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
    public class DeleteGenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeleteGenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<DeleteGenreResponse>> PostAsync([FromBody] DeleteGenreRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new DeleteGenreCommand(request.Data.GenreGuid);
            var affected = await _mediator.Send(command);

            return new DeleteGenreResponse()
            {
                Result = affected == 1 ? "1" : "2"
            };
        }
    }
    public class DeleteGenreRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public GenreKeyDataDTO Data { get; set; }
    }
    public class DeleteGenreResponse : AbstractResponseBody
    {
    }
}
