using CfjSummit.Domain.Models.DTOs.Tracks;
using CfjSummit.Domain.Services.Application.TrackRegistration;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTrackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetTrackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<GetTrackResponse>> PostAsync([FromBody] GetTrackRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new GetTrackQuery(request.Data.TrackGuid);
            var item = await _mediator.Send(query);

            return new GetTrackResponse()
            {
                Data = item
            };
        }


    }
    public class GetTrackRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public TrackKeyDataDTO Data { get; set; }
    }
    public class GetTrackResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public TrackDTO Data { get; set; }
    }

}
