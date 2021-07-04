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
    public class UpdateGenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateGenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<UpdateGenreResponse>> PostAsync([FromBody] UpdateGenreRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new UpdateGenreCommand(request.Data);
            var affected = await _mediator.Send(command);

            return new UpdateGenreResponse()
            {
                Result = affected >= 1 ? "1" : "0",
                Data = new GenreKeyDataDTO()
                {
                    GenreGuid = request.Data.GenreGuid
                }
            };
        }
    }
    public class UpdateGenreRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public GenreDTO Data { get; set; }
    }
    public class UpdateGenreResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public GenreKeyDataDTO Data { get; set; }
    }
}
