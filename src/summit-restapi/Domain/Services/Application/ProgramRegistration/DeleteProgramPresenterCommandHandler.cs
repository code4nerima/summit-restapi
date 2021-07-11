using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class DeleteProgramPresenterCommandHandler : IRequestHandler<DeleteProgramPresenterCommand, int>
    {
        private readonly IProgramRepository _repository;

        public DeleteProgramPresenterCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteProgramPresenterCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.GetAllForUpdate()
                                           .Include(x => x.ProgramPresenters.Where(x => x.ProgramPresenterGuid == request.ProgramPresenterKeyDataDTO.ProgramPresenterGuid))
                                           .SingleOrDefaultAsync(x => x.ProgramGuid == request.ProgramPresenterKeyDataDTO.ProgramGuid, cancellationToken: cancellationToken);
            if (program == null) { throw new Exception("プログラムが登録されていません"); }
            var programPresenter = program.ProgramPresenters.SingleOrDefault();
            if (programPresenter == null) { throw new Exception("登壇者が登録されていません"); }
            program.RemoveProgramPresenter(programPresenter);
            _repository.Update(program);
            return await _repository.SaveChangesAsync();
        }
    }
}
