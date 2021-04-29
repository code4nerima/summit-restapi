using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.DTOs.UserProfiles;
using CfjSummit.Domain.Models.Enums;
using CfjSummit.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProgramController : ControllerBase
    {
        [HttpPost]
        public GetProgramResponse Post([FromBody] GetProgramRequest request, [FromHeader] string authorization)
        {
            // authorizationで認証(Controller)
            // Validation(Model)
            // uidをキーに登録済チェック(Model)
            // OKなら登録(Repository) 
            // TODO Resultも1,0じゃなくて、Success/Failで返したいよね。
            if (authorization == "aaa") { return null; }
            var item = new ProgramDTO()
            {
                Category = ProgramCategory.Session,
                Description = new ProgramDescriptionDTO()
                {
                    En = "hoge",
                    Ja = "hoge",
                    ZhCn = "hoge",
                    ZhTw = "hoge"
                },
                Title = new ProgramTitleDTO()
                {
                    En = "fuga",
                    Ja = "fuga",
                    ZhCn = "piyo",
                    ZhTw = "piyopiyo"
                }
            };
            item.AddProgramOwner(new ProgramOwnerDTO() { Uid = "hoge9", UserName = new UserNameDTO() { En = "en9", Ja = "ja9", ZhCn = "zhcn9", ZhTw = "zhtw9" } });
            item.AddProgramOwner(new ProgramOwnerDTO() { Uid = "hoge3", UserName = new UserNameDTO() { En = "en3", Ja = "ja3", ZhCn = "zhcn3", ZhTw = "zhtw3" } });

            item.AddProgramMember(new ProgramMemberDTO() { Uid = "fuga1", UserName = new UserNameDTO() { En = "en1", Ja = "ja1", ZhCn = "zhcn1", ZhTw = "zhtw1" } });
            item.AddProgramMember(new ProgramMemberDTO() { Uid = "fuga5", UserName = new UserNameDTO() { En = "en5", Ja = "ja5", ZhCn = "zhcn5", ZhTw = "zhtw5" } });
            item.AddProgramMember(new ProgramMemberDTO() { Uid = "fuga3", UserName = new UserNameDTO() { En = "en3", Ja = "ja3", ZhCn = "zhcn3", ZhTw = "zhtw3" } });
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
