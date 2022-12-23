using TodoApp.Domain.Enums;
using TodoApp.Domain.Repositories;
using TodoApp.Presentation.Abstractions;
using TodoApp.Presentation.Helpers;

namespace TodoApp.Presentation.Actions.User;

public class UserEditAction : IAction
{
    private readonly UserRepository _userRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Edit user";

    public UserEditAction(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Open()
    {
        var users = _userRepository.GetAll();
        Writer.Write(users);

        Console.WriteLine("\nType user id you wanna edit or exit");
        var isRead = Reader.TryReadNumber(out var userId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number");
            return;
        }

        var user = users.FirstOrDefault(u => u.Id == userId);
        if (user is null)
        {
            Console.WriteLine("User with inputted id is not found");
            return;
        }

        Console.WriteLine("<Enter> to skip editting certain field");

        if (Reader.TryReadLine($"First name: {user.FirstName}", out var firstName))
            user.FirstName = firstName;

        if (Reader.TryReadLine($"Last name: {user.LastName}", out var lastName))
            user.LastName = lastName;

        var responseResult = _userRepository.Update(user, userId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Writer.Write(user);
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
