using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.Programs;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace ImportPrograms
{
    class Program
    {
        async static Task Main(string[] args)
        {
            //Excelオープン
            var path = @"C:\Users\eveni\Downloads\Time Table-3.xlsx";
            var book = new XSSFWorkbook(path);

            var sheet = book.GetSheet("応募データ");
            var requestBodyList = new List<CreateProgramRequest>();
            foreach (var i in Enumerable.Range(1, 51))
            {
                var row = sheet.GetRow(i);
                var id = row.GetCell(0).Value();
                if (string.IsNullOrEmpty(id)) { break; }

                var date = row.GetCell(1).Value() == "1" ? "2021-09-18" : "2021-09-19";
                var track = row.GetCell(2).Value();
                var startTimeHour = Math.Round(decimal.Parse(row.GetCell(3).Value()) * 24, 0);
                var startTimeMin = Math.Round(decimal.Parse(row.GetCell(3).Value()) * 24 * 60 - startTimeHour * 60, 0);
                var startTime = $"{startTimeHour}:{startTimeMin}";
                var endTimeHour = Math.Round(decimal.Parse(row.GetCell(4).Value()) * 24, 0);
                var endTimeMin = Math.Round(decimal.Parse(row.GetCell(4).Value()) * 24 * 60 - endTimeHour * 60, 0);
                var endTime = $"{endTimeHour}:{endTimeMin}";
                var メールアドレス = row.GetCell(6).Value();
                var 申込者_漢字 = row.GetCell(7).Value();
                var 所属 = row.GetCell(9).Value();
                var プログラムの形式 = row.GetCell(10).Value();
                var ライブ登壇か録画提出か = row.GetCell(12).Value();
                var プログラムテーマ_ジャンルs = row.GetCell(13).Value() == "" ? Array.Empty<string>() : row.GetCell(13).Value().Split(",");
                var プログラム概要 = row.GetCell(16).Value();

                var category = 0;
                switch (プログラムの形式)
                {
                    case "セッション（プレゼンテーション形式の発表）":
                        if (ライブ登壇か録画提出か == "事前に動画を録画して提出")
                        {
                            //録画セッション
                            category = 3;
                        }
                        else if (ライブ登壇か録画提出か == "当日Zoomに接続してライブで登壇")
                        {
                            //セッション
                            category = 1;
                        }
                        else
                        {
                            //無いパターン
                            throw new Exception();
                        }
                        break;
                    case "ワークショップ(参加型、ライブ発信なし)":
                        //ワークショップ
                        category = 2;
                        break;
                }
                var requestBody = new CreateProgramRequest()
                {
                    V = "1",
                    Uid = "Dummy",
                    Data = new ProgramPartsDataDTO()
                    {
                        Category = category,
                        Date = date,
                        Description = new MultilingualValue()
                        {
                            Ja = プログラム概要,
                        },
                        Email = メールアドレス,
                        StartTime = startTime,
                        EndTime = endTime,
                        Title = new MultilingualValue()
                        {
                            Ja = $"{申込者_漢字}-{所属}",
                        },
                        TrackGuid = GetTrackGuid(track),
                        GenreGuids = プログラムテーマ_ジャンルs.Length == 0 ? Array.Empty<string>().ToList() : プログラムテーマ_ジャンルs.Select(x => GetGenreGuid(x)).ToList(),
                        InputCompleted = "0",
                    }
                };
                requestBodyList.Add(requestBody);
            }
            book.Close();

            using var client = new HttpClient();
            foreach (var request in requestBodyList)
            {

                var message = new HttpRequestMessage(HttpMethod.Post, "https://webapi20210430062843.azurewebsites.net/api/CreateProgram");
                message.Headers.Add("authorization", "aaaaa");

                var text = JsonSerializer.Serialize(request);
                message.Content = new StringContent(text, Encoding.UTF8, "application/json");
                var re = await client.SendAsync(message);


                //CreateProgramのRequestbody作成
                if (re.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception();
                }
            }
            //CreateProgram実行
        }

        private static string GetTrackGuid(string track)
        {
            return track switch
            {
                "1" => "f7485be852704effb3c815ef7a23e501",
                "2" => "a180453261484d3a8c28065998b181d2",
                "3" => "58c2233c04e24cc9a70770735e179768",
                "4" => "19b746dfcca44b31b1f46e155380e49f",
                "5" => "28350f4972714db4a1bda030448f5571",
                "6" => "916c1021088046c086558c656ef877bd",
                "7" => "9712dbc0c0f645d28077bd1c61f00489",
                "8" => "5c8221538c9143aa969ac119a2d50675",
                "9" => "de6922ea1b6c43f59dfadeb19d4c9d8b",
                "0" => "f98c53260d024ab383ec9c7c8a0e82b0",
                _ => throw new Exception(),
            };
        }

        private static string GetGenreGuid(string genreName)
        {
            return genreName.Trim() switch
            {
                "東日本大震災復興" => "406f604473d1483bb0f35d3c2655ccbe",
                "防災" => "0bc54c17cf0c4cf6b9c002534247b8db",
                "初心者向け(初心者がやってみた事例。エンジニアじゃないけどできました、説明など)" => "6ee9539414404aad9eaf7751aadb0d24",
                "子育て・育児・保育(子育てしている、保育士/NPOなど向け)" => "d41936409991430bbe734a40667f6921",
                "行政" => "3d6831e6ab2d4b349503d945c1f3848f",
                "Diversity & Inclusion 多文化共生(国籍、世代など)" => "dda2032d34fe4fd7a486c943c44bd9cf",
                "学生(学生による、または学生のため)" => "ed964ea8e27a4c53adff4074c1c213bc",
                "技術紹介" => "abeaf03ca0604c72b1ad2f3f4993b458",
                "研究・アカデミア" => "db13956fbee542eabdc2054f055e130c",
                "オープンデータ" => "3f9ba8639006454aa9d5a44523b135b6",
                "医療・福祉" => "19fb2ec00eaa4da68f849780cd615b06",
                "子供向けプログラミング教育" => "2c21e3a8e2ac456c891fd9cc8d51526e",
                "政治とシビックテック" => "4e35bb7e85254ad29f21a5b70fff07fe",
                "SDGs" => "8c7f90ee7c0a40c3afc55fd7091ac8cb",
                "DX苦労話" => "d95c5292aecd4afe8c9ff2804596df10",
                "アクセシビリティ" => "b7b9038dd92043d59eb880bf8c57143d",
                "インターナショナル" => "9b13cbf0cfaa4b35ae06e43734c85022",
                _ => throw new Exception(),

            };
        }

        private class CreateProgramRequest
        {
            [JsonPropertyName("v")]
            public string V { get; set; }

            [JsonPropertyName("uid")]
            public string Uid { get; set; }

            [JsonPropertyName("data")]
            public ProgramPartsDataDTO Data { get; set; }
        }

    }
}
