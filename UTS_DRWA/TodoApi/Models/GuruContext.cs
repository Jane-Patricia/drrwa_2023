using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class GuruContext : DbContext
{
    public GuruContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}