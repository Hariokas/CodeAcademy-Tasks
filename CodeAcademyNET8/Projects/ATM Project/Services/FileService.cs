using CodeAcademyNET8.Projects.ATM_Project.Models;
using Newtonsoft.Json;

namespace CodeAcademyNET8.Projects.ATM_Project.Services;

// Handles reading and writing user data and transaction history to a file.
internal class FileService
{
    private const string UsersFileName = "users.json";

    private readonly List<UserModel> _userList = [];

    public List<UserModel> UserList => ReadUsersFile();

    public void AddNewUser(UserModel newUser)
    {
        _userList.Add(newUser);
        SaveUserList();
    }

    public void UpdateUser(UserModel user)
    {
        var index = _userList.FindIndex(u => u.Id == user.Id);
        _userList[index] = user;
        SaveUserList();
    }

    public void SaveUserList()
    {
        try
        {
            var users = JsonConvert.SerializeObject(_userList);
            File.WriteAllText(UsersFileName, users);
            Console.WriteLine("Database has been updated!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to save user list: {e.Message}");
        }
    }

    private List<UserModel> ReadUsersFile()
    {
        try
        {
            var users = File.ReadAllText(UsersFileName);
            var userList = JsonConvert.DeserializeObject<List<UserModel>>(users) ?? [];
            return userList;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to read users file: {e.Message}");
            return [];
        }
    }
}