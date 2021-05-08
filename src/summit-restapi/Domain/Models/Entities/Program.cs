using CfjSummit.Domain.Models.DTOs.Programs;
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
        public Program(ProgramPartsDataDTO dto)
        {
            ProgramGuid = GetNewGuid();
            Edit(dto);
        }

        public string ProgramGuid { get; init; }
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
        public string Date { private set; get; }
        public string StartTime { private set; get; }
        public string EndTime { private set; get; }
        public string Email { private set; get; }

        public void Update(ProgramPartsDataDTO dto)
        {
            Edit(dto);
        }

        private void Edit(ProgramPartsDataDTO dto)
        {
            Title_Ja = dto.Title.Ja;
            Title_En = dto.Title.En;
            Title_Zh_Tw = dto.Title.ZhTw;
            Title_Zh_Cn = dto.Title.ZhCn;
            ProgramCategory = (int)dto.Category;
            Date = dto.Date;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
            Description_Ja = dto.Description.Ja;
            Description_En = dto.Description.En;
            Description_Zh_Tw = dto.Description.ZhTw;
            Description_Zh_Cn = dto.Description.ZhCn;
            Email = dto.Email;
        }


        private readonly List<ProgramOwner> _programOwners = new();
        public IReadOnlyCollection<ProgramOwner> ProgramOwners => _programOwners;

        public void ClearProgramOwner() => _programOwners.Clear();
        public void AddRangeProgramOwners(IEnumerable<UserProfile> userProfiles) => _programOwners.AddRange(userProfiles.Select(u => new ProgramOwner(u)));
        public void SetTrackId(long trackId) => TrackId = trackId;

        public long? TrackId { private set; get; }
        public Track Track { private set; get; }


    }
}
