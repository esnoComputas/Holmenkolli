using System.Text.Json;
using AspireApp.WebApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace AspireApp.WebApp.Services;

public class TodoService(TodoDbContext dbContext, IDistributedCache cache)
{
    private const string CacheKey = "all_todos";
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(5);

    public async Task<IEnumerable<TodoItem>?> GetAll()
    {
        var cachedTodos = await cache.GetStringAsync(CacheKey);
        if (!string.IsNullOrEmpty(cachedTodos))
        {
            return JsonSerializer.Deserialize<List<TodoItem>>(cachedTodos);
        }
        var todosFromDb = await dbContext.TodoItems.ToListAsync();

        var jsonTodos = JsonSerializer.Serialize(todosFromDb);
        await cache.SetStringAsync(
            CacheKey,
            jsonTodos,
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = _cacheExpiration }
        );

        return todosFromDb;
    }

    public async Task Add(string title)
    {
        dbContext.TodoItems.Add(new TodoItem { Title = title, CreatedAt = DateTime.UtcNow });
        await dbContext.SaveChangesAsync();
        await cache.RemoveAsync(CacheKey);
    }

    public async Task Delete(int id)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(id);
        if (todoItem != null)
        {
            dbContext.TodoItems.Remove(todoItem);
            await dbContext.SaveChangesAsync();
            await cache.RemoveAsync(CacheKey);
        }
    }

    public async Task UpdateIsComplete(int id, bool value)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(id);
        if (todoItem != null)
        {
            todoItem.IsCompleted = value;
            await dbContext.SaveChangesAsync();
            await cache.RemoveAsync(CacheKey);
        }
    }
}
