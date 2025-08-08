using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    public class TennisDbContext : DbContext
    {
        public TennisDbContext(DbContextOptions<TennisDbContext> options) : base(options) {}

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
