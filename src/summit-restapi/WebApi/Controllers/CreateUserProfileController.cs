using CfjSummit.Domain.Models.DTOs.UserProfiles;
using CfjSummit.Domain.Services.Application.UserProfileRegistration;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new CreateUserProfileCommand(request.Uid, request.UserProfile);
            _ = await _mediator.Send(command);
            return new CreateUserProfileResponse() { Result = "1", TimeStamp = DateTime.UtcNow };
        }

    }
    public class CreateUserProfileRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public UserProfileDTO UserProfile { get; set; }
    }

    public class CreateUserProfileResponse : AbstractResponseBody
    {
    }

}
