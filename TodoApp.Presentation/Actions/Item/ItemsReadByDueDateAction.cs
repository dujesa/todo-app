using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Item;
internal class ItemsReadByDueDateAction : IAction
{
    private readonly ItemRepository _itemRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Display items by due date in range";

    public ItemsReadByDueDateAction(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void Open()
    {
        var isRead = Reader.TryReadDateTime("Input due date for <number-of-days>",out var dueDate);
        if (!isRead)
        {
            Writer.Error("Error: Invalid input");
            return;
        }

        var items = _itemRepository.GetByDueDate(dueDate);
        Writer.Write(items);

        Console.ReadLine();
        Console.Clear();
    }
}
