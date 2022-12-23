using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Actions;

namespace TodoApp.Presentation.Extensions;

public static class ActionExtensions
{
    public static void PrintActionsAndOpen(this IList<IAction> actions)
    {
        const string INVALID_INPUT_MSG = "Please type in number!";
        const string INVALID_ACTION_MSG = "Please select valid action!";


        var isExitSelected = false;
        do
        {
            PrintActions(actions);

            var isValidInput = int.TryParse(Console.ReadLine(), out var actionIndex);
            if (!isValidInput)
            {
                PrintErrorMessage(INVALID_INPUT_MSG);
                continue;
            }

            var action = actions.FirstOrDefault(a => a.MenuIndex == actionIndex);
            if (action is null)
            {
                PrintErrorMessage(INVALID_ACTION_MSG);
                continue;
            }

            action.Open();

            isExitSelected = action is ExitMenuAction;
        } while (!isExitSelected);
    }

    public static void SetActionIndexes(this IList<IAction> actions)
    {
        var index = 0;
        foreach (var action in actions)
        {
            action.MenuIndex = ++index;
        }
    }

    private static void PrintActions(IList<IAction> actions)
    {
        foreach (var action in actions)
        {
            Console.WriteLine($"{action.MenuIndex}. {action.Name}");
        }
    }

    private static void PrintErrorMessage(string message)
    {
        Console.WriteLine(message);
        Thread.Sleep(1000);
        Console.Clear();
    }
}
