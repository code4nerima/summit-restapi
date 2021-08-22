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
    public class ListGrarecoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListGrarecoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async ValueTask<ActionResult<ListGrarecoResponse>> PostAsync([FromBody] ListGrarecoRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new ListProgramGrarecoQuery(request.Data);
            var item = await _mediator.Send(query);
            return new ListGrarecoResponse()
            {
                Data = item
            };
        }

    }
    public class ListGrarecoRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ListGrarecoRequestDTO Data { get; set; }
    }

    public class ListGrarecoResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ListGrarecoResponseDTO Data { get; set; }
    }

}
