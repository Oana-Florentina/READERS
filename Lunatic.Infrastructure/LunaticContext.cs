
using Lunatic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lunatic.Infrastructure {
    public class LunaticContext : DbContext {
        public LunaticContext(DbContextOptions<LunaticContext> options) : base(options) {}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<CoverImage> CoverImages { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }
        public DbSet<FriendRecommandation> FriendRecommandation { get; set; }
        public DbSet<BookClub> BookClubs { get; set; }
        public DbSet<Post> Posts { get; set; }


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //     optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=LunaticDB;User Id=lunatic;Password=lunatic");
        // }
    }
}

