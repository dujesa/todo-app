using TodoApp.Data.Enums;

namespace TodoApp.Data.Entities.Models;

public class Item
{
    public Item(string title)
    {
        Title = title;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Priority { get; set; }
    public Status Status { get; set; }
    public DateTime DueDate { get; set; }

    public Guid ListId { get; set; }
    public List? List { get; set; }
}
