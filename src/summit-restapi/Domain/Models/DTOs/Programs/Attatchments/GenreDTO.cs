using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class GenreDTO : GenreKeyDataDTO
    {
        [JsonPropertyName("name")]
        public MultilingualValue Name { set; get; }

    }
}
