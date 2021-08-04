using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class CreateProgramPresenterCommandHandler : IRequestHandler<CreateProgramPresenterCommand, string>
    {
        private readonly IProgramRepository _repository;

        public CreateProgramPresenterCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateProgramPresenterCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.GetAllForUpdate()
                                           .Include(x => x.ProgramPresenters)
                                           .ThenInclude(x => x.ProgramPresenterLinks)
                                           .SingleOrDefaultAsync(x => x.ProgramGuid == request.ProgramPresenterDTO.ProgramGuid, cancellationToken: cancellationToken);

            if (program == null) { throw new Exception("指定されたプログラムIDはありません"); }
            var programPresenter = new ProgramPresenter(request.ProgramPresenterDTO);
            program.AddProgramPresenter(programPresenter);
            _repository.Update(program);
            await _repository.SaveChangesAsync();
            return programPresenter.ProgramPresenterGuid;
        }
    }
}
