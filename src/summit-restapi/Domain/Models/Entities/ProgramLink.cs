using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;

namespace CfjSummit.Domain.Models.Entities
{
    public class ProgramLink : Entity
    {
        private ProgramLink()
        {

        }

        public ProgramLink(ProgramLinkDTO dto)
        {
            SortOrder = dto.SortOrder;
            Title_Ja = dto.Title.Ja;
            Title_En = dto.Title.En;
            Title_Zh_Tw = dto.Title.ZhTw;
            Title_Zh_Cn = dto.Title.ZhCn;
            Url = dto.Url;
        }

        public Program Program { get; private set; }
        public int SortOrder { get; private set; }
        public string Title_Ja { private set; get; }
        public string Title_En { private set; get; }
        public string Title_Zh_Tw { private set; get; }
        public string Title_Zh_Cn { private set; get; }
        public string Url { private set; get; }
    }
}
