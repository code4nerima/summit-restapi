using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramOwnersQuery : IRequest<GetProgramOwnersResponseDTO>
    {
        public ProgramIdDTO ProgramIdDTO { get; set; }
        public GetProgramOwnersQuery(ProgramIdDTO dto)
        {
            ProgramIdDTO = dto;
        }
    }
}
