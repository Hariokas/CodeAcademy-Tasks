using CodeAcademyNET8.Projects.ATM_Project.Enums;

namespace CodeAcademyNET8.Projects.ATM_Project;

internal class LoggedInMenu(ATMMain atmMain) : IMenu
{
    public void DisplayOptions()
    {
        atmMain.PrintBanner();

        Console.WriteLine("1. Check balance");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Deposit");
        Console.WriteLine("4. Get last 5 transactions");
        Console.WriteLine("5. Logout");
        Console.WriteLine("6. Exit");
    }

    public void HandleSelection()
    {
        var option = GetMenuSelection();

        switch (option)
        {
            case MenuOptionsEnum.Logout:
                atmMain.Logout();
                break;
            case MenuOptionsEnum.TransactionHistory:
                atmMain.PrintTransactionHistory();
                break;
            case MenuOptionsEnum.CheckBalance:
                atmMain.CheckBalance();
                break;
            case MenuOptionsEnum.Withdraw:
                atmMain.Withdraw();
                break;
            case MenuOptionsEnum.Deposit:
                atmMain.Deposit();
                break;
            case MenuOptionsEnum.Exit:
                atmMain.Exit();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private MenuOptionsEnum GetMenuSelection()
    {
        Console.Write("Select an option: ");
        var option = Console.ReadLine();

        if (Enum.TryParse(option, out MenuOptionsEnum menuOption))
            return menuOption;

        atmMain.PrintInRed("Invalid option.");
        GetMenuSelection();
        return MenuOptionsEnum.Exit;
    }
}
