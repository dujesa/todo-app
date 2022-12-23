using TodoApp.Data.Entities.Models;

namespace TodoApp.Domain.Models;

public class ListItems
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ActiveItemsCount { get; set; }
    public ICollection<Item> Items{ get; set; } = new List<Item>();
}
