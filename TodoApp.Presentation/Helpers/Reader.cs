using TodoApp.Data.Enums;

namespace TodoApp.Presentation.Helpers;

public static class Reader
{
    public static bool TryReadNumber(out int number)
    {
        number = 0;
        var isNumber = int.TryParse(Console.ReadLine(), out var inputNumber);
        if (!isNumber)
            return false;

        number = inputNumber;
        return true;
    }

    public static bool TryReadNumber(string message, out int number)
    {
        Console.WriteLine(message);
        return TryReadNumber(out number);
    }

    public static bool TryReadDateTime(string message, out DateTime date)
    {
        date = DateTime.UtcNow;

        Console.WriteLine(message);
        var input = Console.ReadLine();

        var isValidInput = int.TryParse(input, out var number);
        if (isValidInput)
            date = date.AddDays(number);

        return isValidInput;
    }

    public static bool TryReadStatus(string message, out Status status)
    {
        status = Status.Todo;

        Console.WriteLine(message);
        var input = Console.ReadLine();
        var isStatus = Enum.TryParse(typeof(Status), input, out var inputStatus);

        if (isStatus && inputStatus is not null)
        {
            status = (Status)inputStatus;
        }

        return isStatus;
    }

    public static bool TryReadLine(string message, out string line)
    {
        line = string.Empty;

        Console.WriteLine(message);
        var input = Console.ReadLine();
        var isEmpty = string.IsNullOrWhiteSpace(input);

        if (!isEmpty && input is not null)
            line = input;

        return !isEmpty;
    }

    public static void ReadInput(string message, out string input)
    {
        Console.WriteLine(message);
        input = Console.ReadLine() ?? string.Empty;
    }
}

