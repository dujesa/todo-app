using TodoApp.Presentation.Abstractions;

namespace TodoApp.Presentation.Actions.Dashboard;

public class GroupAction : BaseMenuAction
{
    public GroupAction(IList<IAction> actions) : base(actions)
    {
        Name = "Group menu";
    }

    public override void Open()
    {
        Console.WriteLine("Groups management");
        base.Open();
    }
}