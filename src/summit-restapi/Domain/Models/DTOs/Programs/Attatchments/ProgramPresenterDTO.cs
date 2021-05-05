using CfjSummit.Domain.Models.DTOs.UserProfiles;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramPresenterDTO
    {
        [JsonPropertyName("name")]
        public UserNameDTO UserName { get; set; }

    }
}
