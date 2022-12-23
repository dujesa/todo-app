using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Group;

public class GroupEditAction : IAction
{
    private readonly GroupRepository _groupRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Edit group";

    public GroupEditAction(GroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public void Open()
    {
        var groups = _groupRepository.GetAll();
        Writer.Write(groups);

        Console.WriteLine("\nType group id you wanna edit or exit");
        var isRead = Reader.TryReadNumber(out var groupId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }

        var group = groups.FirstOrDefault(u => u.Id == groupId);
        if (group is null)
        {
            Console.WriteLine("Group with inputted id is not found");
            return;
        }

        Console.WriteLine("<Enter> to skip editting certain field");

        if (Reader.TryReadLine($"First name: {group.Name}", out var name))
            group.Name = name;

        var responseResult = _groupRepository.Update(group, groupId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Writer.Write(group);
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
