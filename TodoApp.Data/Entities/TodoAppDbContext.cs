using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TodoApp.Data.Entities.Models;
using TodoApp.Data.Seeds;

namespace TodoApp.Data.Entities;

public class TodoAppDbContext : DbContext
{
    public TodoAppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Group> Groups => Set<Group>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<GroupUser> GroupUsers => Set<GroupUser>();

    public DbSet<Item> Items => Set<Item>();
    public DbSet<List> Lists => Set<List>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupUser>()
            .HasKey(gu => new { gu.UserId, gu.GroupId });

        modelBuilder.Entity<GroupUser>()
            .HasOne(g => g.User)
            .WithMany(u => u.GroupUsers)
            .HasForeignKey(gu => gu.UserId);

        modelBuilder.Entity<GroupUser>()
            .HasOne(g => g.Group)
            .WithMany(g => g.GroupUsers)
            .HasForeignKey(gu => gu.GroupId);

        modelBuilder.Entity<List>()
            .HasOne(l => l.Group)
            .WithMany(g => g.Lists)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Item>()
            .HasOne(i => i.List)
            .WithMany(l => l.Items)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasDiscriminator<string>("user_type")
            .HasValue<User>("user")
            .HasValue<Customer>("customer");

        DatabaseSeeder.Seed(modelBuilder);
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
