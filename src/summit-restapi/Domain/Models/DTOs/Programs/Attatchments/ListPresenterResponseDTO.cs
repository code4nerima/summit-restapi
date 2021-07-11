using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ListPresenterResponseDTO
    {
        [JsonPropertyName("presenters")]
        public List<ProgramPresenterDTO> ProgramPresenters { get; set; }

    }
}
