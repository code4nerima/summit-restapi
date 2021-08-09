using CfjSummit.Domain.Models.Entities;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramPresenterLinkDTO
    {
        public ProgramPresenterLinkDTO()
        {

        }

        [JsonPropertyName("sortOrder")]
        public int SortOrder { get; set; }

        [JsonPropertyName("title")]
        public MultilingualValue Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        public static ProgramPresenterLinkDTO CreateDto(ProgramPresenterLink programPresenterLink)
        {
            return new ProgramPresenterLinkDTO()
            {
                SortOrder = programPresenterLink.SortOrder,
                Title = new MultilingualValue()
                {
                    Ja = programPresenterLink.Title_Ja,
                    En = programPresenterLink.Title_En,
                    ZhTw = programPresenterLink.Title_Zh_Tw,
                    ZhCn = programPresenterLink.Title_Zh_Cn
                },
                Url = programPresenterLink.Url
            };
        }
    }
}
