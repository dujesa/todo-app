namespace TodoApp.Data.Entities.Models;

public class List
{
    public int Id { get; set; }
    public string Name { get; set; } = "Todo List";

    public int GroupId { get; set; }
    public Group? Group { get; set; }

    public ICollection<Item> Items { get; set; } = new List<Item>();
}
