using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class ListGenreQuery : IRequest<ListGenreResponseDTO>
    {
        public ListGenreRequestDTO ListGenreRequestDTO { get; set; }

        public ListGenreQuery(ListGenreRequestDTO dto)
        {
            ListGenreRequestDTO = dto;
        }
    }
}
