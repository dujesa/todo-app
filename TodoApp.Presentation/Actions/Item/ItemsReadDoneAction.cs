using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Item;
public class ItemsReadDoneAction : IAction
{
    private readonly ItemRepository _itemRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Display done items";

    public ItemsReadDoneAction(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void Open()
    {
        var items = _itemRepository.GetAllDone();

        Console.WriteLine("\nDone items:");
        Writer.Write(items);

        Console.ReadLine();
        Console.Clear();
    }
}
