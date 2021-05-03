using CfjSummit.Domain.Models.DTOs.UserProfiles;
using MediatR;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{
    public class ListProgramQuery : IRequest<ListUserProfileResponseDTO>
    {
        public ListUserProfileRequestDTO ListUserProfileRequestDTO { set; get; }
        public ListProgramQuery(ListUserProfileRequestDTO dto)
        {
            ListUserProfileRequestDTO = dto;
        }
    }
}
