using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

internal static class Lecture9
{
    public static void RunTasks()
    {
        Task_1_1();
        Task_1_2();
        Task_1_3();
        Task_2_1();
        Task_2_2();
        Task_2_3();
    }

    private static void Task_1_1()
    {
        var firstNumber = 100;
        var secondNumber = 40;

        Console.WriteLine($"Value of firstNumber before swapping: [{firstNumber}]");
        Console.WriteLine($"Value of secondNumber before swapping: [{secondNumber}]");
        Console.WriteLine("Swapping integers...");
        SwapIntegers(ref firstNumber, ref secondNumber);
        Console.WriteLine($"Value of firstNumber after swapping: [{firstNumber}]");
        Console.WriteLine($"Value of secondNumber after swapping: [{secondNumber}]");

        Separator();
    }

    private static void SwapIntegers(ref int a, ref int b)
    {
        (a, b) = (b, a);
    }

    private static void Task_1_2()
    {
        var n = 50;
        var incrementCount = 20;
        Console.WriteLine($"Incrementing number [{n}] by [{incrementCount}] times");
        IncrementByN(ref n, incrementCount);
        Console.WriteLine($"Incremented number is [{n}]");

        Separator();
    }

    private static void IncrementByN(ref int n, int incrementCount)
    {
        n += incrementCount;
    }

    private static void Task_1_3()
    {
        var chaos = "                 ThiS is pUre ChaOS   ";
        Console.WriteLine(chaos);
        TrimAndCapitalize(ref chaos);
        Console.WriteLine(chaos);

        Separator();
    }

    private static void TrimAndCapitalize(ref string input)
    {
        input = input.Trim();

        if (input.Length > 0)
            input = $"{input[0].ToString().ToUpper()}{input.ToLower()[1..]}";
    }

    private static void Task_2_1()
    {
        GetUserData(out var firstName, out var lastName);
        Console.WriteLine($"User's full name is {firstName} {lastName}");

        Separator();
    }

    private static void GetUserData(out string firstName, out string lastName)
    {
        Console.Write("What is your first name?: ");
        firstName = Console.ReadLine() ?? string.Empty;
        Console.Write("What is your last name?: ");
        lastName = Console.ReadLine() ?? string.Empty;
    }

    private static void Task_2_2()
    {
        var success = GetNumberHigherThanHundred(out var number);

        if (success)
            Console.WriteLine($"Great. Your number {number} seems to be higher than a hundred.");
        else
            Console.WriteLine("Something went wrong (。﹏。)");

        Separator();
    }

    private static bool GetNumberHigherThanHundred(out int number)
    {
        var numberIsHigherThanHundred = false;
        do
        {
            Console.Write("Enter a number: ");

            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number > 100)
                    numberIsHigherThanHundred = true;
            }
            else
            {
                Console.WriteLine("It seems you have entered something wrong (ㆆ_ㆆ)");
            }
        } while (!numberIsHigherThanHundred);

        return numberIsHigherThanHundred;
    }

    public static void Task_2_3()
    {
        var number1 = 5;
        var number2 = 3;

        var success = Divide(number1, number2, out var quotient, out var remainder);

        if (success)
            Console.WriteLine($"{number1}/{number2} = [{quotient}].[{remainder}]");
        else
            Console.WriteLine($"Failed to divide [{number1}] by [{number2}]");

        Separator();
    }

    private static bool Divide(double n1, double n2, out decimal quotient, out decimal remainder)
    {
        if (n2 == 0)
        {
            Console.WriteLine("Division by 0 is not allowed.");
            quotient = 0;
            remainder = 0;
            return false;
        }

        var result = n1 / n2;
        var decimalIndex = result.ToString().IndexOf('.');

        decimal.TryParse(result.ToString().Substring(0, decimalIndex), out quotient);
        decimal.TryParse(result.ToString().Substring(decimalIndex + 1), out remainder);

        return true;
    }
}