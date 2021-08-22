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
    public class GetGrarecoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetGrarecoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<GetGrarecoResponse>> PostAsync([FromBody] GetGrarecoRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new GetProgramGrarecoQuery(request.Data);
            var item = await _mediator.Send(query);

            return new GetGrarecoResponse()
            {
                Data = item
            };
        }

    }
    public class GetGrarecoRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramGrarecoKeyDataDTO Data { get; set; }
    }
    public class GetGrarecoResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramGrarecoDTO Data { get; set; }
    }

}
