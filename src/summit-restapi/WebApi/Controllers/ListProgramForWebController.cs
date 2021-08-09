using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Services.Application.ProgramRegistration;
using CfjSummit.WebApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListProgramForWebController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ListProgramForWebController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<ActionResult<ListProgramForWebResponse>> GetAsync([FromHeader] string authorization,
            [FromQuery] string lang, [FromQuery] string date)
        {
            await _mediator.Send(Logger.CreateWriteLogCommand(Request, ""));
            if (!Authorization.Authorized(authorization)) { return Unauthorized(); }
            var query = new ListProgramForWebQuery(lang, date);
            var item = await _mediator.Send(query);
            return new ListProgramForWebResponse()
            {
                Data = item
            };
        }

    }

    public class ListProgramForWebResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public List<ListProgramForWebResponseDTO> Data { get; set; }
    }

}
