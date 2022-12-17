namespace TodoApp.Data.Entities.Models;

public class List
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "Todo List";

    public Guid GroupId { get; set; }
    public Group? Group { get; set; }

    public ICollection<Item> Items { get; set; } = new List<Item>();
}
