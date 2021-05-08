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
    public class CreateProgramController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CreateProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<CreateProgramResponse>> PostAsync([FromBody] CreateProgramRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new CreateProgramCommand(request.Data);
            var newProgramId = await _mediator.Send(command);

            return new CreateProgramResponse()
            {
                Data = new ProgramKeyDataDTO()
                {
                    ProgramGuid = newProgramId
                }
            };
        }

    }
    public class CreateProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramPartsDataDTO Data { get; set; }
    }
    public class CreateProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramKeyDataDTO Data { get; set; }
    }

}
