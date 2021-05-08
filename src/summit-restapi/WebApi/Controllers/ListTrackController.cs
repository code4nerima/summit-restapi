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
    public class ListTrackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListTrackController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async ValueTask<ActionResult<ListTrackResponse>> PostAsync([FromBody] ListTrackRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new ListTrackQuery(request.Data);
            var item = await _mediator.Send(query);
            return new ListTrackResponse()
            {
                Data = item
            };
        }

    }
    public class ListTrackRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ListTrackRequestDTO Data { get; set; }
    }

    public class ListTrackResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ListTrackResponseDTO Data { get; set; }
    }

}
