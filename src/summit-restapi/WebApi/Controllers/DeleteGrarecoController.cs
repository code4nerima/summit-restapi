using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteGrarecoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeleteGrarecoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<DeleteGrarecoResponse>> PostAsync([FromBody] DeleteGrarecoRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));

            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new DeleteProgramGrarecoCommand(request.Data);
            var affected = await _mediator.Send(command);

            return new DeleteGrarecoResponse()
            {
                Result = affected >= 1 ? "1" : "0",
            };
        }

    }
    public class DeleteGrarecoRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramGrarecoKeyDataDTO Data { get; set; }
    }
    public class DeleteGrarecoResponse : AbstractResponseBody
    {
    }

}
