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
    public class UpdateProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<UpdateProgramResponse>> PostAsync([FromBody] UpdateProgramRequest request, [FromHeader] string authorization)
        {
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new UpdateProgramCommand(request.Uid, request.Program);
            var programId = await _mediator.Send(command);

            return new UpdateProgramResponse()
            {
                Result = "1",
                TimeStamp = DateTime.UtcNow,
                Data = new ProgramIdDTO()
                {
                    ProgramId = programId
                }
            };
        }

    }
    public class UpdateProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public EditProgramRequestDTO Program { get; set; }
    }
    public class UpdateProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramIdDTO Data { get; set; }
    }
}
