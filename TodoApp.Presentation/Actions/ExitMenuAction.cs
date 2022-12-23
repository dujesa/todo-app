using TodoApp.Presentation.Abstractions;

namespace TodoApp.Presentation.Actions;

public class ExitMenuAction : IAction
{
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Exit";

    public ExitMenuAction()
    {
    }

    public void Open()
    {
    }
}
