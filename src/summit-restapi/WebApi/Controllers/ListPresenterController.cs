using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
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
    public class ListPresenterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListPresenterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async ValueTask<ActionResult<ListPresenterResponse>> PostAsync([FromBody] ListPresenterRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new ListProgramPresenterQuery(request.Data);
            var item = await _mediator.Send(query);
            return new ListPresenterResponse()
            {
                Data = item
            };
        }

    }
    public class ListPresenterRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ListPresenterRequestDTO Data { get; set; }
    }

    public class ListPresenterResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ListPresenterResponseDTO Data { get; set; }
    }

}
