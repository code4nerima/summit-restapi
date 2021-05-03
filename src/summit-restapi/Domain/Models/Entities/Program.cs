using CfjSummit.Domain.Models.DTOs.Programs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CfjSummit.Domain.Models.Entities
{
    public class Program : Entity
    {
        private Program()
        {

        }
        public Program(RegisterProgramRequestDTO dto)
        {
            ProgramId = Guid.NewGuid().ToString();
            Title_Ja = dto.Title.Ja;
            Title_En = dto.Title.En;
            Title_Zh_Tw = dto.Title.ZhTw;
            Title_Zh_Cn = dto.Title.ZhCn;
            ProgramCategory = (int)dto.Category;
            Date = dto.Date;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
            TrackId = dto.TrackId;
        }

        public string ProgramId { get; init; }
        public string Title_Ja { private set; get; }
        public string Title_En { private set; get; }
        public string Title_Zh_Tw { private set; get; }
        public string Title_Zh_Cn { private set; get; }
        [Required]
        public int ProgramCategory { private set; get; }
        public string Description_Ja { private set; get; }
        public string Description_En { private set; get; }
        public string Description_Zh_Tw { private set; get; }
        public string Description_Zh_Cn { private set; get; }
        [Required]
        public DateTime Date { private set; get; }
        public string StartTime { private set; get; }
        public string EndTime { private set; get; }
        public string TrackId { private set; get; }

        public void Update(EditProgramRequestDTO dto)
        {
            Title_Ja = dto.Title.Ja;
            Title_En = dto.Title.En;
            Title_Zh_Tw = dto.Title.ZhTw;
            Title_Zh_Cn = dto.Title.ZhCn;
            ProgramCategory = (int)dto.Category;
            Date = dto.Date;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
            TrackId = dto.TrackId;
            Description_Ja = dto.Description.Ja;
            Description_En = dto.Description.En;
            Description_Zh_Tw = dto.Description.ZhTw;
            Description_Zh_Cn = dto.Description.ZhCn;

        }

        private readonly List<ProgramOwner> _programOwners = new();
        public IReadOnlyCollection<ProgramOwner> ProgramOwners => _programOwners;
        public void UpdateProgramOwner(IEnumerable<string> uidList)
        {
            _programOwners.Clear();
            _programOwners.AddRange(uidList.Select(uid => new ProgramOwner(uid)));
        }
    }
}
