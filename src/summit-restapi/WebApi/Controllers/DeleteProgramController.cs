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
    public class DeleteProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeleteProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<ActionResult<DeleteProgramResponse>> PostAsync([FromBody] DeleteProgramRequest request, [FromHeader] string authorization)
        {
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var command = new DeleteProgramCommand(request.Data.ProgramId);
            _ = await _mediator.Send(command);

            return new DeleteProgramResponse()
            {
                Result = "1",
                TimeStamp = DateTime.UtcNow
            };
        }

    }
    public class DeleteProgramRequest : AbstractRequestBody
    {
        [JsonPropertyName("data")]
        public ProgramIdDTO Data { get; set; }
    }
    public class DeleteProgramResponse : AbstractResponseBody
    {
    }

}
