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
    public class CreateProgramController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CreateProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<CreateProgramResponse>> PostAsync([FromBody] CreateProgramRequest request, [FromHeader] string authorization)
        {
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new CreateProgramCommand(request.Uid, request.Program);
            var newProgramId = await _mediator.Send(command);

            return new CreateProgramResponse()
            {
                Result = "1",
                TimeStamp = DateTime.UtcNow,
                Data = new ProgramIdDTO()
                {
                    ProgramId = newProgramId
                }
            };
        }

    }
    public class CreateProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public RegisterProgramRequestDTO Program { get; set; }
    }
    public class CreateProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramIdDTO Data { get; set; }
    }

}
