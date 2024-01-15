using static CodeAcademyNET8.Helpers;
using CodeAcademyNET8.Advanced___OOP.Classes.Exceptions;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class Exceptions
{
    public static void RunTasks()
    {
        Task1();
        Task2();
        Task3();
        Task4();
    }

    private static void Task1()
    {
        string[] values =
        [
            "-1,035.77219",
            "1AFF",
            "1e-35",
            "168,654,291,635,592,999,999,999,999,999,999,999,999,999,999,999,999,999,999",
            "-17.455",
            "190.34001",
            "1.29e325"
        ];

        foreach (var value in values)
            try
            {
                var result = double.Parse(value);

                if (double.IsInfinity(result))
                    throw new OverflowException();

                Console.WriteLine($"Converted '{value}' to {result}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{value}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"'{value}' is outside the range of a Double.");
            }

        Separator();
    }

    private static void Task2()
    {
        try
        {
            // Declare an array of max index 4
            int[] arr = [1, 2, 3, 4, 5];

            // Display values of array elements
            for (var i = 0; i < arr.Length; i++) Console.WriteLine($"Element[{i}] = {arr[i]}");

            Console.WriteLine(arr[7]);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }

        Separator();
    }

    private static void Task3()
    {
        int[] arr = [19, 0, 75, 52];

        for (var i = 0; i < arr.Length; i++)
            try
            {
                Console.WriteLine(arr[i] / arr[i + 1]);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        Separator();
    }

    private static void Task4()
    {
        FileReader.ReadFile("X:\\Nope.lmao");
        Separator();
    }
}