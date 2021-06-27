using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class CreateGenreCommand : IRequest<string>
    {
        public GenreDTO GenreDTO { get; set; }
        public CreateGenreCommand(GenreDTO dto)
        {
            GenreDTO = dto;
        }
    }
}
