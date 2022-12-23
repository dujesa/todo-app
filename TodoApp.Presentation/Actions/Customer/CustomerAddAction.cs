using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Customer;

public class CustomerAddAction : IAction
{
    private readonly CustomerRepository _customerRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Add customer";

    public CustomerAddAction(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void Open()
    {
        Reader.ReadInput("First name", out var firstName);
        Reader.ReadInput("Last name", out var lastName);
        Reader.TryReadDateTime("Subscription end for <number-of-days>", out var subscriptionEnd);
        var customer = new Data.Entities.Models.Customer(firstName, lastName)
        {
            SubscriptionEnd = subscriptionEnd
        };

        var responseResult = _customerRepository.Add(customer);
        if (responseResult is ResponseResultType.Success)
        {
            Writer.Write(customer);
            Console.ReadLine();

            return;
        }

        Console.WriteLine("Failed to add customer, no changes saved!");
        Console.ReadLine();
    }
}
