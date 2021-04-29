using CfjSummit.Domain.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, int>
    {
        private readonly IUserProfileRepository _repository;

        public UpdateUserProfileCommandHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = _repository.GetAll().SingleOrDefault(x => x.Uid == request.Uid);
            if (userProfile == null) { throw new Exception(); }

            userProfile.Update(request.UserProfileDTO);
            _repository.Update(userProfile);
            return await _repository.SaveChangesAsync();

        }
    }
}
