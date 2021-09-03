using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramDTO : ProgramPartsDataDTO
    {
        [JsonPropertyName("owners")]
        public List<ProgramOwnerDTO> ProgramOwners { set; get; } = new();

        [JsonPropertyName("presenters")]
        public List<ProgramPresenterDTO> ProgramPresenters { set; get; } = new();

        [JsonPropertyName("members")]
        public List<ProgramMemberDTO> ProgramMembers { set; get; } = new();

        [JsonPropertyName("grarecos")]
        public List<ProgramGrarecoDTO> ProgramGrarecos { set; get; } = new();

        public static ProgramDTO CreateDto(Program p)
        {
            var dto = new ProgramDTO()
            {
                ProgramGuid = p.ProgramGuid,
                Title = new MultilingualValue()
                {
                    Ja = p.Title_Ja,
                    En = p.Title_En,
                    ZhTw = p.Title_Zh_Tw,
                    ZhCn = p.Title_Zh_Cn
                },
                Category = p.ProgramCategory,
                Date = p.Date,
                StartTime = p.StartTime,
                EndTime = p.EndTime,
                TrackGuid = p.Track?.TrackGuid ?? "",
                TrackName = new MultilingualValue()
                {
                    Ja = p.Track?.Name_Ja ?? "",
                    En = p.Track?.Name_En ?? "",
                    ZhTw = p.Track?.Name_Zh_Tw ?? "",
                    ZhCn = p.Track?.Name_Zh_Cn ?? ""
                },
                UdTalkWebURL = p.Track?.UdTalkWebURL,
                UdTalkAppURL = p.Track?.UdTalkAppURL,
                //収録配信セッション時はProgramのBroadcastingURLを登録するので、こっちが優先。
                //収録配信セッション以外はTrackのBroadcastingURLを使用。(1日目はBroadcastingURL01,2日目はBroadcastingURL02)
                BroadcastingURL = !string.IsNullOrEmpty(p.BroadcastingURL) ? p.BroadcastingURL : (p.Date.EndsWith("18") ? p.Track?.BroadcastingURL_1stDay : p.Track?.BroadcastingURL_2ndDay),
                PresentationURL = p.PresentationURL,
                ProgramOwners = p.ProgramOwnerUserProfiles.Select(x => new ProgramOwnerDTO()
                {
                    Uid = x.UserProfile.Uid,
                    UserName = new MultilingualValue()
                    {
                        Ja = x.UserProfile.Name_Ja,
                        Ja_Kana = x.UserProfile.Name_Ja_Kana,
                        En = x.UserProfile.Name_En,
                        ZhTw = x.UserProfile.Name_Zh_Tw,
                        ZhCn = x.UserProfile.Name_Zh_Cn
                    }
                }).ToList(),
                ProgramMembers = p.ProgramMemberUserProfiles.Select(x => new ProgramMemberDTO()
                {
                    Uid = x.UserProfile.Uid,
                    UserName = new MultilingualValue()
                    {
                        Ja = x.UserProfile.Name_Ja,
                        Ja_Kana = x.UserProfile.Name_Ja_Kana,
                        En = x.UserProfile.Name_En,
                        ZhTw = x.UserProfile.Name_Zh_Tw,
                        ZhCn = x.UserProfile.Name_Zh_Cn
                    },
                    StaffRole = x.StaffRole
                }).ToList(),
                Description = new MultilingualValue()
                {
                    Ja = p.Description_Ja,
                    En = p.Description_En,
                    ZhTw = p.Description_Zh_Tw,
                    ZhCn = p.Description_Zh_Cn
                },
                Email = p.Email,
                InputCompleted = p.InputCompleted,
                GenreGuids = p.ProgramGenres.Select(x => x.Genre.GenreGuid).ToList(),
                ProgramPresenters = p.ProgramPresenters.OrderBy(x => x.SortOrder)
                                                       .ThenBy(x => x.Name_Ja_Kana)
                                                       .Select(x => ProgramPresenterDTO.CreateDto(x))
                                                       .ToList(),
                ProgramLinks = p.ProgramLinks.OrderBy(x => x.SortOrder)
                                            .ThenBy(x => x.Title_Ja)
                                            .Select(x => new ProgramLinkDTO()
                                            {
                                                Title = new MultilingualValue()
                                                {
                                                    Ja = x.Title_Ja,
                                                    En = x.Title_En,
                                                    ZhTw = x.Title_Zh_Tw,
                                                    ZhCn = x.Title_Zh_Cn
                                                },
                                                SortOrder = x.SortOrder,
                                                Url = x.Url
                                            }).ToList(),
                ProgramGrarecos = p.ProgramGrarecos.OrderBy(x => x.SortOrder)
                                                   .Select(x => ProgramGrarecoDTO.CreateDto(x))
                                                   .ToList(),
            };
            return dto;

        }
    }
}
