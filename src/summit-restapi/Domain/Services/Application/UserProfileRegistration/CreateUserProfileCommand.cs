using CfjSummit.Domain.Models.DTOs.UserProfiles;
using MediatR;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{
    public class CreateUserProfileCommand : IRequest<int>
    {
        public UserProfileDTO UserProfileDTO { get; init; }

        public CreateUserProfileCommand(UserProfileDTO dto)
        {
            UserProfileDTO = dto;
        }
    }
}
