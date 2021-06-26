using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListGenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListGenreController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async ValueTask<ActionResult<ListGenreResponse>> PostAsync([FromBody] ListGenreRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new ListGenreQuery(request.Data);
            var item = await _mediator.Send(query);
            return new ListGenreResponse()
            {
                Data = item
            };
        }

    }
    public class ListGenreRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ListGenreRequestDTO Data { get; set; }
    }

    public class ListGenreResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ListGenreResponseDTO Data { get; set; }
    }

}
