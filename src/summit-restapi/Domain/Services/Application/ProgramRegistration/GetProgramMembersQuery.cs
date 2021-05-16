using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramMembersQuery : IRequest<GetProgramMembersResponseDTO>
    {
        public ProgramKeyDataDTO ProgramKeyDataDTO { get; set; }
        public GetProgramMembersQuery(ProgramKeyDataDTO dto)
        {
            ProgramKeyDataDTO = dto;
        }
    }
}
