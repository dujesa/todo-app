namespace TodoApp.Data.Entities.Models;
public class Group
{
    public Group(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
    public ICollection<List> Lists { get;} = new List<List>();
}
