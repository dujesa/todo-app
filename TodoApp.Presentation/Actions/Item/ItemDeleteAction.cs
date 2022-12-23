using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Item;

public class ItemDeleteAction : IAction
{
    private readonly ItemRepository _itemRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Delete item";

    public ItemDeleteAction(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void Open()
    {
        var items = _itemRepository.GetAll();
        Writer.Write(items);

        Console.WriteLine("\nType item id you wanna delete or exit");
        var isRead = Reader.TryReadNumber(out var itemId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }

        var responseResult = _itemRepository.Delete(itemId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Console.WriteLine("Item deleted successfully!");
                break;
            case ResponseResultType.NotFound:
                Console.WriteLine("Item with inputted id does not exist.");
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