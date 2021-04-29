using CfjSummit.Domain.Models.DTOs.UserProfiles;
using Microsoft.AspNetCore.Mvc;
using summit_restapi.ApiInterfaces;
using System;
using System.Text.Json.Serialization;

namespace summit_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateUserProfileController : ControllerBase
    {
        [HttpPost]
        public UpdateUserProfileResponse Post([FromBody] UpdateUserProfileRequest request, [FromHeader] string authorization)
        {
            // authorizationで認証(Controller)
            // Validation(Model)
            // uidをキーに登録済チェック(Model)
            // OKなら登録(Repository)
            if (authorization == "aaa") { return null; }
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
