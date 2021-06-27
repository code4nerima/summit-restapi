using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ListProgramResponseDTO : ListResponseDTO
    {
        [JsonPropertyName("programs")]
        public List<ProgramPartsDataDTO> Programs { get; set; }
    }
}
