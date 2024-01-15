using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

internal static class Lecture7
{
    public static void RunTasks()
    {
        Task_5_1();
        Task_5_2();
        Task_5_3();
    }

    public static void Task_5_1()
    {
        string input;
        var sum = 0;
        do
        {
            Console.Write("Write a number you want to add (type \"finish\" to exit): ");
            input = Console.ReadLine() ?? string.Empty;

            if (input.ToLower() != "finish")
                sum += int.Parse(input);
        } while (input.ToLower() != "finish");

        Console.WriteLine($"The total sum is: {sum}");
        Separator();
    }

    public static void Task_5_2()
    {
        var pwd = "LETMEOUT";
        var input = string.Empty;

        do
        {
            Console.Write("So, you want to get out of here? What's the password?: ");
            input = Console.ReadLine();
        } while (input != pwd);

        Separator();
    }

    public static void Task_5_3()
    {
        var rnd = new Random().Next(1, 100);
        var guess = 0;

        Console.WriteLine("Guess the number between the 1 and 100!");
        do
        {
            Console.Write("Your input: ");
            int.TryParse(Console.ReadLine(), out guess);

            if (guess > rnd) Console.WriteLine("Go lower!");
            if (guess < rnd) Console.WriteLine("Go higher!");
        } while (guess != rnd);

        Console.WriteLine("Congratulations, you've won!");
        Separator();
    }
}