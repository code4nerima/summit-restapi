﻿using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramOwnersCommandHandler : IRequestHandler<UpdateProgramOwnersCommand, int>
    {
        private readonly IProgramRepository _repository;
        private readonly IQueryableRepository<UserProfile> _userProfileRepository;

        public UpdateProgramOwnersCommandHandler(IProgramRepository repository, IQueryableRepository<UserProfile> userProfileRepository)
        {
            _repository = repository;
            _userProfileRepository = userProfileRepository;
        }
        public async Task<int> Handle(UpdateProgramOwnersCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.GetProgramWithOwnersAsync(request.UpdateProgramOwnersRequestDTO.ProgramId);
            program.RemoveAllProgramOwner();
            var userProfiles = _userProfileRepository.GetAll()
                .Where(x => request.UpdateProgramOwnersRequestDTO.OwnerUids.Contains(x.Uid))
                .ToList();
            program.AddRangeProgramOwners(userProfiles);
            _repository.Update(program);
            return await _repository.SaveChangesAsync();
        }
    }
}
