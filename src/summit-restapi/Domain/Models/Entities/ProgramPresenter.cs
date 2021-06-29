using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;

namespace CfjSummit.Domain.Models.Entities
{
    public class ProgramPresenter : Entity
    {
        public ProgramPresenter(long programId, ProgramPresenterDTO dto)
        {
            ProgramId = programId;

            Name_Ja = dto.UserName?.Ja;
            Name_En = dto.UserName?.En;
            Name_Zh_Tw = dto.UserName?.ZhTw;
            Name_Zh_Cn = dto.UserName?.ZhCn;

            Description_Ja = dto.Description?.Ja;
            Description_En = dto.Description?.En;
            Description_Zh_Tw = dto.Description?.ZhTw;
            Description_Zh_Cn = dto.Description?.ZhCn;

            PhotoURL = dto.PhotoURL;
        }

        public Program Program { get; private set; }
        public long ProgramId { get; private set; }
        public virtual string Name_Ja { get; private set; }
        public virtual string Name_En { get; private set; }
        public virtual string Name_Zh_Tw { get; private set; }
        public virtual string Name_Zh_Cn { get; private set; }

        public virtual string Description_Ja { get; private set; }
        public virtual string Description_En { get; private set; }
        public virtual string Description_Zh_Tw { get; private set; }
        public virtual string Description_Zh_Cn { get; private set; }

        public virtual string PhotoURL { get; private set; }

    }
}
