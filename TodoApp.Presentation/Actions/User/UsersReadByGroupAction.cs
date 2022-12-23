using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.User;

public class UsersReadByGroupAction : IAction
{
    private readonly UserRepository _userRepository;
    private readonly GroupRepository _groupRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Display users by group";

    public UsersReadByGroupAction(UserRepository userRepository, GroupRepository groupRepository)
    {
        _userRepository = userRepository;
        _groupRepository = groupRepository;
    }

    public void Open()
    {
        var groups = _groupRepository.GetAll();
        Writer.Write(groups);
        var isValidInputId = Reader.TryReadNumber("\nEnter <id> of group to list items", out var groupId);
        if (!isValidInputId)
            return;

        var users = _userRepository.GetByGroupId(groupId);

        Console.WriteLine("\nUsers:");

        foreach(var user in users ) 
            Writer.Write(user);

        Console.ReadLine();
        Console.Clear();
    }
}
