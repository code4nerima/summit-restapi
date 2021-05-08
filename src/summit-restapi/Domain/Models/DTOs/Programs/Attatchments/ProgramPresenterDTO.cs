using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramPresenterDTO
    {
        [JsonPropertyName("name")]
        public MultilingualValue UserName { get; set; }

    }
}
