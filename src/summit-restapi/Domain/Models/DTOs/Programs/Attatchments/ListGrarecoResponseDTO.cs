using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ListGrarecoResponseDTO
    {
        [JsonPropertyName("grarecos")]
        public List<ProgramGrarecoDTO> ProgramGrarecos { get; set; }

    }
}
