using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramOwnersQuery : IRequest<GetProgramOwnersResponseDTO>
    {
        public ProgramKeyDataDTO ProgramIdDTO { get; set; }
        public GetProgramOwnersQuery(ProgramKeyDataDTO dto)
        {
            ProgramIdDTO = dto;
        }
    }
}
