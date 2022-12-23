using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Actions;
using TodoApp.Presentation.Extensions;

namespace TodoApp.Presentation.Factories;
public class MainMenuFactory
{
    public static IList<IAction> CreateActions()
    {
        var actions = new List<IAction>
        {
            UserActionsFactory.Create(),
            CustomerActionsFactory.Create(),
            GroupActionsFactory.Create(),
            ItemActionsFactory.Create(),
            ListActionsFactory.Create(),
            new ExitMenuAction(),
        };

        actions.SetActionIndexes();

        return actions;
    }
}
