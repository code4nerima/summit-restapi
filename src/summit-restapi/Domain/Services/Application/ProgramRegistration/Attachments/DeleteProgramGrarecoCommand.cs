using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class DeleteProgramGrarecoCommand : IRequest<int>
    {
        public DeleteProgramGrarecoCommand(ProgramGrarecoKeyDataDTO dto)
        {
            ProgramGrarecoKeyDataDTO = dto;
        }

        public ProgramGrarecoKeyDataDTO ProgramGrarecoKeyDataDTO { get; }
    }
    internal class DeleteProgramGrarecoCommandHandler : IRequestHandler<DeleteProgramGrarecoCommand, int>
    {
        private readonly IProgramRepository _repository;

        public DeleteProgramGrarecoCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteProgramGrarecoCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.GetAllForUpdate()
                                           .Include(x => x.ProgramGrarecos.Where(x => x.ProgramGrarecoGuid == request.ProgramGrarecoKeyDataDTO.ProgramGrarecoGuid))
                                           .SingleOrDefaultAsync(x => x.ProgramGuid == request.ProgramGrarecoKeyDataDTO.ProgramGuid, cancellationToken: cancellationToken);
            if (program == null) { throw new Exception("プログラムが登録されていません"); }
            var programGrareco = program.ProgramGrarecos.SingleOrDefault();
            if (programGrareco == null) { throw new Exception("グラレコが登録されていません"); }
            program.RemoveProgramGrareco(programGrareco);
            _repository.Update(program);
            return await _repository.SaveChangesAsync();
        }
    }

}
