using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramOwnersCommand : IRequest<int>
    {
        public UpdateProgramOwnersRequestDTO UpdateProgramOwnersRequestDTO { set; get; }
        public UpdateProgramOwnersCommand(UpdateProgramOwnersRequestDTO dto)
        {
            UpdateProgramOwnersRequestDTO = dto;
        }
    }
}
