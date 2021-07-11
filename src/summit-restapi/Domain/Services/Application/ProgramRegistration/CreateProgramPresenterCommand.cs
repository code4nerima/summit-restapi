using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class CreateProgramPresenterCommand : IRequest<string>
    {
        public ProgramPresenterDTO ProgramPresenterDTO { get; }
        public CreateProgramPresenterCommand(ProgramPresenterDTO dto)
        {
            ProgramPresenterDTO = dto;
        }

    }
}
