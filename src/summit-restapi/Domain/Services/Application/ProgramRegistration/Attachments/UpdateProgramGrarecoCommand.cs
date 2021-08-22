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
    public class UpdateProgramGrarecoCommand : IRequest<int>
    {
        public UpdateProgramGrarecoCommand(ProgramGrarecoDTO dto)
        {
            ProgramGrarecoDTO = dto;
        }

        public ProgramGrarecoDTO ProgramGrarecoDTO { get; }
    }
    internal class UpdateProgramGrarecoCommandHandler : IRequestHandler<UpdateProgramGrarecoCommand, int>
    {
        private readonly IProgramRepository _repository;

        public UpdateProgramGrarecoCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateProgramGrarecoCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.GetAllForUpdate()
                                           .Include(x => x.ProgramGrarecos.Where(x => x.ProgramGrarecoGuid == request.ProgramGrarecoDTO.ProgramGrarecoGuid))
                                           .SingleOrDefaultAsync(x => x.ProgramGuid == request.ProgramGrarecoDTO.ProgramGuid, cancellationToken: cancellationToken);
            if (program == null) { throw new Exception("プログラムが登録されていません"); }
            var programGrareco = program.ProgramGrarecos.SingleOrDefault();
            if (programGrareco == null) { throw new Exception("グラレコが登録されていません"); }
            programGrareco.Update(request.ProgramGrarecoDTO);
            _repository.Update(program);
            return await _repository.SaveChangesAsync();
        }
    }

}
