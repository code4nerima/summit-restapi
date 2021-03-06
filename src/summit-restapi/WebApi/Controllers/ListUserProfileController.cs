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
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));

            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new ListProgramQuery(request.Data);
            var item = await _mediator.Send(query);

            return new ListUserProfileResponse()
            {
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
