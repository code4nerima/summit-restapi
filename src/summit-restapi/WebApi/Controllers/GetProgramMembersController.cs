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
    public class GetProgramMembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetProgramMembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<GetProgramMembersResponse>> PostAsync([FromBody] GetProgramMembersRequest request, [FromHeader] string authorization)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, request));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new GetProgramMembersQuery(request.Data);
            var item = await _mediator.Send(query);
            return new GetProgramMembersResponse()
            {
                Data = item
            };
        }

    }
    public class GetProgramMembersRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramKeyDataDTO Data { get; set; }
    }
    public class GetProgramMembersResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public GetProgramMembersResponseDTO Data { get; set; }
    }

}
