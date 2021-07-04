using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Services.Application.ProgramRegistration;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListRelatedProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListRelatedProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async ValueTask<ActionResult<ListRelatedProgramResponse>> PostAsync([FromBody] ListRelatedProgramRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new ListRelatedProgramQuery(request.Data);
            var item = await _mediator.Send(query);
            return new ListRelatedProgramResponse()
            {
                Data = item
            };
        }

    }
    public class ListRelatedProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ListRelatedProgramRequestDTO Data { get; set; }
    }

    public class ListRelatedProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ListRelatedProgramResponseDTO Data { get; set; }
    }

}
