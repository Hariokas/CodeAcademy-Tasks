using System.Security.Cryptography;
using System.Text;
using CodeAcademyNET8.Projects.ATM_Project.Models;

namespace CodeAcademyNET8.Projects.ATM_Project.Services;

// Manages user ID and PIN validation
internal class AuthenticationService(IEnumerable<UserModel> userList)
{
    protected internal UserModel CurrentUser { get; set; } = new();

    protected internal bool Login(string id, string pin)
    {
        if (!UserExists(id))
        {
            Console.WriteLine("User does not exist");
            return false;
        }

        if (!PinMatches(id, pin))
        {
            Console.WriteLine("Invalid PIN");
            return false;
        }

        CurrentUser = userList.FirstOrDefault(u => u.Id == id);
        return true;
    }

    protected internal bool UserExists(string userId)
    {
        return userList.Any(u => u.Id == userId);
    }

    private protected bool PinMatches(string userId, string pin)
    {
        var user = userList.FirstOrDefault(u => u.Id == userId);
        if (user == null)
            return false;

        var hashedPin = HashPin(pin);
        return user.Pin == hashedPin;
    }

    protected internal void Logout()
    {
        CurrentUser = new UserModel();
    }

    protected internal string HashPin(string pin)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(pin));

        var sb = new StringBuilder();
        foreach (var b in bytes)
            sb.Append(b.ToString("x2"));

        return sb.ToString();
    }

}