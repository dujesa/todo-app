using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Group;

public class GroupAddAction : IAction
{
    private readonly GroupRepository _groupRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Add group";

    public GroupAddAction(GroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public void Open()
    {
        Reader.ReadInput("Name", out var name);
        var group = new Data.Entities.Models.Group(name);

        var responseResult = _groupRepository.Add(group);
        if (responseResult is ResponseResultType.Success)
        {
            Writer.Write(group);
            Console.ReadLine();

            return;
        }

        Console.WriteLine("Failed to add group, no changes saved!");
        Console.ReadLine();
    }
}
