using WarSafe.Domain.Entities;
using System.Text.RegularExpressions;

namespace WarSafe.Application.Validators;

public static class UserValidator
{
    public static void Validate(User user)
    {
        if (user == null)
            throw new Exception("User cannot be null");

        if (string.IsNullOrWhiteSpace(user.Email))
            throw new Exception("Email is required");

        if (!IsValidEmail(user.Email))
            throw new Exception("Invalid email format");

        if (string.IsNullOrWhiteSpace(user.PasswordHash))
            throw new Exception("Password is required");

        if (user.PasswordHash.Length < 6)
            throw new Exception("Password must be at least 6 characters long");
    }

    private static bool IsValidEmail(string email)
    {
        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }
}
