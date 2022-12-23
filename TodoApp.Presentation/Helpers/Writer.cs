using TodoApp.Data.Entities.Models;
using TodoApp.Data.Enums;
using TodoApp.Domain.Models;

namespace TodoApp.Presentation.Helpers;

public class Writer
{
    public static void Write(User user)
        => Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName}");

    public static void Write(ICollection<User> users)
    {
        foreach (var user in users)
            Write(user);
    }

    public static void Write(Customer customer)
    {
        if (customer is null)
        {
            Console.WriteLine("Customer details are unavailable!");
            return;
        }

        var subscriptionDaysLeft = (customer.SubscriptionEnd - DateTime.UtcNow).Days;
        Console.WriteLine($"{customer.Id}: {customer.FirstName} {customer.LastName} \t Subscription: {subscriptionDaysLeft} days left");
    }

    public static void Write(ICollection<Customer> customers)
    {
        foreach (var customer in customers)
            Write(customer);
    }

    public static void Write(Group group)
    {
        Console.WriteLine($"{group.Id}: {group.Name}");
    }

    public static void Write(ICollection<Group> groups)
    {
        foreach (var group in groups)
            Write(group);
    }

    public static void Write(Item item)
    {
        var statusSign = item.Status switch
        {
            Status.Done => "✓",
            Status.Urgent => "URGENT!",
            _ =>  " ", 
        };

        Console.WriteLine($"{item.Id}: {item.Title} - {item.Priority}: [{statusSign}] => Due date: {item.DueDate.ToShortDateString()}");
    }

    public static void Write(ICollection<Item> items)
    {
        foreach (var item in items)
            Write(item);
    }

    public static void Write(List list)
    {
        Console.WriteLine($"----List----");
        Console.WriteLine($"[{ list.Id}] { list.Name}");

        if (list.Items is null)
        {
            Console.WriteLine();
            return;
        }
         
        Console.WriteLine("Items:");
        Write(list.Items);
        Console.WriteLine("------------");
        Console.WriteLine();
    }

    public static void Write(ICollection<List> lists)
    {
        foreach (var list in lists)
            Write(list);
    }

    public static void Write(GroupDetails group)
    {
        Console.WriteLine($"[Group - {group.Id}: {group.Name}]");
        foreach (var listItems in group.listItems)
        {
            Console.WriteLine($"\nList - {listItems.Id}: {listItems.Name}");
            Console.WriteLine($"\n----Items----");
            Write(listItems.Items);
            Console.WriteLine($"\n------------");
            Console.WriteLine($"\nActive items count: {listItems.ActiveItemsCount}\n\n");
        }
        Console.WriteLine();
    }

    public static void Write(UserWithGroups user)
    {
        Console.WriteLine($"[User - {user.Id}]: {user.FirstName} {user.LastName} is in groups:");

        foreach (var group in user.Groups)
            Write(group);

        Console.WriteLine();
    }

    public static void Error(string message)
    {
        Console.WriteLine(message);
        Thread.Sleep(1000);
        Console.Clear();
    }
}
