using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.List;

public class ListEditAction : IAction
{
    private readonly ListRepository _listRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Edit list";

    public ListEditAction(ListRepository listRepository)
    {
        _listRepository = listRepository;
    }

    public void Open()
    {
        var lists = _listRepository.GetAll();
        Writer.Write(lists);

        Console.WriteLine("\nType list id you wanna edit or exit");
        var isRead = Reader.TryReadNumber(out var listId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }

        var list = lists.FirstOrDefault(u => u.Id == listId);
        if (list is null)
        {
            Console.WriteLine("List with inputted id is not found");
            return;
        }

        Console.WriteLine("<Enter> to skip editting certain field");

        if (Reader.TryReadLine($"Title: {list.Name}", out var name))
            list.Name = name;

        var responseResult = _listRepository.Update(list, listId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Writer.Write(list);
                break;
            case ResponseResultType.NoChanges:
                Console.WriteLine("No changes applied");
                break;
            default:
                Console.WriteLine("Error occurred while updating list");
                break;
        }

        Console.ReadLine();
        Console.Clear();
    }
}
