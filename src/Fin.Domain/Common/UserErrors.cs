namespace Fin.Domain.Common;

public static class UserErrors
{
    public static Error NotFound(int id) => new(
        "User.NotFound",
        $"The user with ID {id} was not found.",
        ErrorType.NotFound);
}
