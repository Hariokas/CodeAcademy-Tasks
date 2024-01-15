using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

public static class Lecture6
{
    public static void RunTasks()
    {
        Task_1_1();
        Task_1_2();
        Task_1_3();
        Task_2_1();
        Task_2_2();
        Task_2_3();
        Task_3_1();
        Task_3_2();
        Task_3_3();
        Task_4_1();
        Task_4_2();
    }

    public static void Task_1_1()
    {
        var i = 1;
        while (i <= 5)
        {
            Console.Write($"{i} ->");
            var j = 1;
            while (j <= 5)
            {
                Console.Write($" {j}");
                j++;
            }

            i++;
            Console.WriteLine();
        }

        Separator();
    }

    public static void Task_1_2()
    {
        var i = 1;
        while (i <= 10)
        {
            if (i % 2 == 0)
                Console.WriteLine($"{i}");

            var j = 1;
            while (j <= 10)
            {
                if (j % 2 != 0)
                    Console.Write($" {j}");

                j++;
            }

            i++;
            Console.WriteLine();
        }

        Separator();
    }

    public static void Task_1_3()
    {
        while (true)
        {
            Console.Write("Enter a number lower than 100: ");
            var input = int.Parse(Console.ReadLine());
            Console.WriteLine($"Number you have entered: {input}");

            if (input > 100)
                break;

            while (true)
            {
                Console.Write("Enter a positive number: ");
                var positiveInput = int.Parse(Console.ReadLine());
                Console.WriteLine($"Number you have entered: {positiveInput}");

                if (positiveInput < 0)
                    break;
            }
        }

        Separator();
    }

    public static void Task_2_1()
    {
        while (true)
        {
            Console.Write("Enter a number to calculate factorial: ");
            var input = int.Parse(Console.ReadLine());

            if (input < 0)
            {
                Console.WriteLine("A negative number was entered, exiting cycle");
                break;
            }

            var factorial = 1;
            var i = input;

            while (i > 0)
            {
                factorial *= i;
                i--;
            }

            if (factorial != 0)
                Console.WriteLine($"Factorial of {input} is {factorial}");
        }

        Separator();
    }

    public static void Task_2_2()
    {
        Console.Write("Enter a number to split it: ");
        var input = Console.ReadLine()?.Trim().Replace(" ", string.Empty) ?? string.Empty;

        var i = 0;
        var charArr = new char[input.Length];

        while (i < input.Length)
        {
            charArr[i] = input.ToCharArray()[i];
            i++;
        }

        Console.WriteLine($"Split numbers are: {string.Join(", ", charArr)}");

        Separator();
    }

    public static void Task_2_3()
    {
        Console.WriteLine("How many lines you would like to print?: ");
        var lineCount = int.Parse(Console.ReadLine());

        var i = 1;
        while (i < lineCount)
        {
            var j = i;
            while (j > 0)
            {
                if (i == j && j == 1)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(".");
                j--;
            }

            Console.WriteLine();
            i++;
        }

        Separator();
    }

    public static void Task_3_1()
    {
        var number = 123456;
        while (true)
        {
            Console.Write("Guess the number: ");
            var guess = int.Parse(Console.ReadLine());
            if (guess == number)
                break;
        }

        Console.WriteLine($"You've guessed correctly! The number was {number}");
        Separator();
    }

    public static void Task_3_2()
    {
        Console.Write("Enter a number that you want to raise by a degree: ");
        var number = int.Parse(Console.ReadLine());
        Console.Write("Enter a degree you want to raise the number: ");
        var degree = int.Parse(Console.ReadLine());

        Console.WriteLine($"{number}^{degree}={Math.Pow(number, degree)}");
        Separator();
    }

    public static void Task_3_3()
    {
        Console.Write("Enter a number you want to print: ");
        var number = int.Parse(Console.ReadLine());
        Console.Write("Enter a number of groups: ");
        var groupCount = int.Parse(Console.ReadLine());

        var i = 0;
        while (i < groupCount)
        {
            var intStr = string.Empty;
            var j = 0;
            while (j <= i)
            {
                intStr += number;
                j++;
            }

            Console.Write($" -> {intStr}");
            i++;
        }

        Console.WriteLine();
        Separator();
    }

    public static void Task_4_1()
    {
        Console.WriteLine("How many lines you would like to print?: ");
        var lineCount = int.Parse(Console.ReadLine());

        var i = 1;
        while (i <= lineCount)
        {
            var j = i;
            while (j > 0)
            {
                Console.Write(i);
                j--;
            }

            Console.WriteLine();
            i++;
        }

        Separator();
    }

    public static void Task_4_2()
    {
        Console.Write("Enter the amount of money to withdraw: ");
        var amount = Convert.ToInt32(Console.ReadLine());

        var temp = amount;

        var maxBill = 50;
        while (amount > 0)
            if (amount >= maxBill)
            {
                Console.WriteLine("50 EUR ");
                amount -= maxBill;
            }
            else if (amount >= 20)
            {
                Console.WriteLine("20 EUR ");
                amount -= 20;
            }
            else if (amount >= 10)
            {
                Console.WriteLine("10 EUR ");
                amount -= 10;
            }
            else
            {
                Console.WriteLine($"{amount} EUR");
                amount = 0;
            }

        Console.WriteLine($"(the user has entered {temp} EUR.)");
        Separator();
    }
}