﻿using CfjSummit.Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class RegisterProgramRequestDTO
    {

        [JsonPropertyName("title")]
        public ProgramTitleDTO Title { set; get; }

        [JsonPropertyName("category")]
        public ProgramCategory Category { set; get; }
    }
}