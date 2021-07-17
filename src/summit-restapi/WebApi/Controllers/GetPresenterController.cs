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
    public class GetPresenterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetPresenterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<GetPresenterResponse>> PostAsync([FromBody] GetPresenterRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new GetProgramPresenterQuery(request.Data);
            var item = await _mediator.Send(query);

            return new GetPresenterResponse()
            {
                Data = item
            };
        }


    }
    public class GetPresenterRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramPresenterKeyDataDTO Data { get; set; }
    }
    public class GetPresenterResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramPresenterDTO Data { get; set; }
    }

}
