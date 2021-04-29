using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using summit_restapi.ApiInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CfjSummit.Domain.Models;
using CfjSummit.Domain.Models.DTOs.Programs;

namespace summit_restapi.Controllers
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
                Data = new ProgramKey()
                {
                    ProgramId = Guid.NewGuid().ToString()
                }
            };
        }
    }

    public class CreateProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public RegisterProgramRequest Program { get; set; }
    }
    public class CreateProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramKey Data { get; set; }
    }
}
