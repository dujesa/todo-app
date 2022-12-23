using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Item;

public class ItemEditAction : IAction
{
    private readonly ItemRepository _itemRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Edit item";

    public ItemEditAction(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void Open()
    {
        var items = _itemRepository.GetAll();
        Writer.Write(items);

        Console.WriteLine("\nType item id you wanna edit or exit");
        var isRead = Reader.TryReadNumber(out var itemId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }

        var item = items.FirstOrDefault(u => u.Id == itemId);
        if (item is null)
        {
            Console.WriteLine("Item with inputted id is not found");
            return;
        }

        Console.WriteLine("<Enter> to skip editting certain field");

        if (Reader.TryReadLine($"Title: {item.Title}", out var title))
            item.Title = title;

        if (Reader.TryReadNumber($"Priority: {item.Priority}", out var priority))
            item.Priority = priority;

        var dueDateFor = DateTime.UtcNow.Subtract(item.DueDate).Days;
        if (Reader.TryReadDateTime($"Due date for <number-of-days>: {dueDateFor}", out var dueDate))
            item.DueDate = dueDate;

        if (Reader.TryReadStatus($"Status: {item.Status}", out var status))
            item.Status = status;

        var responseResult = _itemRepository.Update(item, itemId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Writer.Write(item);
                break;
            case ResponseResultType.NoChanges:
                Console.WriteLine("No changes applied");
                break;
            default:
                Console.WriteLine("Error occurred while updating item");
                break;
        }

        Console.ReadLine();
        Console.Clear();
    }
}
