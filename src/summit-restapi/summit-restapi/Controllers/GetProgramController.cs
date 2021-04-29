using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.DTOs.UserProfiles;
using CfjSummit.Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using summit_restapi.ApiInterfaces;
using System;
using System.Text.Json.Serialization;

namespace summit_restapi.Controllers
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
            var item = new ProgramItem()
            {
                Category = ProgramCategory.Session,
                Description = new ProgramDescription()
                {
                    En = "hoge",
                    Ja = "hoge",
                    ZhCn = "hoge",
                    ZhTw = "hoge"
                },
                Title = new ProgramTitle()
                {
                    En = "fuga",
                    Ja = "fuga",
                    ZhCn = "piyo",
                    ZhTw = "piyopiyo"
                }
            };
            item.AddProgramOwner(new ProgramOwner() { Uid = "hoge9", UserName = new UserName() { En = "en9", Ja = "ja9", ZhCn = "zhcn9", ZhTw = "zhtw9" } });
            item.AddProgramOwner(new ProgramOwner() { Uid = "hoge3", UserName = new UserName() { En = "en3", Ja = "ja3", ZhCn = "zhcn3", ZhTw = "zhtw3" } });

            item.AddProgramMember(new ProgramMember() { Uid = "fuga1", UserName = new UserName() { En = "en1", Ja = "ja1", ZhCn = "zhcn1", ZhTw = "zhtw1" } });
            item.AddProgramMember(new ProgramMember() { Uid = "fuga5", UserName = new UserName() { En = "en5", Ja = "ja5", ZhCn = "zhcn5", ZhTw = "zhtw5" } });
            item.AddProgramMember(new ProgramMember() { Uid = "fuga3", UserName = new UserName() { En = "en3", Ja = "ja3", ZhCn = "zhcn3", ZhTw = "zhtw3" } });
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
        public ProgramKey Data { get; set; }
    }
    public class GetProgramResponse : AbstractResponseBody
    {
        [JsonPropertyName("data")]
        public ProgramItem Data { get; set; }
    }

}
