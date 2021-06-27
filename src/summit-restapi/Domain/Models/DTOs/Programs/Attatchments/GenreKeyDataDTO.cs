using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class GenreKeyDataDTO
    {
        [JsonPropertyName("genreId")]
        public string GenreGuid { get; set; }

    }
}
