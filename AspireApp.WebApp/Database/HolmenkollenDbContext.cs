using Microsoft.EntityFrameworkCore;

namespace AspireApp.WebApp.Database;

public class HolmenkollenDbContext(DbContextOptions<HolmenkollenDbContext> options) : DbContext(options)
{
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<RaceGroup> RaceGroups { get; set; }
    public DbSet<Position> Positions { get; set; }
}
