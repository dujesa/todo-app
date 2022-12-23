using TodoApp.Presentation.Abstractions;

namespace TodoApp.Presentation.Actions.Dashboard;

public class CustomerAction : BaseMenuAction
{
    public CustomerAction(IList<IAction> actions) : base(actions)
    {
        Name = "Customer menu";
    }

    public override void Open()
    {
        Console.WriteLine("Customers management");
        base.Open();
    }
}