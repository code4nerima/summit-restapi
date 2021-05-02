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
    public class GetUserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetUserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<GetUserProfileResponse>> PostAsync([FromBody] GetUserProfileRequest request, [FromHeader] string authorization)
        {
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new GetUserProfileQuery(request.Data.Uid);
            var item = await _mediator.Send(query);

            return new GetUserProfileResponse()
            {
                Result = "1",
                TimeStamp = DateTime.UtcNow,
                Data = item
            };
        }

    }
    public class GetUserProfileRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public UidDTO Data { get; set; }
    }
    public class GetUserProfileResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public GetUserProfileDTO Data { get; set; }
    }

}
