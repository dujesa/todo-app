using TodoApp.Domain.Factories;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Actions;
using TodoApp.Presentation.Actions.Dashboard;
using TodoApp.Presentation.Actions.List;

namespace TodoApp.Presentation.Factories;

public class ListActionsFactory
{
    public static ListAction Create()
    {
        var actions = new List<IAction>
        {
            new ListAddToGroupAction(RepositoryFactory.Create<ListRepository>(), RepositoryFactory.Create<GroupRepository>()),
            new ListEditAction(RepositoryFactory.Create<ListRepository>()),
            new ListDeleteAction(RepositoryFactory.Create<ListRepository>()),
            new ListsReadDetailsAction(RepositoryFactory.Create<ListRepository>()),
            new ExitMenuAction()
        };

        var menuAction = new ListAction(actions);
        return menuAction;
    }
}
