using CfjSummit.Domain.Models.DTOs.UserProfiles;
using CfjSummit.Domain.Models.Enums;

namespace CfjSummit.Domain.Services.Application
{
    public class CreateUserProfileCommand
    {
        public string Uid { get; set; }
        public UserNameDTO UserName { get; set; }
        public UserRole UserRole { get; set; }

        public CreateUserProfileCommand(string uid, UserNameDTO userNameDTO, UserRole userRole)
        {

            Uid = uid;
            UserName = userNameDTO;
            UserRole = userRole;
        }
        public int Execute()
        {
            return 1;
        }
    }
}
