using CfjSummit.Domain.Models.DTOs.UserProfiles;
using CfjSummit.Domain.Services.Application.UserProfileRegistration;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateUserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CreateUserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<CreateUserProfileResponse>> PostAsync([FromBody] CreateUserProfileRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new CreateUserProfileCommand(request.Data);
            _ = await _mediator.Send(command);
            return new CreateUserProfileResponse();
        }

    }
    public class CreateUserProfileRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public UserProfileDTO Data { get; set; }
    }

    public class CreateUserProfileResponse : AbstractResponseBody
    {
    }

}
