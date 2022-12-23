using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TodoApp.Data.Entities;

namespace TodoApp.Domain.Factories;

public static class DbContextFactory
{
    public static TodoAppDbContext GetTodoAppDbContext()
    {
        var options = new DbContextOptionsBuilder()
            .UseNpgsql(ConfigurationManager.ConnectionStrings["TodoApp"].ConnectionString)
            .Options;

        return new TodoAppDbContext(options);
    }
}
