using TodoApp.Data.Enums;

namespace TodoApp.Domain.Extensions;

public static class StatusExtensions
{
    public static bool IsOneOf(this Status status, params Status[] statusesToCheck)
    {
        return statusesToCheck.Contains(status);
    }
}
