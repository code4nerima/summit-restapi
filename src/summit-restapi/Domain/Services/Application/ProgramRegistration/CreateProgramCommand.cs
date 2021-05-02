using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class CreateProgramCommand : IRequest<string>
    {
        public RegisterProgramRequestDTO RegisterProgramRequestDTO { get; init; }
        public CreateProgramCommand(RegisterProgramRequestDTO dto)
        {
            RegisterProgramRequestDTO = dto;
        }
    }
}
