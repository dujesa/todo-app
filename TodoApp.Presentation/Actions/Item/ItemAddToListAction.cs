using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Item;

public class ItemAddToListAction : IAction
{
    private readonly ItemRepository _itemRepository;
    private readonly ListRepository _listRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Add item to list";

    public ItemAddToListAction(ItemRepository itemRepository, ListRepository listRepository)
    {
        _itemRepository = itemRepository;
        _listRepository = listRepository;
    }

    public void Open()
    {
        var lists = _listRepository.GetAll();
        Writer.Write(lists);
        var isValidInputId = Reader.TryReadNumber("\nEnter <id> of list in which you wanna add item", out var listId);
        if (!isValidInputId)
            return;

        var exists = lists.Any(g => g.Id == listId);
        if (!exists)
        {
            Console.WriteLine("Group with inputted id does not exist.");

            Console.ReadLine();
            Console.Clear();

            return;
        }


        Reader.ReadInput("Title", out var title);
        var item = new Data.Entities.Models.Item(title)
        {
            ListId = listId
        };

        var responseResult = _itemRepository.Add(item);
        if (responseResult is ResponseResultType.Success)
        {
            Writer.Write(item);
            Console.ReadLine();

            return;
        }

        Console.WriteLine("Failed to add item, no changes saved!");
        Console.ReadLine();
    }
}
