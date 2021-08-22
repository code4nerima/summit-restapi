using CfjSummit.Domain.Models.DTOs.Programs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CfjSummit.Domain.Models.Entities
{
    public class Program : Entity
    {
        public enum ProgramRoleEnum
        {
            Owner = 1,
            Member = 2,
        }

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

        public void RemoveChildItems()
        {
            _programGenres.Clear();
            _programLinks.Clear();
            _programPresenters.ForEach(x => x.ClearProgramPresenterLinks());
            _programGrarecos.Clear();
            _programUserProfiles.Clear();
            _programGrarecos.Clear();
        }

        public string Description_Zh_Cn { private set; get; }
        [Required]
        public string Date { private set; get; }
        public string StartTime { private set; get; }

        public void ClearProgramOwner()
        {
            _programUserProfiles.RemoveAll(x => x.ProgramRole == (int)ProgramRoleEnum.Owner);
        }

        public void RemoveProgramPresenter(ProgramPresenter programPresenter)
        {
            _programPresenters.Remove(programPresenter);
        }

        public void ClearProgramMember()
        {
            _programUserProfiles.RemoveAll(x => x.ProgramRole == (int)ProgramRoleEnum.Member);
        }

        internal void RemoveProgramGrareco(ProgramGrareco programGrareco)
        {
            _programGrarecos.Remove(programGrareco);
        }

        public string EndTime { private set; get; }
        public string Email { private set; get; }
        public string InputCompleted { private set; get; } = "0";
        public virtual string BroadcastingURL { get; private set; }


        public void AddRangeProgramOwners(IReadOnlyList<long> userProfileIds)
        {
            var items = userProfileIds.Select(userProfileId => new ProgramUserProfile((int)ProgramRoleEnum.Owner, Id, userProfileId));
            _programUserProfiles.AddRange(items);
        }

        public void AddRangeProgramMembers(IReadOnlyList<long> userProfileIds)
        {
            var items = userProfileIds.Select(userProfileId => new ProgramUserProfile((int)ProgramRoleEnum.Member, Id, userProfileId));
            _programUserProfiles.AddRange(items);
        }

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
            InputCompleted = dto.InputCompleted;
            BroadcastingURL = dto.BroadcastingURL;
            _programLinks.Clear();
            _programLinks.AddRange(dto.ProgramLinks.Select(pl => new ProgramLink(pl)));
        }

        private readonly List<ProgramUserProfile> _programUserProfiles = new();
        public IReadOnlyCollection<ProgramUserProfile> ProgramUserProfiles => _programUserProfiles;

        [NotMapped]
        public IReadOnlyCollection<ProgramUserProfile> ProgramOwnerUserProfiles => _programUserProfiles.Where(x => x.ProgramRole == (int)ProgramRoleEnum.Owner).ToList();
        [NotMapped]
        public IReadOnlyCollection<ProgramUserProfile> ProgramMemberUserProfiles => _programUserProfiles.Where(x => x.ProgramRole == (int)ProgramRoleEnum.Member).ToList();

        public void SetTrackId(long trackId) => TrackId = trackId;

        public long? TrackId { private set; get; }
        public Track Track { private set; get; }

        private readonly List<ProgramGenre> _programGenres = new();
        public IReadOnlyCollection<ProgramGenre> ProgramGenres => _programGenres;

        public void ClearProgramGenres() => _programGenres.Clear();
        public void AddRangeProgramGenres(IReadOnlyList<long> genreIds)
        {
            var items = genreIds.Select(genreId => new ProgramGenre(Id, genreId));
            _programGenres.AddRange(items);
        }

        private readonly List<ProgramPresenter> _programPresenters = new();
        public IReadOnlyCollection<ProgramPresenter> ProgramPresenters => _programPresenters;
        public void AddProgramPresenter(ProgramPresenter presenter) => _programPresenters.Add(presenter);


        private readonly List<ProgramLink> _programLinks = new();
        public IReadOnlyCollection<ProgramLink> ProgramLinks => _programLinks;
        public void AddRangeProgramLinks(IReadOnlyList<ProgramLink> programLinks) => _programLinks.AddRange(programLinks);
        public void ClearProgramLinks() => _programLinks.Clear();

        private readonly List<ProgramGrareco> _programGrarecos = new();
        public IReadOnlyCollection<ProgramGrareco> ProgramGrarecos => _programGrarecos;
        public void AddProgramGrareco(ProgramGrareco programGrareco) => _programGrarecos.Add(programGrareco);

    }
}
