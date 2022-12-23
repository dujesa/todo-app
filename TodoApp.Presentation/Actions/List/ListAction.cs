using TodoApp.Presentation.Abstractions;

namespace TodoApp.Presentation.Actions.Dashboard;

public class ListAction : BaseMenuAction
{
    public ListAction(IList<IAction> actions) : base(actions)
    {
        Name = "List menu";
    }

    public override void Open()
    {
        Console.WriteLine("Lists management");
        base.Open();
    }
}