using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.List;

public class ListDeleteAction : IAction
{
    private readonly ListRepository _listRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Delete list";

    public ListDeleteAction(ListRepository listRepository)
    {
        _listRepository = listRepository;
    }

    public void Open()
    {
        var lists = _listRepository.GetAll();
        Writer.Write(lists);

        Console.WriteLine("\nType list id you wanna delete or exit");
        var isRead = Reader.TryReadNumber(out var listId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }

        var responseResult = _listRepository.Delete(listId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Console.WriteLine("List deleted successfully!");
                break;
            case ResponseResultType.NotFound:
                Console.WriteLine("List with inputted id does not exist.");
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