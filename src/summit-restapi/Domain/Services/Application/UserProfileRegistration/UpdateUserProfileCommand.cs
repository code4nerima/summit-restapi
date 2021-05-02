using CfjSummit.Domain.Models.DTOs.UserProfiles;
using MediatR;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{

    public class UpdateUserProfileCommand : IRequest<int>
    {
        public UserProfileDTO UserProfileDTO { get; init; }

        public UpdateUserProfileCommand(UserProfileDTO dto)
        {
            UserProfileDTO = dto;
        }
    }
}
