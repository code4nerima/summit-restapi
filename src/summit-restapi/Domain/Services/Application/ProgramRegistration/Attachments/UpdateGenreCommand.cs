using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class UpdateGenreCommand : IRequest<int>
    {
        public GenreDTO GenreDTO { get; set; }
        public UpdateGenreCommand(GenreDTO dto)
        {
            GenreDTO = dto;
        }
    }
}
