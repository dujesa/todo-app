using TodoApp.Data.Entities.Models;
using TodoApp.Data.Entities;
using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Repositories;

public class CustomerRepository : BaseRepository
{
    public CustomerRepository(TodoAppDbContext dbContext) : base(dbContext)
    {
    }

    public ResponseResultType Add(Customer customer)
    {
        DbContext.Customers.Add(customer);

        return SaveChanges();
    }

    public ResponseResultType Delete(int id)
    {
        var customerToDelete = DbContext.Customers.Find(id);
        if (customerToDelete is null)
        {
            return ResponseResultType.NotFound;
        }

        DbContext.Customers.Remove(customerToDelete);

        return SaveChanges();
    }

    public ResponseResultType Update(Customer customer, int id)
    {
        var customerToUpdate = DbContext.Customers.Find(id);
        if (customerToUpdate is null)
        {
            return ResponseResultType.NotFound;
        }

        customerToUpdate.FirstName = customer.FirstName;
        customerToUpdate.LastName = customer.LastName;

        return SaveChanges();
    }

    public Customer? GetById(int id) => DbContext.Customers.FirstOrDefault(c => c.Id == id);
    public ICollection<Customer> GetAll() => DbContext.Customers.ToList();

    public ICollection<Customer> GetAllBySubscriptionEndIn(int numberOfDays)
    {
        var queryDate = DateTime.UtcNow.AddDays(numberOfDays);

        var customers = DbContext.Customers
            .Where(c => c.SubscriptionEnd < queryDate)
            .ToList();

        return customers;
    }
}
