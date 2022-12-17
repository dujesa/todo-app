namespace TodoApp.Data.Entities.Models;
public class Group
{
    public Group(string name)
    {
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<List> Lists { get;} = new List<List>();
}
