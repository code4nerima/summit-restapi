﻿using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.DTOs.UserProfiles;
using CfjSummit.Domain.Models.Enums;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramQueryHandler : IRequestHandler<GetProgramQuery, ProgramDTO>
    {
        private readonly IProgramRepository _repository;

        public GetProgramQueryHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProgramDTO> Handle(GetProgramQuery request, CancellationToken cancellationToken)
        {
            var p = await _repository
                .GetAll()
                .Include(x => x.ProgramOwners)
                .ThenInclude(x => x.UserProfile)
                .SingleOrDefaultAsync(x => x.ProgramId == request.ProgramId, cancellationToken: cancellationToken);
            if (p == null) { return new ProgramDTO(); }

            var dto = new ProgramDTO()
            {
                Title = new ProgramTitleDTO()
                {
                    Ja = p.Title_Ja,
                    En = p.Title_En,
                    ZhTw = p.Title_Zh_Tw,
                    ZhCn = p.Title_Zh_Cn
                },
                Category = (ProgramCategory)p.ProgramCategory,
                Date = p.Date,
                StartTime = p.StartTime,
                EndTime = p.EndTime,
                TrackId = p.TrackId,
                ProgramOwners = p.ProgramOwners.Select(x => new ProgramOwnerDTO()
                {
                    Uid = x.UserProfile.Uid,
                    UserName = new UserNameDTO()
                    {
                        Ja = x.UserProfile.Name_Ja,
                        Ja_Kana = x.UserProfile.Name_Ja_Kana,
                        En = x.UserProfile.Name_En,
                        ZhTw = x.UserProfile.Name_Zh_Tw,
                        ZhCn = x.UserProfile.Name_Zh_Cn
                    }
                }).ToList(),
                Description = new ProgramDescriptionDTO()
                {
                    Ja = p.Description_Ja,
                    En = p.Description_En,
                    ZhTw = p.Description_Zh_Tw,
                    ZhCn = p.Description_Zh_Cn
                },

            };
            //TODO
            //dto.AddProgramMember
            //dto.AddProgramOwner
            return dto;
        }
    }
}
