using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class ListProgramQuery : IRequest<ListProgramResponseDTO>
    {
        public ListProgramRequestDTO ListProgramRequestDTO { set; get; }

        public ListProgramQuery(ListProgramRequestDTO dto)
        {
            ListProgramRequestDTO = dto;
        }
    }
}
