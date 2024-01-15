using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

public static class Lecture1
{
    public static void RunTasks()
    {
        FirstTask();
        SecondTask();
        ThirdTask();
        FourthTask();
        var preke = "Obuolys";
        var kiekis = 5;
        var kaina = 2;
        FifthTask(preke, kiekis, kaina);
        SixthTask("Vardenis Pavardenis", 28, "Software Developer", "johndoe@example.com", "+1 123-456-7890");
    }

    private static void FirstTask()
    {
        Console.WriteLine("   /\\");
        Console.WriteLine("  /  \\");
        Console.WriteLine(" /    \\");
        Console.WriteLine("/______\\");
        Filler();
    }

    private static void SecondTask()
    {
        Console.WriteLine("      *****");
        Console.WriteLine("    **     **");
        Console.WriteLine("  **         **");
        Console.WriteLine(" **   Hello   **");
        Console.WriteLine(" **    from   **");
        Console.WriteLine("  **   C#    **");
        Console.WriteLine("    **     **");
        Console.WriteLine("      *****");
        Filler();
    }

    private static void ThirdTask()
    {
        ChangeForegroundColor(ConsoleColor.Yellow);
        Console.WriteLine("   /\\");
        ChangeForegroundColor(ConsoleColor.Green);
        Console.WriteLine("  /  \\");
        ChangeForegroundColor(ConsoleColor.Magenta);
        Console.WriteLine(" /    \\");
        ChangeForegroundColor(ConsoleColor.DarkMagenta);
        Console.WriteLine("/______\\");

        ChangeForegroundColor();
        Filler();
    }

    private static void FourthTask()
    {
        ChangeForegroundColor(ConsoleColor.Blue);
        Console.WriteLine(" / \\     / \\  ");

        ChangeForegroundColor(ConsoleColor.Cyan);
        Console.WriteLine("/   \\   /   \\ ");

        ChangeForegroundColor(ConsoleColor.White);
        Console.WriteLine("\\    \\ /    /");

        ChangeForegroundColor(ConsoleColor.Yellow);
        Console.WriteLine(" \\         /    ");

        ChangeForegroundColor(ConsoleColor.Magenta);
        Console.WriteLine("  \\       /     ");

        ChangeForegroundColor(ConsoleColor.Red);
        Console.WriteLine("   \\     /      ");

        ChangeForegroundColor(ConsoleColor.DarkYellow);
        Console.WriteLine("    \\   /       ");

        ChangeForegroundColor(ConsoleColor.Green);
        Console.WriteLine("     \\ /        ");

        ChangeForegroundColor(ConsoleColor.Green);
        Console.WriteLine("      V         ");

        ChangeForegroundColor();
        Filler();
    }

    private static void FifthTask(string item, int quantity, int price)
    {
        Console.WriteLine($"Prekė: {item}\nKiekis: {quantity}\nKaina: {price} eur");
        Filler();
    }

    private static void SixthTask(string fullName, int age, string position, string email, string phoneNumber)
    {
        Console.WriteLine("============== VIZITINE ==============");
        Console.WriteLine($"Vardas: {fullName}");
        Console.WriteLine($"Amzius: {age}");
        Console.WriteLine($"Pareigos: {position}");
        Console.WriteLine($"E. Pastas: {email}");
        Console.WriteLine($"Tel.: {phoneNumber}");
        Console.WriteLine("======================================");
        Filler();
    }

    private static void ChangeForegroundColor()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void ChangeForegroundColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
}