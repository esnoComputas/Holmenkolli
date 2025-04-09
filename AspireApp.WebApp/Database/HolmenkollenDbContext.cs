using Microsoft.EntityFrameworkCore;

namespace AspireApp.WebApp.Database;

public class HolmenkollenDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<Candidate> Candidates { get; set; }
}
