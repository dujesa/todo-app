using TodoApp.Domain.Factories;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Actions;
using TodoApp.Presentation.Actions.Dashboard;
using TodoApp.Presentation.Actions.Item;

namespace TodoApp.Presentation.Factories;

public class ItemActionsFactory
{
    public static ItemAction Create()
    {
        var actions = new List<IAction>
        {
            new ItemAddToListAction(RepositoryFactory.Create<ItemRepository>(), RepositoryFactory.Create<ListRepository>()),
            new ItemEditAction(RepositoryFactory.Create<ItemRepository>()),
            new ItemDeleteAction(RepositoryFactory.Create<ItemRepository>()),
            new ItemsReadActiveAction(RepositoryFactory.Create<ItemRepository>()),
            new ItemsReadDoneAction(RepositoryFactory.Create<ItemRepository>()),
            new ItemsReadByGroupAction(RepositoryFactory.Create<ItemRepository>(), RepositoryFactory.Create<GroupRepository>()),
            new ItemsReadByDueDateAction(RepositoryFactory.Create<ItemRepository>()),
            new ExitMenuAction()
        };

        var menuAction = new ItemAction(actions);
        return menuAction;
    }
}
