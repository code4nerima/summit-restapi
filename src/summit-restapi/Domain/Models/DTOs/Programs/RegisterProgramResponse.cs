using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class RegisterProgramResponse
    {
        [JsonPropertyName("programId")]
        public string ProgramId { get; set; }
    }
}
