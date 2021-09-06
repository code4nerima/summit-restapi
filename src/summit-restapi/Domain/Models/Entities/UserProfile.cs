using CfjSummit.Domain.Models.DTOs.UserProfiles;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CfjSummit.Domain.Models.Entities
{
    [Index(nameof(Uid), IsUnique = true)]
    public class UserProfile : Entity
    {
        private UserProfile()
        {

        }
        public UserProfile(UserProfileDTO dto)
        {
            Uid = dto.Uid;
            Name_Ja = dto.UserName?.Ja;
            Name_Ja_Kana = dto.UserName?.Ja_Kana;
            Name_En = dto.UserName?.En;
            Name_Zh_Tw = dto.UserName?.ZhTw;
            Name_Zh_Cn = dto.UserName?.ZhCn;
            Role = dto.Role;
        }

        [Required]
        public virtual string Uid { get; private set; }
        [Required]
        public virtual string Name_Ja { get; private set; }
        public virtual string Name_Ja_Kana { get; private set; }
        public virtual string Name_En { get; private set; }
        public virtual string Name_Zh_Tw { get; private set; }
        public virtual string Name_Zh_Cn { get; private set; }
        [Required]
        public virtual int Role { get; private set; }

        public void Update(UserProfileDTO dto)
        {
            Name_Ja = dto.UserName.Ja ?? Name_Ja;
            Name_Ja_Kana = dto.UserName?.Ja_Kana;
            Name_En = dto.UserName.En ?? Name_En;
            Name_Zh_Tw = dto.UserName.ZhTw ?? Name_Zh_Tw;
            Name_Zh_Cn = dto.UserName.ZhCn ?? Name_Zh_Cn;
            Role = dto.Role;
            PhotoURL = dto.PhotoURL;
        }

        private readonly List<ProgramUserProfile> _programUserProfiles = new();
        public IReadOnlyCollection<ProgramUserProfile> ProgramUserProfiles => _programUserProfiles;

        public virtual string PhotoURL { get; private set; }
    }
}
