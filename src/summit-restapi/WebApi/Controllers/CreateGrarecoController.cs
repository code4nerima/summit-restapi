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
    public class CreateGrarecoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateGrarecoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<CreateGrarecoResponse>> PostAsync([FromBody] CreateGrarecoRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new CreateProgramGrarecoCommand(request.Data);
            var newGrarecoGuid = await _mediator.Send(command);

            return new CreateGrarecoResponse()
            {
                Data = new ProgramGrarecoKeyDataDTO()
                {
                    ProgramGrarecoGuid = newGrarecoGuid
                }
            };
        }

    }
    public class CreateGrarecoRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramGrarecoDTO Data { get; set; }
    }
    public class CreateGrarecoResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramGrarecoKeyDataDTO Data { get; set; }
    }

}
