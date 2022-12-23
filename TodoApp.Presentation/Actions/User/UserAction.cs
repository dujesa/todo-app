using TodoApp.Presentation.Abstractions;

namespace TodoApp.Presentation.Actions.Dashboard;

public class UserAction : BaseMenuAction
{
    public UserAction(IList<IAction> actions) : base(actions)
    {
        Name = "User menu";
    }

    public override void Open()
    {
        Console.WriteLine("Users management");
        base.Open();
    }
}
