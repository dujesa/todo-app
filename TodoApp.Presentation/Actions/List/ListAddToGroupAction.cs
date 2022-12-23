using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.List;

public class ListAddToGroupAction : IAction
{
    private readonly ListRepository _listRepository;
    private readonly GroupRepository _groupRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Add list to group";

    public ListAddToGroupAction(ListRepository listRepository, GroupRepository groupRepository)
    {
        _listRepository = listRepository;
        _groupRepository = groupRepository;
    }

    public void Open()
    {
        var groups = _groupRepository.GetAll();
        Writer.Write(groups);
        var isValidInputId = Reader.TryReadNumber("\nEnter <id> of group in which you wanna add list", out var groupId);
        if (!isValidInputId)
            return;

        Reader.ReadInput("Name", out var name);
        var list = new Data.Entities.Models.List
        {
            Name = name,
            GroupId = groupId
        };

        var responseResult = _listRepository.Add(list);
        if (responseResult is ResponseResultType.Success)
        {
            Writer.Write(list);
            Console.ReadLine();

            return;
        }

        Console.WriteLine("Failed to add list, no changes saved!");
        Console.ReadLine();
    }
}
