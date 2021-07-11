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
                    }
                }).ToList(),
                Description = new MultilingualValue()
                {
                    Ja = p.Description_Ja,
                    En = p.Description_En,
                    ZhTw = p.Description_Zh_Tw,
                    ZhCn = p.Description_Zh_Cn
                },
                Email = p.Email,
                GenreGuids = p.ProgramGenres.Select(x => x.Genre.GenreGuid).ToList(),
                ProgramPresenters = p.ProgramPresenters.OrderBy(x => x.SortOrder).ThenBy(x => x.Name_Ja_Kana).Select(x => new ProgramPresenterDTO()
                {
                    ProgramPresenterGuid = x.ProgramPresenterGuid,
                    UserName = new MultilingualValue()
                    {
                        Ja = x.Name_Ja,
                        Ja_Kana = x.Name_Ja_Kana,
                        En = x.Name_En,
                        ZhTw = x.Name_Zh_Tw,
                        ZhCn = x.Name_Zh_Cn
                    },
                    Description = new MultilingualValue()
                    {
                        Ja = x.Description_Ja,
                        En = x.Description_En,
                        ZhTw = x.Description_Zh_Tw,
                        ZhCn = x.Description_Zh_Cn
                    },
                    Organization = new MultilingualValue()
                    {
                        Ja = x.Organization_Ja,
                        En = x.Organization_En,
                        ZhTw = x.Organization_Zh_Tw,
                        ZhCn = x.Organization_Zh_Cn
                    },
                    PhotoURL = x.PhotoURL,
                    SortOrder = x.SortOrder
                }
                ).ToList()
            };
            return dto;

        }
    }
}
