using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class DeleteGenreCommand : IRequest<int>
    {
        public string GenreGuid { set; get; }
        public DeleteGenreCommand(string genreGuid)
        {
            GenreGuid = genreGuid;
        }
    }
}
