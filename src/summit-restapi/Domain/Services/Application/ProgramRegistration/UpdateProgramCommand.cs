using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramCommand : IRequest<string>
    {
        public EditProgramRequestDTO EditProgramRequestDTO { get; set; }
        public UpdateProgramCommand(EditProgramRequestDTO dto)
        {
            EditProgramRequestDTO = dto;
        }

    }
}
