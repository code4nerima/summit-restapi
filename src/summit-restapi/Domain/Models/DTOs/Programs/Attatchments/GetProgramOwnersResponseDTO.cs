using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class GetProgramOwnersResponseDTO
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
        [JsonPropertyName("owners")]
        public List<ProgramOwnerDTO> Owners { get; set; }
    }
}
