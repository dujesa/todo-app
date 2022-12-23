using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Customer;

public class CustomerEditAction : IAction
{
    private readonly CustomerRepository _customerRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Edit customer";

    public CustomerEditAction(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void Open()
    {
        var customers = _customerRepository.GetAll();
        Writer.Write(customers);

        Console.WriteLine("\nType customer id you wanna edit or exit");
        var isRead = Reader.TryReadNumber(out var customerId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }

        var customer = customers.FirstOrDefault(u => u.Id == customerId);
        if (customer is null)
        {
            Console.WriteLine("Customer with inputted id is not found");
            return;
        }

        Console.WriteLine("<Enter> to skip editting certain field");

        if (Reader.TryReadLine($"First name: {customer.FirstName}", out var firstName))
            customer.FirstName = firstName;

        if (Reader.TryReadLine($"Last name: {customer.LastName}", out var lastName))
            customer.LastName = lastName;

        var responseResult = _customerRepository.Update(customer, customerId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Writer.Write(customer);
                break;
            case ResponseResultType.NoChanges:
                Console.WriteLine("No changes applied");
                break;
            default:
                Console.WriteLine("Error occurred while updating customer");
                break;
        }

        Console.ReadLine();
        Console.Clear();
    }
}
