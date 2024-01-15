using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

public static class Lecture3
{
    public static void RunTasks()
    {
        Task_1_1(101);
        Task_1_2(7);
        SecondTaskFirstPart(20);
        SecondTaskSecondPart(15);
        ThirdTaskFirstPart(17);
        ThirdTaskSecondPart("123456");
        FourthTask(27);
        FifthTask(2024);
        SixthTask(15);
        SeventhTaskFirstPart(15, -3);
        SeventhTaskSecondPart(15, 15, 38);
        EightTaskFirstPart(10, 11, -21);
        EightTaskSecondPart(2023, 3);
        NinthTask(2, 2, 2);
        TenthTask();
    }

    private static void Task_1_1(int inputNumber)
    {
        Console.WriteLine($"Your inputNumber is: {inputNumber}");
        if (inputNumber > 100)
            Console.WriteLine("Input is greater than 100");
        else if (inputNumber == 100)
            Console.WriteLine("Input is equal to 100");
        else
            Console.WriteLine("Input is lower than 100");

        Separator();
    }

    private static void Task_1_2(int dayNumber)
    {
        Console.WriteLine($"{dayNumber} --> {((DayOfWeek)(dayNumber % 7)).ToString()}");
        Separator();
    }

    private static void SecondTaskFirstPart(int inputNumber)
    {
        if (inputNumber % 2 == 0)
            Console.WriteLine($"Number {inputNumber} is even");

        if (inputNumber % 5 == 0)
            Console.WriteLine($"Number {inputNumber} is divisible by 5");

        Separator();
    }

    private static void SecondTaskSecondPart(int inputTemperature)
    {
        Console.Write("The weather is: ");

        if (inputTemperature < 0)
            Console.WriteLine("Cold");

        if (inputTemperature >= 0 && inputTemperature <= 20)
            Console.WriteLine("Cool");

        if (inputTemperature > 20)
            Console.WriteLine("Hot");
        Separator();
    }

    private static void ThirdTaskFirstPart(int wokeUpAt)
    {
        Console.Write($"You woke up at: {wokeUpAt}; ");

        if (wokeUpAt >= 0 && wokeUpAt < 12)
            Console.WriteLine("Good day!");

        if (wokeUpAt >= 12 && wokeUpAt <= 18)
            Console.WriteLine("Good afternoon!");

        if (wokeUpAt > 18 && wokeUpAt <= 24)
            Console.WriteLine("Good evening!");

        Separator();
    }

    private static void ThirdTaskSecondPart(string password)
    {
        var mySuperSecurePassword = "changeme";

        if (password == mySuperSecurePassword || password == "Mellon")
            Console.WriteLine("You have successfully logged in.");
        else if (password == "01101001 01101110")
            Console.WriteLine("Hacked...");
        else
            Console.WriteLine($"Password [{password}] is incorrect, please try again...");

        Separator();
    }

    private static void FourthTask(int age)
    {
        if (age < 18)
            Console.WriteLine("You are a minor");
        else if (age >= 18 && age <= 65)
            Console.WriteLine("You are an adult");
        else
            Console.WriteLine("You are eligible for the Senior Citizen promotion");

        Separator();
    }

    private static void FifthTask(int yearToCheck)
    {
        if ((yearToCheck % 4 == 0 && yearToCheck % 100 != 0) || yearToCheck % 400 == 0)
            Console.WriteLine($"Year {yearToCheck} is a leap year");
        else
            Console.WriteLine($"Year {yearToCheck} is not a leap year");

        Separator();
    }

    private static void SixthTask(int bazinga)
    {
        if (bazinga % 3 == 0 && bazinga % 5 == 0)
            Console.WriteLine("BazingaPop");
        else if (bazinga % 3 == 0 && bazinga % 5 != 0)
            Console.WriteLine("Bazinga");
        else if (bazinga % 3 != 0 && bazinga % 5 == 0)
            Console.WriteLine("Pop");
        else
            Console.WriteLine(bazinga);

        Separator();
    }

    private static void SeventhTaskFirstPart(int firstNumber, int secondNumber)
    {
        if (firstNumber > 0 && secondNumber > 0)
            Console.WriteLine("Both numbers are positive");
        else if (firstNumber > 0 || secondNumber > 0)
            Console.WriteLine("Only one number is positive");
        else
            Console.WriteLine("Neither number is positive");

        Separator();
    }

    private static void SeventhTaskSecondPart(int firstNumber, int secondNumber, int thirdNumber)
    {
        if (firstNumber == secondNumber && secondNumber == thirdNumber)
            Console.WriteLine("All numbers are equal");
        else if (firstNumber == secondNumber || firstNumber == thirdNumber || secondNumber == thirdNumber)
            Console.WriteLine("Two numbers are equal");
        else
            Console.WriteLine("None of the numbers are equal");

        Separator();
    }

    private static void EightTaskFirstPart(int a, int b, int c)
    {
        if ((a > 0 && b > 0) || (a > 0 && c > 0) || (b > 0 && c > 0))
        {
            var sum = a + b + c;
            Console.WriteLine($"The sum of the numbers is: {sum}");
        }
        else
        {
            Console.WriteLine("Could not calculate sum.");
        }

        Separator();
    }

    private static void EightTaskSecondPart(int year, int month)
    {
        switch (month)
        {
            case 1: // January
            case 2: // February
            case 3: // March
                Console.WriteLine("Cold period");
                break;
            case 6: // June
            case 7: // July
            case 8: // August
                Console.WriteLine("Hot period");
                break;
            default:
                Console.WriteLine("Medium period month");
                break;
        }

        Separator();
    }

    private static void NinthTask(int a, int b, int c)
    {
        if (a + b > c && a + c > b && b + c > a)
            Console.WriteLine("Can form a triangle.");
        else
            Console.WriteLine("Cannot form a triangle.");

        Separator();
    }

    private static void TenthTask()
    {
        var productOneName = "orange";
        var productOnePrice = 0.49;

        var productTwoName = "milkshake";
        var productTwoPrice = 1.79;

        var productThreeName = "banana";
        var productThreePrice = 4.99;

        Console.WriteLine($"{productOneName} -> {productOnePrice} EUR");
        Console.WriteLine($"{productTwoName} -> {productTwoPrice} EUR");
        Console.WriteLine($"{productThreeName} -> {productThreePrice} EUR");

        Console.WriteLine("Enter the name of the first product: ");
        var basketProductOne = Console.ReadLine().Trim().ToLower();

        Console.WriteLine("Enter the name of the second product: ");
        var basketProductTwo = Console.ReadLine().Trim().ToLower();

        double basketTotal = 0;
        double discount = 0;
        double basketOnePrice = 0;
        double basketTwoPrice = 0;

        if (basketProductOne == productOneName)
        {
            basketTotal += productOnePrice;
            basketOnePrice = productOnePrice;
        }

        if (basketProductTwo == productOneName)
        {
            basketTotal += productOnePrice;
            basketTwoPrice = productOnePrice;
        }

        if (basketProductOne == productTwoName)
        {
            basketTotal += productTwoPrice;
            basketOnePrice = productTwoPrice;
        }

        if (basketProductTwo == productTwoName)
        {
            basketTotal += productTwoPrice;
            basketTwoPrice = productTwoPrice;
        }

        if (basketProductOne == productThreeName)
        {
            basketTotal += productThreePrice;
            basketOnePrice = productThreePrice;
        }

        if (basketProductTwo == productThreeName)
        {
            basketTotal += productThreePrice;
            basketTwoPrice = productThreePrice;
        }

        //Additional part
        if (basketProductOne == basketProductTwo)
            discount += Math.Round(basketTotal * 0.1, 2);

        Console.WriteLine("Do you have a loyalty card? (yes/no)");
        var cardResponse = Console.ReadLine().Trim().ToLower();

        if (cardResponse == "yes")
            discount += Math.Round(basketTotal * 0.1, 2);

        basketTotal = Math.Round(basketTotal - discount, 2);

        Console.WriteLine("You bought:");
        Console.WriteLine($"\t{basketProductOne} {basketOnePrice} EUR");
        Console.WriteLine($"\t{basketProductTwo} {basketTwoPrice} EUR");
        Console.WriteLine("Price before discount:");
        Console.WriteLine($"\t{basketTotal + discount} EUR");
        Console.WriteLine("Total discount applied:");
        Console.WriteLine($"\t{discount} EUR");
        Console.WriteLine("Total price:");
        Console.WriteLine($"\t{basketTotal} EUR");

        Separator();
    }
}