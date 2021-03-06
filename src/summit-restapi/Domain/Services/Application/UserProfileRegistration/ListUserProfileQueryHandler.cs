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
    public class ListUserProfileQueryHandler : IRequestHandler<ListProgramQuery, ListUserProfileResponseDTO>
    {
        private readonly IUserProfileRepository _repository;

        public ListUserProfileQueryHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListUserProfileResponseDTO> Handle(ListProgramQuery request, CancellationToken cancellationToken)
        {
            var takeCount = request.ListUserProfileRequestDTO.Limit;
            if (takeCount <= 0) { takeCount = int.MaxValue; }
            var query = await _repository.GetAll()
                .Where(x => request.ListUserProfileRequestDTO.Roles.Contains(x.Role))
                .OrderBy(x => x.Name_Ja_Kana)
                .Skip(request.ListUserProfileRequestDTO.Start)
                .Take(takeCount)
                .ToListAsync(cancellationToken: cancellationToken);

            return new ListUserProfileResponseDTO()
            {
                TotalCount = query.Count,
                UserProfiles = query.Select(x => new UserProfileDTO()
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
                    },
                    PhotoURL = x.PhotoURL
                })
                .ToList()
            };

        }
    }
}
