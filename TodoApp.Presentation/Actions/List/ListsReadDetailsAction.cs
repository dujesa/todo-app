using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.List;
public class ListsReadDetailsAction : IAction
{
    private readonly ListRepository _listRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Display list details";

    public ListsReadDetailsAction(ListRepository listRepository)
    {
        _listRepository = listRepository;
    }

    public void Open()
    {
        var doneLists = _listRepository.GetAllDone();
        var activeLists = _listRepository.GetAllActive();

        Console.WriteLine("\nDone lists with items:");
        Writer.Write(doneLists);

        Console.WriteLine("\nActive lists with items:");
        Writer.Write(activeLists);

        Console.ReadLine();
        Console.Clear();
    }
}