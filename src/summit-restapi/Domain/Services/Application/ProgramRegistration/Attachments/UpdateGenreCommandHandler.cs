using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, int>
    {
        private readonly IGenreRepository _repository;

        public UpdateGenreCommandHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _repository
                        .GetAllForUpdate()
                        .SingleOrDefaultAsync(x => x.GenreGuid == request.GenreDTO.GenreGuid, cancellationToken: cancellationToken);
            if (genre == null) { throw new Exception(); }

            genre.Update(request.GenreDTO);
            _repository.Update(genre);
            return await _repository.SaveChangesAsync();
        }
    }
}
