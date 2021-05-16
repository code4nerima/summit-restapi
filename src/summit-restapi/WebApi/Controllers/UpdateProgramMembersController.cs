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
    public class UpdateProgramMembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateProgramMembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<UpdateProgramMembersResponse>> PostAsync([FromBody] UpdateProgramMembersRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));

            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new UpdateProgramMembersCommand(request.Data);
            _ = await _mediator.Send(command);
            return new UpdateProgramMembersResponse();
        }

    }
    public class UpdateProgramMembersRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public UpdateProgramMembersRequestDTO Data { get; set; }
    }
    public class UpdateProgramMembersResponse : AbstractResponseBody
    {
    }

}
