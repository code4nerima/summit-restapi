using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class ListRelatedProgramQuery : IRequest<ListRelatedProgramResponseDTO>
    {
        public ListRelatedProgramRequestDTO ListRelatedProgramRequestDTO { set; get; }
        public ListRelatedProgramQuery(ListRelatedProgramRequestDTO dto)
        {
            ListRelatedProgramRequestDTO = dto;
        }
    }
}
