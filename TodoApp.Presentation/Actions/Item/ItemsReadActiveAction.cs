using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Item;

public class ItemsReadActiveAction : IAction
{
    private readonly ItemRepository _itemRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Display active items";

    public ItemsReadActiveAction(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void Open()
    {
        var items = _itemRepository.GetAllActive();

        Console.WriteLine("\nActive items:");
        Writer.Write(items);

        Console.ReadLine();
        Console.Clear();
    }
}
