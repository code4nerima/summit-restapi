using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Services.Application.ProgramRegistration;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeleteProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<DeleteProgramResponse>> PostAsync([FromBody] DeleteProgramRequest request, [FromHeader] string authorization)
        {
            // authorizationで認証(Controller)
            // Validation(Model)
            // uidをキーに登録済チェック(Model)
            // OKなら登録(Repository)
            // TODO Resultも1,0じゃなくて、Success/Failで返したいよね。
            var command = new DeleteProgramCommand(request.Data.ProgramId);
            var programId = await _mediator.Send(command);

            return new DeleteProgramResponse()
            {
                Result = "1",
                TimeStamp = DateTime.UtcNow
            };
        }

    }
    public class DeleteProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramIdDTO Data { get; set; }
    }
    public class DeleteProgramResponse : AbstractResponseBody
    {
    }

}
