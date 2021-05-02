using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Services.Application.ProgramRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    public class ListProgramController : ControllerBaseExtention
    {
        private readonly IMediator _mediator;

        public ListProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ListProgramResponse>> PostAsync([FromBody] ListProgramRequest request, [FromHeader] string authorization)
        {
            if (!Authorized(authorization)) { return Unauthorized(); }
            var query = new ListProgramQuery(request.Data);
            var item = await _mediator.Send(query);
            return new ListProgramResponse()
            {
                Data = item
            };
        }

    }
    public class ListProgramRequest : RequestBodyBase
    {
        [JsonPropertyName("data")]
        public ListProgramRequestDTO Data { get; set; }
    }

    public class ListProgramResponse : ResponseBodyBase
    {
        [JsonPropertyName("data")]
        public ListProgramResponseDTO Data { get; set; }
    }

}
