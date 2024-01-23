using CodeAcademyNET8.Projects.ATM_Project.Models;
using CodeAcademyNET8.Projects.ATM_Project.Services;

namespace CodeAcademyNET8.Projects.ATM_Project;

internal class ATMMain
{
    private readonly AuthenticationService _authenticationService;
    private readonly FileService _fileService = new();
    private readonly TransactionService _transactionService = new();

    public ATMMain()
    {
        _authenticationService = new AuthenticationService(_fileService.UserList);
    }

    public UserModel CurrentUser => _authenticationService.CurrentUser;

    public void Run()
    {
        while (true)
        {
            var isLoggedIn = !string.IsNullOrEmpty(CurrentUser.Id);
            IMenu menu = isLoggedIn ? new LoggedInMenu(this) : new GuestMenu(this);

            menu.DisplayOptions();
            menu.HandleSelection();
        }
    }

    internal void CheckBalance()
    {
        PrintBanner();
        PrintInBlue($"Your current balance is: {CurrentUser.Balance}");
        WaitForClickAnyButton();
    }

    internal void Withdraw()
    {
        var withdrawalSuccessful = _transactionService.Withdraw(CurrentUser);
        if (!withdrawalSuccessful)
        {
            WaitForClickAnyButton();
            return;
        }

        _fileService.UpdateUser(CurrentUser);
        WaitForClickAnyButton();
    }

    internal void Deposit()
    {
        var depositSuccessful = _transactionService.Deposit(CurrentUser);
        if (!depositSuccessful)
        {
            WaitForClickAnyButton();
            return;
        }

        _fileService.UpdateUser(CurrentUser);
        WaitForClickAnyButton();
    }

    public void PrintTransactionHistory()
    {
        _transactionService.PrintTransactionHistory(CurrentUser);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    internal bool Login()
    {
        PrintBanner();

        if (!string.IsNullOrEmpty(CurrentUser.Id))
        {
            PrintInRed("You are already logged in.");
            Console.WriteLine("Would you like to log out?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            var option = Console.ReadLine();

            if (option == "1")
                Logout();
            else
                return false;
        }

        var id = GetUserInput("Please enter your ID:");
        var userExists = _authenticationService.UserExists(id);
        if (!userExists)
        {
            PrintInRed("User does not exist.");
            Console.WriteLine("Would you like to open an account now?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            var option = Console.ReadLine();

            return option == "1" && Register(id);
        }

        var pin = GetUserInput("Please enter your PIN:");
        var loginSuccessful = _authenticationService.Login(id, pin);
        if (!loginSuccessful)
        {
            PrintInRed("Invalid ID or PIN.");
            WaitForClickAnyButton();
            return false;
        }

        PrintInGreen("Successfully logged in!");
        WaitForClickAnyButton();
        return true;
    }

    internal bool Register(string id = "")
    {
        PrintBanner();

        if (string.IsNullOrWhiteSpace(id))
        {
            id = GetUserInput("Please enter your ID:");

            if (_authenticationService.UserExists(id))
            {
                PrintInRed("User already exists. Please pick another ID.");
                WaitForClickAnyButton();
                Register();
            }
        }

        var name = GetUserInput("Please enter your name:");
        var surname = GetUserInput("Please enter your surname:");
        var pin = GetUserInput("Please enter your PIN code:");
        var hashedPin = _authenticationService.HashPin(pin);

        var user = new UserModel
        {
            Id = id,
            Balance = 0,
            Name = name,
            Surname = surname,
            Pin = hashedPin,
            Transactions = []
        };

        PrintInRed("Are you sure these details are correct?");
        Console.WriteLine($"Name: {user.Name}\nSurname: {user.Surname}\nPIN: {pin}");
        var option = GetUserInput("1. Yes\n2. No");

        if (option != "1" && !string.Equals(option, "yes", StringComparison.CurrentCultureIgnoreCase))
            Register();

        _fileService.AddNewUser(user);
        PrintInGreen("Successfully registered!");
        WaitForClickAnyButton();
        return true;
    }

    internal string GetUserInput(string message)
    {
        while (true)
        {
            PrintInBlue(message);
            PrintInBlue("To exit the program type 'exit'");
            var input = Console.ReadLine();

            if (string.Equals(input, "exit", StringComparison.CurrentCultureIgnoreCase))
                Exit();

            if (!string.IsNullOrWhiteSpace(input)) return input;

            PrintInRed("Invalid input.");
            WaitForClickAnyButton();
        }
    }

    internal void Logout()
    {
        _authenticationService.Logout();
        PrintBanner();
        PrintInGreen("You have been logged out.");
        WaitForClickAnyButton();
    }

    internal void Exit()
    {
        PrintBanner();
        PrintInGreen("Thank you for using our ATM. Goodbye!");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }

    internal void WaitForClickAnyButton()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    internal void PrintInBlue(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    internal void PrintInRed(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    internal void PrintInGreen(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    internal void PrintBanner()
    {
        const string banner = """
                                  __   ____  _____ __ __          ___          ___ ___   ____  ______  ____   __
                                 /  ] /    |/ ___/|  |  |        /   \        |   |   | /    ||      ||    | /  ]
                                /  / |  o  (   \_ |  |  | _____ |     | _____ | _   _ ||  o  ||      | |  | /  /
                               /  /  |     |\__  ||  _  ||     ||  O  ||     ||  \_/  ||     ||_|  |_| |  |/  /
                              /   \_ |  _  |/  \ ||  |  ||_____||     ||_____||   |   ||  _  |  |  |   |  /   \_
                              \     ||  |  |\    ||  |  |       |     |       |   |   ||  |  |  |  |   |  \     |
                               \____||__|__| \___||__|__|        \___/        |___|___||__|__|  |__|  |____\____|
                                                                                                                     
                              """;
        Console.WriteLine();
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine(banner);
        Console.ForegroundColor = originalColor;
    }
}