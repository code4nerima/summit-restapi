using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class CreateProgramGrarecoCommand : IRequest<string>
    {
        public ProgramGrarecoDTO ProgramGrarecoDTO { get; }
        public CreateProgramGrarecoCommand(ProgramGrarecoDTO dto)
        {
            ProgramGrarecoDTO = dto;
        }

    }
    internal class CreateProgramGrarecoCommandHandler : IRequestHandler<CreateProgramGrarecoCommand, string>
    {
        private readonly IProgramRepository _repository;

        public CreateProgramGrarecoCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateProgramGrarecoCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.GetAllForUpdate()
                                           .SingleOrDefaultAsync(x => x.ProgramGuid == request.ProgramGrarecoDTO.ProgramGuid, cancellationToken: cancellationToken);

            if (program == null) { throw new Exception("指定されたプログラムIDはありません"); }
            var programGrareco = new ProgramGrareco(request.ProgramGrarecoDTO);
            program.AddProgramGrareco(programGrareco);
            _repository.Update(program);
            await _repository.SaveChangesAsync();
            return programGrareco.ProgramGrarecoGuid;

        }
    }
}
