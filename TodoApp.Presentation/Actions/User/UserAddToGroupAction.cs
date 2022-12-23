using TodoApp.Data.Entities.Models;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.User;
public class UserAddToGroupAction : IAction
{
    private readonly UserRepository _userRepository;
    private readonly GroupRepository _groupRepository;
    private readonly GroupUserRepository _groupUserRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Add user to group";

    public UserAddToGroupAction(
        UserRepository userRepository, 
        GroupRepository groupRepository,
        GroupUserRepository groupUserRepository)
    {
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _groupUserRepository = groupUserRepository;
    }

    public void Open()
    {
        var groups = _groupRepository.GetAll();
        Writer.Write(groups);
        var isValidGroupId = Reader.TryReadNumber("\nEnter <id> of group youo want to add user", out var groupId);
        if (!isValidGroupId)
            return;

        var addingGroup = groups.SingleOrDefault(g => g.Id == groupId);
        if (addingGroup is null)
        {
            Console.WriteLine("Group with inputted id does not exist.");

            Console.ReadLine();
            Console.Clear();

            return;
        }

        var users = _userRepository.GetAll();
        Writer.Write(users);
        var isValidUserId = Reader.TryReadNumber("\nEnter <id> of user want to add to selected group", out var userId);
        if (!isValidUserId)
            return;

        var addingUser = users.FirstOrDefault(u => u.Id == userId);
        if (addingUser is null)
        {
            Console.WriteLine("User with inputted id does not exist.");

            Console.ReadLine();
            Console.Clear();

            return;
        }

        var responseResult = _groupUserRepository.Add(new GroupUser
        {
            GroupId = groupId,
            UserId = userId,
        });
        
        if (responseResult is ResponseResultType.Success)
        {
            Console.WriteLine($"Successfully added" +
                $" {addingUser.FirstName} {addingUser.LastName}" +
                $"to group {addingGroup.Name}");
            Console.ReadLine();

            return;
        }

        Console.WriteLine("Failed to add item, no changes saved!");
        Console.ReadLine();
    }
}

