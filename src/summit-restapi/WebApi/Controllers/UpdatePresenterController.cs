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
    public class UpdatePresenterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdatePresenterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<UpdatePresenterResponse>> PostAsync([FromBody] UpdatePresenterRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));

            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new UpdateProgramPresenterCommand(request.Data);
            var affected = await _mediator.Send(command);

            return new UpdatePresenterResponse()
            {
                Result = affected >= 1 ? "1" : "0",
                Data = new ProgramPresenterKeyDataDTO()
                {
                    ProgramPresenterGuid = request.Data.ProgramPresenterGuid
                }
            };
        }

    }
    public class UpdatePresenterRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramPresenterDTO Data { get; set; }
    }
    public class UpdatePresenterResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramPresenterKeyDataDTO Data { get; set; }
    }

}
