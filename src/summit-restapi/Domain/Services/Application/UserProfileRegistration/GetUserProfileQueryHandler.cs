using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.UserProfiles;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, GetUserProfileDTO>
    {
        private readonly IUserProfileRepository _repository;

        public GetUserProfileQueryHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUserProfileDTO> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll()
                .Where(x => x.Uid == request.Uid)
                .Select(x => new GetUserProfileDTO()
                {
                    Uid = x.Uid,
                    Role = x.Role,
                    UserName = new MultilingualValue()
                    {
                        Ja = x.Name_Ja,
                        Ja_Kana = x.Name_Ja_Kana,
                        En = x.Name_En,
                        ZhTw = x.Name_Zh_Tw,
                        ZhCn = x.Name_Zh_Cn
                    }
                })
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
