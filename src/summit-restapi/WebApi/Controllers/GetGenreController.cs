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
    public class GetGenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetGenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<GetGenreResponse>> PostAsync([FromBody] GetGenreRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new GetGenreQuery(request.Data.GenreGuid);
            var item = await _mediator.Send(query);

            return new GetGenreResponse()
            {
                Data = item
            };
        }
    }
    public class GetGenreRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public GenreKeyDataDTO Data { get; set; }
    }
    public class GetGenreResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public GenreDTO Data { get; set; }
    }

}
