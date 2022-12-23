using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Entities;
using TodoApp.Data.Entities.Models;
using TodoApp.Data.Enums;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Repositories;
public class ItemRepository : BaseRepository
{
    public ItemRepository(TodoAppDbContext dbContext) : base(dbContext)
    {
    }

    public ResponseResultType Add(Item item)
    {
        DbContext.Items.Add(item);

        return SaveChanges();
    }

    public ResponseResultType Delete(int id)
    {
        var itemToDelete = DbContext.Items.Find(id);
        if (itemToDelete is null)
        {
            return ResponseResultType.NotFound;
        }

        DbContext.Items.Remove(itemToDelete);

        return SaveChanges();
    }

    public ResponseResultType Update(Item item, int id)
    {
        var itemToUpdate = DbContext.Items.Find(id);
        if (itemToUpdate is null)
        {
            return ResponseResultType.NotFound;
        }

        itemToUpdate.DueDate = item.DueDate;
        itemToUpdate.Status = item.Status;
        itemToUpdate.Title = item.Title;
        itemToUpdate.Priority = item.Priority;
        itemToUpdate.ListId = item.ListId;

        return SaveChanges();
    }

    public Item? GetById(int id) => DbContext.Items.FirstOrDefault(i => i.Id == id);

    public ICollection<Item> GetAll() => DbContext.Items.ToList();

    public ICollection<Item> GetAllActive()
    {
        return DbContext.Items
            .Where(i => i.DueDate > DateTime.UtcNow)
            .Where(i => i.Status == Status.Todo || i.Status == Status.Urgent)
            .ToList();
    }

    public ICollection<Item> GetAllDone()
    {
        return DbContext.Items
            .Where(i => i.Status == Status.Done)
            .ToList();
    }

    public GroupItems? GetByGroupId(int groupId)
    {
        var items = DbContext.Groups
            .Include(g => g.Lists)
            .ThenInclude(l => l.Items)
            .Where(g => g.Id == groupId)
            .Select(g => new GroupItems
            {
                Id = g.Id,
                Name = g.Name,
                Items = g.Lists.SelectMany(l => l.Items).ToList()
            })
            .FirstOrDefault();

        return items;
    }

    public ICollection<Item> GetByDueDate(DateTime dueDate)
    {
        var items = DbContext.Items
            .Where(i => i.DueDate < dueDate && i.DueDate >= DateTime.UtcNow)
            .OrderByDescending(i => i.Priority)
            .ToList();

        return items;
    }
}
