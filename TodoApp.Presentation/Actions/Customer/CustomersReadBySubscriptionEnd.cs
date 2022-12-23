using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Customer;
public class CustomersReadBySubscriptionEnd : IAction
{
    private readonly CustomerRepository _customerRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Display customers with custom subscription end";

    public CustomersReadBySubscriptionEnd(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void Open()
    {
        var isValidInputNumber = Reader.TryReadNumber("\nEnter <number> of days in which to query customers sub end date", out var numberOfDays);
        if (!isValidInputNumber)
            return;

        var customers = _customerRepository.GetAllBySubscriptionEndIn(numberOfDays);

        Console.WriteLine("\nCustomers:");

        Writer.Write(customers);

        Console.ReadLine();
        Console.Clear();
    }
}
