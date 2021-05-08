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
    public class CreateTrackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateTrackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<CreateTrackResponse>> PostAsync([FromBody] CreateTrackRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new CreateTrackCommand(request.Data);
            var newTrackGuid = await _mediator.Send(command);

            return new CreateTrackResponse()
            {
                Data = new TrackKeyDataDTO()
                {
                    TrackGuid = newTrackGuid
                }
            };
        }

    }
    public class CreateTrackRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public TrackDTO Data { get; set; }
    }
    public class CreateTrackResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public TrackKeyDataDTO Data { get; set; }
    }

}
