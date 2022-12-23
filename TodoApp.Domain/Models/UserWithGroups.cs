using TodoApp.Data.Entities.Models;

namespace TodoApp.Domain.Models;

public class UserWithGroups
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ICollection<Group> Groups { get; set; } = new List<Group>();
}
