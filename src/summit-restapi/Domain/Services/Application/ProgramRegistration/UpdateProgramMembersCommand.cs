using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramMembersCommand : IRequest<int>
    {
        public UpdateProgramMembersRequestDTO UpdateProgramMembersRequestDTO { set; get; }
        public UpdateProgramMembersCommand(UpdateProgramMembersRequestDTO dto)
        {
            UpdateProgramMembersRequestDTO = dto;
        }

    }
}
