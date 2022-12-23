using TodoApp.Domain.Factories;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Actions;
using TodoApp.Presentation.Actions.Dashboard;
using TodoApp.Presentation.Actions.Group;

namespace TodoApp.Presentation.Factories;

public class GroupActionsFactory
{
    public static GroupAction Create()
    {
        var actions = new List<IAction>
        {
            new GroupAddAction(RepositoryFactory.Create<GroupRepository>()),
            new GroupEditAction(RepositoryFactory.Create<GroupRepository>()),
            new GroupDeleteAction(RepositoryFactory.Create<GroupRepository>()),
            new GroupReadAction(RepositoryFactory.Create<GroupRepository>()),
            new ExitMenuAction()
        };

        var menuAction = new GroupAction(actions);
        return menuAction;
    }
}
