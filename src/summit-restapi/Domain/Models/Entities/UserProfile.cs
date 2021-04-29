using CfjSummit.Domain.Models.DTOs.UserProfiles;
using System.ComponentModel.DataAnnotations;


namespace CfjSummit.Domain.Models.Entities
{
    public class UserProfile : Entity
    {
        private UserProfile()
        {

        }
        public UserProfile(string uid, UserProfileDTO dto)
        {
            Uid = uid;
            Name_Ja = dto.UserName?.Ja;
            Name_En = dto.UserName?.En;
            Name_Zh_Tw = dto.UserName?.ZhTw;
            Name_Zh_Cn = dto.UserName?.ZhCn;
            Role = (int)dto.UserRole;
        }

        [Required]
        public virtual string Uid { get; private set; }
        [Required]
        public virtual string Name_Ja { get; private set; }
        public virtual string Name_En { get; private set; }
        public virtual string Name_Zh_Tw { get; private set; }
        public virtual string Name_Zh_Cn { get; private set; }
        [Required]
        public virtual int Role { get; private set; }

        public void Update(UserProfileDTO dto)
        {
            Name_Ja = dto.UserName.Ja ?? Name_Ja;
            Name_En = dto.UserName.En ?? Name_En;
            Name_Zh_Tw = dto.UserName.ZhTw ?? Name_Zh_Tw;
            Name_Zh_Cn = dto.UserName.ZhCn ?? Name_Zh_Cn;
            Role = (int)dto.UserRole;
        }
    }
}
