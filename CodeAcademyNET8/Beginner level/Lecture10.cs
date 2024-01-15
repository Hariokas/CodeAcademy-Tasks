using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

internal static class Lecture10
{
    public static void RunTasks()
    {
        Task_1_1();
        Task_1_2();
        Task_1_3();
        Task_1_4();
        Task_1_5();
        Task_1_6();
    }

    private static void Task_1_1()
    {
        for (var i = 1; i <= 100; i++)
        for (var j = i; j % 2 == 0; j++)
            Console.WriteLine(i);

        Separator();
    }

    private static void Task_1_2()
    {
        var limit = 100;
        Console.WriteLine($"The counting limit is {limit}");

        for (var i = 1; i <= limit; i++)
            Console.Write($"{i} ");

        Console.WriteLine();
        Separator();
    }

    private static void Task_1_3()
    {
        var limit = 10;

        for (var i = 0; i <= limit; i++)
            Console.WriteLine($"Square of {i} is {i * i}");

        Separator();
    }

    private static void Task_1_4()
    {
        // Write a program that calculates the arithmetic mean of all numbers from 1 to n (n is user input) (mean => average)
        var input = 150;
        var sum = 0;

        for (var i = 1; i <= input; i++)
            sum += i;

        Console.WriteLine($"Arithmetic mean of [{sum}] is [{sum / input}]");
        Separator();
    }

    private static void Task_1_5()
    {
        // Write a program that prints a "column" of "*" characters, the height of which is an input from the user
        var height = 15;
        for (var i = 0; i <= height; i++)
            Console.WriteLine("*");

        Separator();
    }

    private static void Task_1_6()
    {
        // Write a program that prints all numbers that are divisible by 3 without remainder, from 1 to 100
        for (var i = 1; i <= 100; i++)
        for (var j = i; j % 3 == 0; j++)
            Console.WriteLine(i);

        Separator();
    }
}