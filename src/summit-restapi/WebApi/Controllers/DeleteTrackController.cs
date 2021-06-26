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
    public class DeleteTrackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeleteTrackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<DeleteProgramResponse>> PostAsync([FromBody] DeleteTrackRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new DeleteTrackCommand(request.Data.TrackGuid);
            var deleted = await _mediator.Send(command);

            return new DeleteProgramResponse()
            {
                Result = deleted ? "1" : "2"
            };
        }
    }
    public class DeleteTrackRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public TrackKeyDataDTO Data { get; set; }
    }
    public class DeleteTrackResponse : AbstractResponseBody
    {
    }

}
