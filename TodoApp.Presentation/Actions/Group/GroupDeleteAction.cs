using TodoApp.Data.Entities.Models;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Group;

public class GroupDeleteAction : IAction
{
    private readonly GroupRepository _groupRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Delete group";

    public GroupDeleteAction(GroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public void Open()
    {
        var groups = _groupRepository.GetAll();
        Writer.Write(groups);

        Console.WriteLine("\nType group id you wanna delete or exit");
        var isRead = Reader.TryReadNumber(out var groupId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }

        var responseResult = _groupRepository.Delete(groupId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Console.WriteLine("Group deleted successfully!");
                break;
            case ResponseResultType.NotFound:
                Console.WriteLine("Group with inputted id does not exist.");
                break;
            case ResponseResultType.NoChanges:
                Console.WriteLine("No changes applied");
                break;
            default:
                Console.WriteLine("Error occurred while updating group");
                break;
        }

        Console.ReadLine();
        Console.Clear();
    }
}