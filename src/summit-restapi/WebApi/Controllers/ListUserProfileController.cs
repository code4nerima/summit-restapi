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
    public class ListUserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListUserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ListUserProfileResponse>> PostAsync([FromBody] ListUserProfileRequest request, [FromHeader] string authorization)
        {
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new ListUserProfileQuery(request.Data);
            var item = await _mediator.Send(query);

            return new ListUserProfileResponse()
            {
                Result = "1",
                TimeStamp = DateTime.UtcNow,
                Data = item
            };
        }

    }
    public class ListUserProfileRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ListUserProfileRequestDTO Data { get; set; }
    }

    public class ListUserProfileResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ListUserProfileResponseDTO Data { get; set; }
    }
}
