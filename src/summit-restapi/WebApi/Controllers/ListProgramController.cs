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
    public class ListProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async ValueTask<ActionResult<ListProgramResponse>> PostAsync([FromBody] ListProgramRequest request, [FromHeader] string authorization)
        {
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new ListProgramQuery(request.Data);
            var item = await _mediator.Send(query);
            return new ListProgramResponse()
            {
                Data = item
            };
        }
    }
    public class ListProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ListProgramRequestDTO Data { get; set; }
    }

    public class ListProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ListProgramResponseDTO Data { get; set; }
    }
}
