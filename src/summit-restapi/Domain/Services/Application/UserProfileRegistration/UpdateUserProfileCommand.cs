using CfjSummit.Domain.Models.DTOs.UserProfiles;
using MediatR;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{

    public class UpdateUserProfileCommand : IRequest<int>
    {
        public string Uid { get; init; }
        public UserProfileDTO UserProfileDTO { get; init; }

        public UpdateUserProfileCommand(string uid, UserProfileDTO dto)
        {
            Uid = uid;
            UserProfileDTO = dto;
        }
    }
}
