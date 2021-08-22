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
    public class UpdateGrarecoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateGrarecoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<UpdateGrarecoResponse>> PostAsync([FromBody] UpdateGrarecoRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));

            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new UpdateProgramGrarecoCommand(request.Data);
            var affected = await _mediator.Send(command);

            return new UpdateGrarecoResponse()
            {
                Result = affected >= 1 ? "1" : "0",
                Data = new ProgramGrarecoKeyDataDTO()
                {
                    ProgramGrarecoGuid = request.Data.ProgramGrarecoGuid
                }
            };
        }

    }
    public class UpdateGrarecoRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramGrarecoDTO Data { get; set; }
    }
    public class UpdateGrarecoResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramGrarecoKeyDataDTO Data { get; set; }
    }

}
