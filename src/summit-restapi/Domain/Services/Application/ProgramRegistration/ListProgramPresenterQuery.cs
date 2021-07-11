using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class ListProgramPresenterQuery : IRequest<ListPresenterResponseDTO>
    {
        public ListProgramPresenterQuery(ListPresenterRequestDTO dto)
        {
            ListPresenterRequestDTO = dto;
        }

        public ListPresenterRequestDTO ListPresenterRequestDTO { get; }
    }
}
