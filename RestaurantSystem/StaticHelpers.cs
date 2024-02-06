namespace RestaurantSystem;

internal static class StaticHelpers
{
    private const string Banner = """
                                  ⢀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⣠⣤⣶⣶
                                  ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢰⣿⣿⣿⣿
                                  ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣀⣀⣾⣿⣿⣿⣿
                                  ⣿⣿⣿⣿⣿⡏⠉⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿
                                  ⣿⣿⣿⣿⣿⣿⠀⠀⠀⠈⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠉⠁⠀⣿
                                  ⣿⣿⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠙⠿⠿⠿⠻⠿⠿⠟⠿⠛⠉⠀⠀⠀⠀⠀⣸⣿
                                  ⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿
                                  ⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣴⣿⣿⣿⣿
                                  ⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⢰⣹⡆⠀⠀⠀⠀⠀⠀⣭⣷⠀⠀⠀⠸⣿⣿⣿⣿
                                  ⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠈⠉⠀⠀⠤⠄⠀⠀⠀⠉⠁⠀⠀⠀⠀⢿⣿⣿⣿
                                  ⣿⣿⣿⣿⣿⣿⣿⣿⢾⣿⣷⠀⠀⠀⠀⡠⠤⢄⠀⠀⠀⠠⣿⣿⣷⠀⢸⣿⣿⣿
                                  ⣿⣿⣿⣿⣿⣿⣿⣿⡀⠉⠀⠀⠀⠀⠀⢄⠀⢀⠀⠀⠀⠀⠉⠉⠁⠀⠀⣿⣿⣿
                                  ⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿
                                  ⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿
                                  """;

    public static void PrintError(Exception e)
    {
        PrintInYellow(Banner);
        PrintInRed(e.Message);
        WaitForClickAnyButton();
    }

    internal static void PrintInBlue(string message, bool noNewLine = false)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        if (noNewLine)
            Console.Write(message);
        else
            Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    internal static void PrintInRed(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    internal static void PrintInGreen(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    internal static void PrintInYellow(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    internal static void PrintBanner()
    {
        Console.Clear();
        const string banner = """

                              ______              ___  ___                      _      _  _
                              |  _  \             |  \/  |                     | |    | |( )
                              | | | |  ___    ___ | .  . |  __ _  _ __    __ _ | |  __| ||/  ___
                              | | | | / _ \  / __|| |\/| | / _` || '_ \  / _` || | / _` |   / __|
                              | |/ / | (_) || (__ | |  | || (_| || | | || (_| || || (_| |   \__ \
                              |___/   \___/  \___|\_|  |_/ \__,_||_| |_| \__,_||_| \__,_|   |___/
                                                                                                 
                                                                                                 
                              
                              """;
        PrintInYellow(banner);
        PrintInYellow("****************************");
    }

    internal static string GetUserInput(string message)
    {
        if (!message.EndsWith(' '))
            message += ' ';

        while (true)
        {
            PrintInBlue("To exit the program type 'exit'");
            PrintInBlue(message, true);
            var input = Console.ReadLine();

            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                return "-1";

            if (!string.IsNullOrWhiteSpace(input)) return input;

            PrintInRed("Invalid input.");
            WaitForClickAnyButton();
        }
    }

    internal static int GetIntInput(string message)
    {
        while (true)
        {
            var input = GetUserInput(message);
            if (int.TryParse(input, out var result))
                return result;

            PrintInRed("Invalid input.");
            WaitForClickAnyButton();
        }
    }

    internal static decimal GetDecimalInput(string message)
    {
        while (true)
        {
            var input = GetUserInput(message);
            if (decimal.TryParse(input, out var result))
                return result;

            PrintInRed("Invalid input.");
            WaitForClickAnyButton();
        }
    }

    internal static void WaitForClickAnyButton()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}