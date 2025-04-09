using Microsoft.EntityFrameworkCore;

namespace AspireApp.WebApp.Database;

public class HolmenkollenDbContext(DbContextOptions<HolmenkollenDbContext> options) : DbContext(options)
{
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<RaceGroup> RaceGroups { get; set; }
    public DbSet<Position> Positions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RaceGroup>().HasData(
            new RaceGroup { Id = 1, Name = "Herrelaget", Positions = new List<Position>() },
            new RaceGroup { Id = 2, Name = "Damelaget", Positions = new List<Position>() },
            new RaceGroup { Id = 3, Name = "Koselaget", Positions = new List<Position>() }
        );
    }
}
