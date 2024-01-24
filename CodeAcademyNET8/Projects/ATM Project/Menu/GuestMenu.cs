using CodeAcademyNET8.Projects.ATM_Project.Enums;

namespace CodeAcademyNET8.Projects.ATM_Project.Menu;

internal class GuestMenu(ATMMain atmMain) : IMenu
{
    public void DisplayOptions()
    {
        atmMain.PrintBanner();

        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("3. Exit");
    }

    public void HandleSelection()
    {
        var option = GetMenuSelection();

        switch (option)
        {
            case GuestMenuOptionsEnum.Login:
                atmMain.Login();
                break;
            case GuestMenuOptionsEnum.Register:
                atmMain.Register();
                break;
            case GuestMenuOptionsEnum.Exit:
                atmMain.Exit();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private GuestMenuOptionsEnum GetMenuSelection()
    {
        Console.Write("Select an option: ");
        var option = Console.ReadLine();

        if (Enum.TryParse(option, out GuestMenuOptionsEnum menuOption))
            return menuOption;

        atmMain.PrintInRed("Invalid option.");
        GetMenuSelection();
        return GuestMenuOptionsEnum.Exit;
    }
}