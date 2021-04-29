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
    public class UpdateUserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UpdateUserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async ValueTask<ActionResult<UpdateUserProfileResponse>> Post([FromBody] UpdateUserProfileRequest request, [FromHeader] string authorization)
        {
            // authorizationで認証(Controller)
            // Validation(Model)
            // uidをキーに登録済チェック(Model)
            // OKなら登録(Repository)
            var command = new UpdateUserProfileCommand(request.Uid, request.UserProfile);
            _ = await _mediator.Send(command);
            return new UpdateUserProfileResponse() { Result = "1", TimeStamp = DateTime.UtcNow };
        }
    }
    public class UpdateUserProfileRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public UserProfileDTO UserProfile { get; set; }
    }

    public class UpdateUserProfileResponse : AbstractResponseBody
    {
    }
}
