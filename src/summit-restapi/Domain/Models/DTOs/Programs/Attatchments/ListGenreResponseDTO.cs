using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ListGenreResponseDTO : ListResponseDTO
    {
        [JsonPropertyName("genres")]
        public List<GenreDTO> Grenres { get; set; }

    }
}
