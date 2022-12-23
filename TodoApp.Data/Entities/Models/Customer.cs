namespace TodoApp.Data.Entities.Models;

public class Customer : User
{
    public Customer(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public DateTime SubscriptionEnd { get; set; }
}
