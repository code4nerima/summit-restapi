using CfjSummit.Domain.Models.DTOs.Programs;
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
    public class GetProgramOwnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetProgramOwnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<GetProgramOwnersResponse>> PostAsync([FromBody] GetProgramOwnersRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new GetProgramOwnersQuery(request.Data);
            var item = await _mediator.Send(query);
            return new GetProgramOwnersResponse()
            {
                Data = item
            };
        }

    }
    public class GetProgramOwnersRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramKeyDataDTO Data { get; set; }
    }
    public class GetProgramOwnersResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public GetProgramOwnersResponseDTO Data { get; set; }
    }

}
