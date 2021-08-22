using CfjSummit.Domain.Models.Entities;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramGrarecoDTO : ProgramGrarecoKeyDataDTO
    {
        public ProgramGrarecoDTO()
        {

        }
        [JsonPropertyName("name")]
        public MultilingualValue Name { get; set; }

        [JsonPropertyName("organization")]
        public MultilingualValue Organization { get; set; }

        [JsonPropertyName("description")]
        public MultilingualValue Description { get; set; }

        [JsonPropertyName("photoURL")]
        public string PhotoURL { get; set; }

        [JsonPropertyName("sortOrder")]
        public int SortOrder { get; set; }

        public static ProgramGrarecoDTO CreateDto(ProgramGrareco pp)
        {
            var dto = new ProgramGrarecoDTO()
            {
                ProgramGrarecoGuid = pp.ProgramGrarecoGuid,
                Name = new MultilingualValue()
                {
                    Ja = pp.Name_Ja,
                    Ja_Kana = pp.Name_Ja_Kana,
                    En = pp.Name_En,
                    ZhTw = pp.Name_Zh_Tw,
                    ZhCn = pp.Name_Zh_Cn
                },
                Description = new MultilingualValue()
                {
                    Ja = pp.Description_Ja,
                    En = pp.Description_En,
                    ZhTw = pp.Description_Zh_Tw,
                    ZhCn = pp.Description_Zh_Cn
                },
                Organization = new MultilingualValue()
                {
                    Ja = pp.Organization_Ja,
                    En = pp.Organization_En,
                    ZhTw = pp.Organization_Zh_Tw,
                    ZhCn = pp.Organization_Zh_Cn
                },
                PhotoURL = pp.PhotoURL,
                SortOrder = pp.SortOrder,
            };
            return dto;
        }

    }
}
