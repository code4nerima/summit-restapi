using CfjSummit.Domain.Models.DTOs.UserProfiles;
using Microsoft.AspNetCore.Mvc;
using summit_restapi.ApiInterfaces;
using System;
using System.Text.Json.Serialization;

namespace summit_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateUserProfileController : ControllerBase
    {
        [HttpPost]
        public CreateUserProfileResponse Post([FromBody] CreateUserProfileRequest request, [FromHeader] string authorization)
        {
            // authorizationで認証(Controller)
            // Validation(Model)
            // uidをキーに登録済チェック(Model)
            // OKなら登録(Repository)
            if (authorization == "aaa") { return null; }
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
