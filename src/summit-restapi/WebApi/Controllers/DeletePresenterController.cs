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
    public class DeletePresenterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeletePresenterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<DeletePresenterResponse>> PostAsync([FromBody] DeletePresenterRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));

            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new DeleteProgramPresenterCommand(request.Data);
            var affected = await _mediator.Send(command);

            return new DeletePresenterResponse()
            {
                Result = affected >= 1 ? "1" : "0",
            };
        }


    }
    public class DeletePresenterRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramPresenterKeyDataDTO Data { get; set; }
    }
    public class DeletePresenterResponse : AbstractResponseBody
    {
    }

}
