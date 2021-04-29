using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class CreateProgramCommand : IRequest<string>
    {
        public string Uid { get; init; }
        public RegisterProgramRequestDTO RegisterProgramRequestDTO { get; init; }
        public CreateProgramCommand(string uid, RegisterProgramRequestDTO dto)
        {
            Uid = uid;
            RegisterProgramRequestDTO = dto;
        }
    }
}
