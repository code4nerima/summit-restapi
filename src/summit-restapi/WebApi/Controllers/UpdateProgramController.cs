using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Services.Application.ProgramRegistration;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<UpdateProgramResponse>> PostAsync([FromBody] UpdateProgramRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));

            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new UpdateProgramCommand(request.Data);
            var affected = await _mediator.Send(command);

            return new UpdateProgramResponse()
            {
                Result = affected >= 1 ? "1" : "0",
                Data = new ProgramKeyDataDTO()
                {
                    ProgramGuid = request.Data.ProgramGuid
                }
            };
        }

    }
    public class UpdateProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramPartsDataDTO Data { get; set; }
    }
    public class UpdateProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramKeyDataDTO Data { get; set; }
    }
}
