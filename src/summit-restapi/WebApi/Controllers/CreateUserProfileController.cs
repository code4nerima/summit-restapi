using CfjSummit.Domain.Models.DTOs.UserProfiles;
using CfjSummit.Domain.Services.Application;
using CfjSummit.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateUserProfileController : ControllerBase
    {
        [HttpPost]
        public ActionResult<CreateUserProfileResponse> Post([FromBody] CreateUserProfileRequest request, [FromHeader] string authorization)
        {
            // authorizationで認証(Controller)
            // Validation(Model)
            // uidをキーに登録済チェック(Model)
            // OKなら登録(Repository)
            if (!string.IsNullOrEmpty(authorization)) { return Unauthorized(); }
            var command = new CreateUserProfileCommand(request.Uid, request.UserProfile.UserName, request.UserProfile.UserRole);
            _ = command.Execute();
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
