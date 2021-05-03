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
    public class UpdateProgramOwnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateProgramOwnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<UpdateProgramOwnersResponse>> PostAsync([FromBody] UpdateProgramOwnersRequest request, [FromHeader] string authorization)
        {
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new UpdateProgramOwnersCommand(request.Data);
            _ = await _mediator.Send(command);
            return new UpdateProgramOwnersResponse();
        }

    }
    public class UpdateProgramOwnersRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public UpdateProgramOwnersRequestDTO Data { get; set; }
    }
    public class UpdateProgramOwnersResponse : AbstractResponseBody
    {
    }

}
