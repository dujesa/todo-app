using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Entities;
using TodoApp.Data.Entities.Models;
using TodoApp.Data.Enums;
using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Repositories;

public class ListRepository : BaseRepository
{
    public ListRepository(TodoAppDbContext dbContext) : base(dbContext)
    {
    }

    public ResponseResultType Add(List list)
    {
        DbContext.Lists.Add(list);

        return SaveChanges();
    }

    public ResponseResultType Delete(int id)
    {
        var listToDelete = DbContext.Lists.Find(id);
        if (listToDelete is null)
        {
            return ResponseResultType.NotFound;
        }

        DbContext.Lists.Remove(listToDelete);

        return SaveChanges();
    }

    public ResponseResultType Update(List list, int id)
    {
        var listToUpdate = DbContext.Lists.Find(id);
        if (listToUpdate is null)
        {
            return ResponseResultType.NotFound;
        }

        listToUpdate.Name = list.Name;
        listToUpdate.GroupId = list.GroupId;

        return SaveChanges();
    }

    public List? GetById(int id) => DbContext.Lists.FirstOrDefault(l => l.Id == id);
    public ICollection<List> GetAll() => DbContext.Lists.Include(l => l.Items).ToList();

    public ICollection<List> GetAllDone()
    {
        var doneLists = DbContext.Lists
            .Include(l => l.Items)
            .Where(l => l.Items.All(i => i.Status == Status.Done))
            .ToList();

        return doneLists;
    }

    public ICollection<List> GetAllActive()
    {
        var doneLists = DbContext.Lists
            .Include(l => l.Items)
            .Where(l => l.Items.Any(i => i.Status == Status.Todo || i.Status == Status.Urgent))
            .ToList();

        return doneLists;
    }
}
