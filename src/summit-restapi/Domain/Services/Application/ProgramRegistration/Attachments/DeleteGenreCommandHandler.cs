using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, int>
    {
        private readonly IGenreRepository _repository;

        public DeleteGenreCommandHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _repository.GetAll()
                                         .Include(x => x.ProgramGenres)
                                         .SingleOrDefaultAsync(x => x.GenreGuid == request.GenreGuid, cancellationToken: cancellationToken);
            if (genre.ProgramGenres.Any()) { return -1; }
            _repository.Remove(genre);
            return await _repository.SaveChangesAsync();
        }
    }
}
