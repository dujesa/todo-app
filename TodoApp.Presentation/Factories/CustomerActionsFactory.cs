using TodoApp.Domain.Factories;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Actions;
using TodoApp.Presentation.Actions.Dashboard;
using TodoApp.Presentation.Actions.Customer;

namespace TodoApp.Presentation.Factories;

public class CustomerActionsFactory
{
    public static CustomerAction Create()
    {
        var actions = new List<IAction>
        {
            new CustomerAddAction(RepositoryFactory.Create<CustomerRepository>()),
            new CustomerEditAction(RepositoryFactory.Create<CustomerRepository>()),
            new CustomerDeleteAction(RepositoryFactory.Create<CustomerRepository>()),
            new CustomersReadBySubscriptionEnd(RepositoryFactory.Create<CustomerRepository>()),
            new ExitMenuAction()
        };

        var menuAction = new CustomerAction(actions);
        return menuAction;
    }
}
