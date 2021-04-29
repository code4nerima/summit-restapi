using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateProgramController : ControllerBase
    {
        [HttpPost]
        public CreateProgramResponse Post([FromBody] CreateProgramRequest request, [FromHeader] string authorization)
        {
            // authorizationで認証(Controller)
            // Validation(Model)
            // uidをキーに登録済チェック(Model)
            // OKなら登録(Repository)
            // TODO Resultも1,0じゃなくて、Success/Failで返したいよね。
            if (authorization == "aaa") { return null; }
            return new CreateProgramResponse()
            {
                Result = "1",
                TimeStamp = DateTime.UtcNow,
                Data = new ProgramIdDTO()
                {
                    ProgramId = Guid.NewGuid().ToString()
                }
            };
        }

    }
    public class CreateProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public RegisterProgramRequestDTO Program { get; set; }
    }
    public class CreateProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramIdDTO Data { get; set; }
    }

}
