using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using System.Collections.Generic;
using System.Linq;

namespace CfjSummit.Domain.Models.Entities
{
    public class ProgramPresenter : Entity
    {
        private ProgramPresenter()
        {

        }
        public ProgramPresenter(ProgramPresenterDTO dto)
        {
            ProgramPresenterGuid = GetNewGuid();
            Edit(dto);
        }

        public Program Program { get; private set; }

        public virtual string ProgramPresenterGuid { get; private set; }

        public virtual string Name_Ja { get; private set; }
        public virtual string Name_Ja_Kana { get; private set; }
        public virtual string Name_En { get; private set; }
        public virtual string Name_Zh_Tw { get; private set; }
        public virtual string Name_Zh_Cn { get; private set; }

        public virtual string Organization_Ja { get; private set; }
        public virtual string Organization_En { get; private set; }
        public virtual string Organization_Zh_Tw { get; private set; }
        public virtual string Organization_Zh_Cn { get; private set; }

        public virtual string Description_Ja { get; private set; }
        public virtual string Description_En { get; private set; }
        public virtual string Description_Zh_Tw { get; private set; }
        public virtual string Description_Zh_Cn { get; private set; }

        public virtual string PhotoURL { get; private set; }

        public virtual int SortOrder { get; private set; }

        private readonly List<ProgramPresenterLink> _programPresenterLinks = new();
        public IReadOnlyCollection<ProgramPresenterLink> ProgramPresenterLinks => _programPresenterLinks;
        public void AddRangeProgramPresenterLinks(IReadOnlyList<ProgramPresenterLink> programPresenterLinks) => _programPresenterLinks.AddRange(programPresenterLinks);
        public void ClearProgramPresenterLinks() => _programPresenterLinks.Clear();


        public void Update(ProgramPresenterDTO dto)
        {
            Edit(dto);
        }


        private void Edit(ProgramPresenterDTO dto)
        {
            Name_Ja = dto.Name?.Ja;
            Name_Ja_Kana = dto.Name.Ja_Kana;
            Name_En = dto.Name?.En;
            Name_Zh_Tw = dto.Name?.ZhTw;
            Name_Zh_Cn = dto.Name?.ZhCn;

            Organization_Ja = dto.Organization?.Ja;
            Organization_En = dto.Organization?.En;
            Organization_Zh_Tw = dto.Organization?.ZhTw;
            Organization_Zh_Cn = dto.Organization?.ZhCn;

            Description_Ja = dto.Description?.Ja;
            Description_En = dto.Description?.En;
            Description_Zh_Tw = dto.Description?.ZhTw;
            Description_Zh_Cn = dto.Description?.ZhCn;

            PhotoURL = dto.PhotoURL;

            SortOrder = dto.SortOrder;

            ClearProgramPresenterLinks();
            AddRangeProgramPresenterLinks(dto.ProgramPresenterLinks.Select(x => new ProgramPresenterLink(x)).ToList());
        }

    }
}
