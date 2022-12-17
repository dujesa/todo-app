using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TodoApp.Data.Entities.Models;

namespace TodoApp.Data.Entities;

public class TodoAppDbContext : DbContext
{
    public TodoAppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Group> Groups => Set<Group>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<List> Lists => Set<List>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>()
            .HasMany(g => g.Users)
            .WithMany(u => u.Groups);

        modelBuilder.Entity<List>()
            .HasOne(l => l.Group)
            .WithMany(g => g.Lists)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Item>()
            .HasOne(i => i.List)
            .WithMany(l => l.Items)
            .OnDelete(DeleteBehavior.Cascade);

        //DatabaseSeeder.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}

public class TodoAppDbContextFactory : IDesignTimeDbContextFactory<TodoAppDbContext>
{
    public TodoAppDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddXmlFile("App.config")
            .Build();

        config.Providers
            .First()
            .TryGet("connectionStrings:add:TodoApp:connectionString", out var connectionString);

        var options = new DbContextOptionsBuilder<TodoAppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new TodoAppDbContext(options);
    }
}
