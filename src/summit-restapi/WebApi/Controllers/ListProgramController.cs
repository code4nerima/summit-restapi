using CfjSummit.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListProgramController : ControllerBase
    {
    }
    public class ListProgramRequest : AbstractRequestBody
    {
        //[JsonPropertyName("data")]
        //public ListUserProfileRequestDTO Data { get; set; }
    }

    public class ListProgramResponse : AbstractResponseBody
    {
        //[JsonPropertyName("data")]
        //public ListUserProfileResponseDTO Data { get; set; }
    }

}
