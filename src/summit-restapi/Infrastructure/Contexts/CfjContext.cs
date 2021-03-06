using CfjSummit.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CfjSummit.Infrastructure.Contexts
{
    public class CfjContext : DbContext
    {
        public CfjContext(DbContextOptions<CfjContext> options)
            : base(options)
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramUserProfile> ProgramUserProfiles { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ProgramGenre> ProgramGenres { get; set; }
        public DbSet<ProgramPresenter> ProgramPresenters { get; set; }
        public DbSet<ProgramLink> ProgramLinks { get; set; }
        public DbSet<ProgramPresenterLink> ProgramPresenterLinks { get; set; }
    }
}
