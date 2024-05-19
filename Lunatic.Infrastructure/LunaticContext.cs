
using Lunatic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lunatic.Infrastructure {
    public class LunaticContext : DbContext {
        public LunaticContext(DbContextOptions<LunaticContext> options) : base(options) {}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //     optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=LunaticDB;User Id=lunatic;Password=lunatic");
        // }
    }
}

