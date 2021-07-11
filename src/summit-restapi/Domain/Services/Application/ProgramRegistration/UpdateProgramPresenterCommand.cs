using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramPresenterCommand : IRequest<int>
    {
        public UpdateProgramPresenterCommand(ProgramPresenterDTO dto)
        {
            ProgramPresenterDTO = dto;
        }

        public ProgramPresenterDTO ProgramPresenterDTO { get; }
    }
}
