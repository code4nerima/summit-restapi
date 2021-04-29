using CfjSummit.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class RegisterProgramRequest
    {

        [JsonPropertyName("title")]
        public ProgramTitle Title { set; get; }

        [JsonPropertyName("category")]
        public ProgramCategory Category { set; get; }
    }
}
