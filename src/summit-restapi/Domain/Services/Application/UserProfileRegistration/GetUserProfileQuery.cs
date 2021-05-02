using CfjSummit.Domain.Models.DTOs.UserProfiles;
using MediatR;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{

    public class GetUserProfileQuery : IRequest<GetUserProfileDTO>
    {
        public string Uid { get; init; }
        public GetUserProfileQuery(string uid)
        {
            Uid = uid;

        }

    }
}
