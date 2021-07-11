using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramPresenterDTO : ProgramPresenterKeyDataDTO
    {
        [JsonPropertyName("name")]
        public MultilingualValue UserName { get; set; }

        [JsonPropertyName("organization")]
        public MultilingualValue Organization { get; set; }

        [JsonPropertyName("description")]
        public MultilingualValue Description { get; set; }

        [JsonPropertyName("photoURL")]
        public string PhotoURL { get; set; }

        [JsonPropertyName("sortOrder")]
        public int SortOrder { get; set; }
    }
}
