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
    public class CreateGenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateGenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<CreateGenreResponse>> PostAsync([FromBody] CreateGenreRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new CreateGenreCommand(request.Data);
            var newGenreGuid = await _mediator.Send(command);

            return new CreateGenreResponse()
            {
                Data = new GenreKeyDataDTO()
                {
                    GenreGuid = newGenreGuid
                }
            };
        }

    }
    public class CreateGenreRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public GenreDTO Data { get; set; }
    }
    public class CreateGenreResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public GenreKeyDataDTO Data { get; set; }
    }

}
