namespace TodoApp.Domain.Models;

public class GroupDetails
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ListItems> listItems { get; set; } = new List<ListItems>();
}
