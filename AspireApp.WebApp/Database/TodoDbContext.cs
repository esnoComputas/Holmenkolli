using Microsoft.EntityFrameworkCore;

namespace AspireApp.WebApp.Database;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; }
}
