using TodoApp.Presentation.Abstractions;

namespace TodoApp.Presentation.Actions.Dashboard;

public class ItemAction : BaseMenuAction
{
    public ItemAction(IList<IAction> actions) : base(actions)
    {
        Name = "Item menu";
    }

    public override void Open()
    {
        Console.WriteLine("Items management");
        base.Open();
    }
}