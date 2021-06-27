using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using System.Collections.Generic;

namespace CfjSummit.Domain.Models.Entities
{
    public class Genre : Entity
    {
        private Genre()
        {

        }

        public Genre(GenreDTO dto)
        {
            GenreGuid = NewGuid;
            Edit(dto);

        }

        public void Update(GenreDTO dto)
        {
            Edit(dto);
        }

        private void Edit(GenreDTO dto)
        {
            Name_Ja = dto.Name.Ja;
            Name_En = dto.Name.En;
            Name_Zh_Tw = dto.Name.ZhTw;
            Name_Zh_Cn = dto.Name.ZhCn;
        }

        public virtual string GenreGuid { set; get; }
        public virtual string Name_Ja { get; private set; }
        public virtual string Name_En { get; private set; }
        public virtual string Name_Zh_Tw { get; private set; }
        public virtual string Name_Zh_Cn { get; private set; }

        private readonly List<ProgramGenre> _programGenres = new();
        public IReadOnlyCollection<ProgramGenre> ProgramGenres => _programGenres;

    }
}
