using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class GetGenreQuery : IRequest<GenreDTO>
    {
        public string GenreGuid { get; }

        public GetGenreQuery(string genreGuid)
        {
            GenreGuid = genreGuid;
        }
    }
}
