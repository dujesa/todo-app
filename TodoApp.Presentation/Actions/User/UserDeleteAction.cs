using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.User;

public class UserDeleteAction : IAction
{
    private readonly UserRepository _userRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Delete user";

    public UserDeleteAction(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Open()
    {
        var users = _userRepository.GetAll();
        Writer.Write(users);

        Console.WriteLine("\nType user id you wanna delete or exit");
        var isRead = Reader.TryReadNumber(out var userId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }

        var responseResult = _userRepository.Delete(userId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Console.WriteLine("User deleted successfully!");
                break;
            case ResponseResultType.NotFound:
                Console.WriteLine("User with inputted id does not exist.");
                break;
            case ResponseResultType.NoChanges:
                Console.WriteLine("No changes applied");
                break;
            default:
                Console.WriteLine("Error occurred while updating user");
                break;
        }

        Console.ReadLine();
        Console.Clear();
    }
}