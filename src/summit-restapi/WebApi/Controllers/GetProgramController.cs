using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Services.Application.ProgramRegistration;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<GetProgramResponse>> PostAsync([FromBody] GetProgramRequest request, [FromHeader] string authorization)
        {
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new GetProgramQuery(request.Data.ProgramId);
            var item = await _mediator.Send(query);

            return new GetProgramResponse()
            {
                Result = "1",
                TimeStamp = DateTime.UtcNow,
                Data = item
            };
        }

    }
    public class GetProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramIdDTO Data { get; set; }
    }
    public class GetProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramDTO Data { get; set; }
    }
}
