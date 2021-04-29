using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProgramController : ControllerBase
    {
        [HttpPost]
        public UpdateProgramResponse Post([FromBody] UpdateProgramRequest request, [FromHeader] string authorization)
        {
            // authorizationで認証(Controller)
            // Validation(Model)
            // uidをキーに登録済チェック(Model)
            // OKなら登録(Repository)
            // TODO Resultも1,0じゃなくて、Success/Failで返したいよね。
            if (authorization == "aaa") { return null; }
            return new UpdateProgramResponse()
            {
                Result = "1",
                TimeStamp = DateTime.UtcNow,
                Data = new ProgramIdDTO()
                {
                    ProgramId = request.Program.ProgramId
                }
            };
        }

    }
    public class UpdateProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public EditProgramRequestDTO Program { get; set; }
    }
    public class UpdateProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramIdDTO Data { get; set; }
    }
}
