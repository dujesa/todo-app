using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Entities;
using TodoApp.Data.Entities.Models;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Repositories;

public class UserRepository : BaseRepository
{
    public UserRepository(TodoAppDbContext dbContext) : base(dbContext)
    {
    }

    public ResponseResultType Add(User user)
    {
        DbContext.Users.Add(user);

        return SaveChanges();
    }

    public ResponseResultType Delete(int id)
    {
        var userToDelete = DbContext.Users.Find(id);
        if (userToDelete is null)
        {
            return ResponseResultType.NotFound;
        }

        DbContext.Users.Remove(userToDelete);

        return SaveChanges();
    }

    public ResponseResultType Update(User user, int id)
    {
        var userToUpdate = DbContext.Users.Find(id);
        if (userToUpdate is null)
        {
            return ResponseResultType.NotFound;
        }

        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;

        return SaveChanges();
    }

    public User? GetById(int id) => DbContext.Users.FirstOrDefault(u => u.Id == id);
    public ICollection<User> GetAll() => DbContext.Users.ToList();

    public ICollection<UserWithGroups> GetByGroupId(int groupId)
    {
        var users = DbContext.Users
            .Include(u => u.GroupUsers)
            .ThenInclude(gu => gu.Group)
            .Select(u => new UserWithGroups
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Groups = u.GroupUsers
                    .Select(gu => gu.Group)
                    .ToList(),
            })
            .Where(u => u.Groups.Any(g => g.Id == groupId))
            .ToList();

        return users;
    }
}
