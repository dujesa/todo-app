using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Entities.Models;

namespace TodoApp.Data.Seeds;

public static class DatabaseSeeder
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasData(new List<User>
            {
                new User("Bartol", "Deak")
                {
                    Id = 1,
                },
                new User("Ante", "Roca")
                {
                    Id = 2,
                },
                new User("Matija", "Luketin")
                {
                    Id = 3,
                },
                new User("Duje", "Saric")
                {
                    Id = 4,
                },
                new User("Marija", "Sustic")
                {
                    Id = 5,
                },
                new User("Lucia", "Vukorepa")
                {
                    Id = 6,
                },
                new User("Alex", "Amanzi")
                {
                    Id = 7,
                },
                new User("Frane", "Doljanin")
                {
                    Id = 8,
                },
                new User("Jere", "Mandusic")
                {
                    Id = 9,
                },
                new User("Ivo", "Jovanovic")
                {
                    Id = 10,
                },
                new User("Gabriela", "Bonic")
                {
                    Id = 13,
                },
            });

        builder.Entity<Customer>()
            .HasData(new List<Customer>
            {
                new Customer("Ante", "Vuletic")
                {
                    Id = 11,
                },
                new Customer("Kreso", "Condic")
                {
                    Id = 12,
                }
            });

        builder.Entity<Group>()
            .HasData(new List<Group>
            {
                new Group("devovi")
                {
                    Id = 1
                },
                new Group("internship-voditelji")
                {
                    Id = 2
                },
                new Group("days-organizatori")
                {
                    Id = 3
                }
            });

        builder.Entity<GroupUser>()
            .HasData(new List<GroupUser>
            {
                new GroupUser
                {
                    GroupId= 1,
                    UserId= 1,
                },
                new GroupUser
                {
                    GroupId= 1,
                    UserId= 3,
                },
                new GroupUser
                {
                    GroupId= 1,
                    UserId= 4,
                },
                new GroupUser
                {
                    GroupId= 1,
                    UserId= 7,
                },
                new GroupUser
                {
                    GroupId= 1,
                    UserId= 8,
                },
                new GroupUser
                {
                    GroupId= 1,
                    UserId= 9,
                },
                new GroupUser
                {
                    GroupId= 1,
                    UserId= 10,
                },
                new GroupUser
                {
                    GroupId= 2,
                    UserId= 1,
                },
                new GroupUser
                {
                    GroupId= 2,
                    UserId= 4,
                },
                new GroupUser
                {
                    GroupId= 2,
                    UserId= 5,
                },
                new GroupUser
                {
                    GroupId= 2,
                    UserId= 6,
                },
                new GroupUser
                {
                    GroupId= 2,
                    UserId= 13,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 1,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 2,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 3,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 4,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 5,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 6,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 7,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 8,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 9,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 10,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 11,
                },
                new GroupUser
                {
                    GroupId= 3,
                    UserId= 12,
                }
            });

        builder.Entity<List>()
            .HasData(new List<List>
            {
                new List
                {
                    Id = 1,
                    GroupId = 1,
                    Name = "#dev-tasks"
                },
                new List
                {
                    Id = 2,
                    GroupId = 2,
                    Name = "#internship-tasks"
                },
                new List
                {
                    Id = 3,
                    GroupId = 1,
                    Name = "#days-tasks"
                },
            });

        builder.Entity<Item>()
            .HasData(new List<Item>
            {
                new Item("Days app implementacija")
                {
                    Id = 1,
                    DueDate = new DateTime(2023, 5, 15, 0, 0, 0, DateTimeKind.Utc),
                    Priority = 1,
                    ListId = 1,
                },
                new Item("Days app CI CD")
                {
                    Id = 2,
                    DueDate = new DateTime(2022, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                    Priority = 1,
                    ListId = 1,
                },
                new Item("Days youtube videi")
                {
                    Id = 3,
                    DueDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Priority = 3,
                    ListId = 3,
                },
                new Item("Days speakeri")
                {
                    Id = 4,
                    DueDate = new DateTime(2023, 5, 5, 0, 0, 0, DateTimeKind.Utc),
                    Priority = 3,
                    ListId = 3,
                },
                new Item("Days sponzori")
                {
                    Id = 5,
                    DueDate = new DateTime(2023, 4, 2, 0, 0, 0, DateTimeKind.Utc),
                    Priority = 3,
                    ListId = 3,
                },
                new Item("Organizacija Internship Teambuildinga")
                {
                    Id = 6,
                    DueDate = new DateTime(2023, 5, 15, 0, 0, 0, DateTimeKind.Utc),
                    Priority = 10,
                    ListId = 2
                },
                new Item("IC organizacija")
                {
                    Id = 7,
                    DueDate = new DateTime(2023, 1, 5, 0, 0, 0, DateTimeKind.Utc),
                    Priority = 1,
                    ListId = 2
                },
            });
    }
}
