using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class DeleteProgramPresenterCommand : IRequest<int>
    {
        public DeleteProgramPresenterCommand(ProgramPresenterKeyDataDTO dto)
        {
            ProgramPresenterKeyDataDTO = dto;
        }

        public ProgramPresenterKeyDataDTO ProgramPresenterKeyDataDTO { get; }
    }
}
