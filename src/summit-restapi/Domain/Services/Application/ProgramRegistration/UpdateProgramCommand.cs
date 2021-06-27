using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramCommand : IRequest<int>
    {
        public ProgramPartsDataDTO ProgramPartsDataDTO { get; set; }
        public UpdateProgramCommand(ProgramPartsDataDTO dto)
        {
            ProgramPartsDataDTO = dto;
        }

    }
}
