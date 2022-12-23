using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Entities;
using TodoApp.Data.Entities.Models;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Repositories;

public class GroupRepository : BaseRepository
{
    public GroupRepository(TodoAppDbContext dbContext) : base(dbContext)
    {
    }

    public ResponseResultType Add(Group group)
    {
        DbContext.Groups.Add(group);

        return SaveChanges();
    }

    public ResponseResultType Delete(int id)
    {
        var groupToDelete = DbContext.Groups.Find(id);
        if (groupToDelete is null)
        {
            return ResponseResultType.NotFound;
        }

        DbContext.Groups.Remove(groupToDelete);

        return SaveChanges();
    }

    public ResponseResultType Update(Group group, int id)
    {
        var groupToUpdate = DbContext.Groups.Find(id);
        if (groupToUpdate is null)
        {
            return ResponseResultType.NotFound;
        }

        groupToUpdate.Name = group.Name;

        return SaveChanges();
    }

    public Group? GetById(int id) => DbContext.Groups.FirstOrDefault(g => g.Id == id);
    
    public ICollection<Group> GetAll() => DbContext.Groups.ToList();

    public GroupDetails? GetDetailedById(int groupId)
    {
        var groupDetails = DbContext.Groups
            .Include(g => g.Lists)
            .ThenInclude(l => l.Items)
            .Where(g => g.Id == groupId)
            .Select(g => new GroupDetails
            {
                Id = groupId,
                Name = g.Name,
                listItems = g.Lists.Select(l => new ListItems 
                {
                    Id = l.Id,
                    Name = l.Name,
                    ActiveItemsCount = l.Items.Count(i => i.Status != Data.Enums.Status.Done),
                    Items = l.Items
                }).ToList(),
            })
            .FirstOrDefault();

        return groupDetails;
    }
}
