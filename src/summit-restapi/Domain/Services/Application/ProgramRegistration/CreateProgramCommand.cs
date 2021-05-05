using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class CreateProgramCommand : IRequest<string>
    {
        public ProgramPartsDataDTO ProgramPartsDataDTO { get; init; }
        public CreateProgramCommand(ProgramPartsDataDTO dto)
        {
            ProgramPartsDataDTO = dto;
        }
    }
}
