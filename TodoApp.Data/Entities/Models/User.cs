namespace TodoApp.Data.Entities.Models;

public class User
{
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}
