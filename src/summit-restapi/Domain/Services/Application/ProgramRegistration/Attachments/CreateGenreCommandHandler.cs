using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, string>
    {
        private readonly IGenreRepository _repository;

        public CreateGenreCommandHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var newProgramGenre = new Genre(request.GenreDTO);
            _repository.Add(newProgramGenre);
            await _repository.SaveChangesAsync();
            return newProgramGenre.GenreGuid;
        }
    }
}
