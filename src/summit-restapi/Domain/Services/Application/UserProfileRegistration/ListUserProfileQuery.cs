using CfjSummit.Domain.Models.DTOs.UserProfiles;
using MediatR;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{
    public class ListUserProfileQuery : IRequest<ListUserProfileResponseDTO>
    {
        public ListUserProfileRequestDTO ListUserProfileRequestDTO { set; get; }
        public ListUserProfileQuery(ListUserProfileRequestDTO dto)
        {
            ListUserProfileRequestDTO = dto;
        }
    }
}
