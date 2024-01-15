using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

internal static class Lecture8
{
    public static void RunTasks()
    {
        //Task_1_1();
        //Task_1_2();
        //Task_1_3();
        //Task_2_1();
        //Task_2_2();
        //Task_2_3();
        //Task_2_4();
        //Task_3_1();
        Task_3_2();
    }

    public static void Task_1_1()
    {
        if (IsPasswordValid("ThisIsQuiteALongPassword"))
            Console.WriteLine("Password is valid.");
        else
            Console.WriteLine("Password is not valid.");

        Separator();
    }

    private static bool IsPasswordValid(string password)
    {
        return password.Length > 8;
    }

    public static void Task_1_2()
    {
        if (IsEmailValid("address@email.com"))
            Console.WriteLine("Email is valid.");
        else
            Console.WriteLine("Email is not valid.");

        Separator();
    }

    private static bool IsEmailValid(string email)
    {
        return email.Contains('@') && email.Contains('.');
    }

    public static void Task_1_3()
    {
        var dollars = 25.78;
        var euros = ConvertToEuros(dollars);

        Console.WriteLine($"{dollars} dollars is {euros} EUR");

        Separator();
    }

    private static double ConvertToEuros(double dollarAmount)
    {
        const double exchangeRate = 0.85;
        return dollarAmount * exchangeRate;
    }

    public static void Task_2_1()
    {
        var firstName = "John";
        var lastName = "Doe";
        var initials = GetInitials(firstName, lastName);

        Console.WriteLine($"Initials of {firstName} {lastName} -> {initials}");
        Separator();
    }

    private static string GetInitials(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            return string.Empty;

        return $"{firstName[0]}{lastName[0]}";
    }

    public static void Task_2_2()
    {
        var radius = 7.2;
        var height = 11.7;
        var volume = CalculateCylinderVolume(radius, height);

        Console.WriteLine($"Cylinder's radius: {radius}; height: {height}; volume: {volume};");
        Separator();
    }

    private static double CalculateCylinderVolume(double radius, double height)
    {
        return Math.PI * Math.Pow(radius, 2) * height;
    }

    public static void Task_2_3()
    {
        var number = 15;

        if (IsNumberEven(number))
            Console.WriteLine($"Number {number} is even");
        else
            Console.WriteLine($"Number {number} is not even");

        Separator();
    }

    private static bool IsNumberEven(int number)
    {
        return number % 2 == 0;
    }

    public static void Task_2_4()
    {
        var length = 18.3;
        var width = 12.8;
        var area = CalculateRectangleArea(length, width);

        Console.WriteLine($"Rectangle's n: {length}; width: {width}; area: {area};");
        Separator();
    }

    private static double CalculateRectangleArea(double length, double width)
    {
        return length * width;
    }

    public static void Task_3_1()
    {
        var number = 5;
        var factorial = CalculateFactorialRecursively(number);

        Console.WriteLine($"Factorial of {number} is {factorial}");
        Separator();
    }

    private static int CalculateFactorialRecursively(int number)
    {
        if (number <= 0)
            return 1;

        return number * CalculateFactorialRecursively(number - 1);
    }

    public static void Task_3_2()
    {
        var length = 10;
        var fibonacci = FibonacciSequence(length);
        Console.WriteLine($"Fibonacci number for n = {length} is {fibonacci}");
    }

    private static int FibonacciSequence(int n)
    {
        // Fi+2 = Fi+1 + Fi <- Basic formula
        // Fi = Fi-1 + Fi-2
        // Fib(n) = Fib(n-1) + Fib(n-2) for n > 1

        if (n <= 1) return n; //Fib0 == 0; Fib1 == 1
        return FibonacciSequence(n - 1) + FibonacciSequence(n - 2);
    }
}