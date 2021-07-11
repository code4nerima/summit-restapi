using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramPresenterCommandHandler : IRequestHandler<UpdateProgramPresenterCommand, int>
    {
        private readonly IProgramRepository _repository;

        public UpdateProgramPresenterCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateProgramPresenterCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.GetAllForUpdate()
                                           .Include(x => x.ProgramPresenters.Where(x => x.ProgramPresenterGuid == request.ProgramPresenterDTO.ProgramPresenterGuid))
                                           .SingleOrDefaultAsync(x => x.ProgramGuid == request.ProgramPresenterDTO.ProgramGuid, cancellationToken: cancellationToken);
            if (program == null) { throw new Exception("プログラムが登録されていません"); }
            var programPresenter = program.ProgramPresenters.SingleOrDefault();
            if (programPresenter == null) { throw new Exception("登壇者が登録されていません"); }
            programPresenter.Update(request.ProgramPresenterDTO);
            _repository.Update(program);
            return await _repository.SaveChangesAsync();
        }
    }
}
