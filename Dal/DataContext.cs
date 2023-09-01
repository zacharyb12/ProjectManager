using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; init; }
    public DbSet<Project> Projects { get; init; }
    public DbSet<TaskItem> Tasks { get; init; }
}