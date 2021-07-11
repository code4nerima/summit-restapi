using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
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
    public class CreatePresenterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreatePresenterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<CreatePresenterResponse>> PostAsync([FromBody] CreatePresenterRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new CreateProgramPresenterCommand(request.Data);
            var newPresenterGuid = await _mediator.Send(command);

            return new CreatePresenterResponse()
            {
                Data = new ProgramPresenterKeyDataDTO()
                {
                    ProgramPresenterGuid = newPresenterGuid
                }
            };
        }

    }
    public class CreatePresenterRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramPresenterDTO Data { get; set; }
    }
    public class CreatePresenterResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramPresenterKeyDataDTO Data { get; set; }
    }
}
