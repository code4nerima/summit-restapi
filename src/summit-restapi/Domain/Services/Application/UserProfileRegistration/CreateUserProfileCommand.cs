using CfjSummit.Domain.Models.DTOs.UserProfiles;
using MediatR;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{
    public class CreateUserProfileCommand : IRequest<int>
    {
        public string Uid { get; init; }
        public UserProfileDTO UserProfileDTO { get; init; }

        public CreateUserProfileCommand(string uid, UserProfileDTO dto)
        {
            Uid = uid;
            UserProfileDTO = dto;
        }
    }
}
