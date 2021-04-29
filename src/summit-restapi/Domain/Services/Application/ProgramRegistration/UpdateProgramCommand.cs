using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramCommand : IRequest<string>
    {
        public string Uid { get; set; }
        public EditProgramRequestDTO EditProgramRequestDTO { get; set; }
        public UpdateProgramCommand(string uid, EditProgramRequestDTO dto)
        {
            Uid = uid;
            EditProgramRequestDTO = dto;
        }

    }
}
