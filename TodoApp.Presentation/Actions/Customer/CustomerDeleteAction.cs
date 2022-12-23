using TodoApp.Data.Entities.Models;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.Customer;

public class CustomerDeleteAction : IAction
{
    private readonly CustomerRepository _customerRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Delete customer";

    public CustomerDeleteAction(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void Open()
    {
        var customers = _customerRepository.GetAll();
        Writer.Write(customers);

        Console.WriteLine("\nType customer id you wanna delete or exit");
        var isRead = Reader.TryReadNumber(out var customerId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }
        var responseResult = _customerRepository.Delete(customerId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Console.WriteLine("Customer deleted successfully!");
                break;
            case ResponseResultType.NotFound:
                Console.WriteLine("Customer with inputted id does not exist.");
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