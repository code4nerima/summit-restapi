using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.UserProfileRegistration
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, int>
    {
        private readonly IUserProfileRepository _repository;

        public CreateUserProfileCommandHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var p = new UserProfile(request.Uid, request.UserProfileDTO);
            _repository.Add(p);
            return await _repository.SaveChangesAsync();
        }
    }
}
