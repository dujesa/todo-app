using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Item;

public class ItemsReadByGroupAction : IAction
{
    private readonly ItemRepository _itemRepository;
    private readonly GroupRepository _groupRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Display items by group";

    public ItemsReadByGroupAction(ItemRepository itemRepository, GroupRepository groupRepository)
    {
        _itemRepository = itemRepository;
        _groupRepository = groupRepository;
    }

    public void Open()
    {
        var groups = _groupRepository.GetAll();
        Writer.Write(groups);
        var isValidInputId = Reader.TryReadNumber("\nEnter <id> of group to list items", out var groupId);
        if (!isValidInputId)
            return;

        var groupItems = _itemRepository.GetByGroupId(groupId);

        Console.WriteLine("\nActive items:");

        if (groupItems is not null)
            Writer.Write(groupItems.Items);

        Console.ReadLine();
        Console.Clear();
    }
}
