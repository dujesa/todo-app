using TodoApp.Domain.Factories;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Actions;
using TodoApp.Presentation.Actions.Dashboard;
using TodoApp.Presentation.Actions.User;

namespace TodoApp.Presentation.Factories;

public class UserActionsFactory
{
    public static UserAction Create()
    {
        var actions = new List<IAction>
        {
            new UserAddAction(RepositoryFactory.Create<UserRepository>()),
            new UserEditAction(RepositoryFactory.Create<UserRepository>()),
            new UserDeleteAction(RepositoryFactory.Create<UserRepository>()),
            new UsersReadByGroupAction(RepositoryFactory.Create<UserRepository>(), RepositoryFactory.Create<GroupRepository>()),
            new UserAddToGroupAction(
                RepositoryFactory.Create<UserRepository>(),
                RepositoryFactory.Create<GroupRepository>(),
                RepositoryFactory.Create<GroupUserRepository>()),
            new ExitMenuAction()
        };

        var menuAction = new UserAction(actions);
        return menuAction;
    }
}
