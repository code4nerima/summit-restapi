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
    public class UpdateTrackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateTrackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<UpdateTrackResponse>> PostAsync([FromBody] UpdateTrackRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new UpdateTrackCommand(request.Data);
            var affected = await _mediator.Send(command);

            return new UpdateTrackResponse()
            {
                Result = affected == 1 ? "1" : "0",
                Data = new TrackKeyDataDTO()
                {
                    TrackGuid = request.Data.TrackGuid
                }
            };
        }

    }
    public class UpdateTrackRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public TrackDTO Data { get; set; }
    }
    public class UpdateTrackResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public TrackKeyDataDTO Data { get; set; }
    }

}
