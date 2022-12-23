using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Group;
public class GroupReadAction : IAction
{
    private readonly GroupRepository _groupRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Group details";

    public GroupReadAction(GroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public void Open()
    {
        var groups = _groupRepository.GetAll();
        Writer.Write(groups);
        var isValidInputId = Reader.TryReadNumber("\nEnter <id> of group to display details", out var groupId);
        if (!isValidInputId)
            return;

        var groupDetails = _groupRepository.GetDetailedById(groupId);
        if (groupDetails is null)
            Console.WriteLine("Group not found");
        else
            Writer.Write(groupDetails); 

        Console.ReadLine();
        Console.Clear();
    }
}

