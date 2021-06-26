namespace CfjSummit.Domain.Models.Entities
{
    public class ProgramGenre : Entity
    {
        protected ProgramGenre()
        {

        }
        public ProgramGenre(long programId, long genreId)
        {
            ProgramId = programId;
            GenreId = genreId;
        }

        public Program Program { private set; get; }
        public long ProgramId { private set; get; }

        public Genre Genre { private set; get; }
        public long GenreId { private set; get; }
    }
}
