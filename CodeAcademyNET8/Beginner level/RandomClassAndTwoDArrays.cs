using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

internal static class RandomClassAndTwoDArrays
{
    public static void RunTasks()
    {
        //Task1_1();
        //Task1_2();
        //Task1_3();
        //Task1_4();
        //Task1_5();
        Task3_1();
    }

    private static void Task1_1()
    {
        var minValue = 0;
        var maxValue = 11;
        var numberCount = 10;

        var randomInts = GenerateRandomIntegers(minValue, maxValue, numberCount);

        Console.WriteLine($"{numberCount} integer array of numbers in between of {minValue} and {maxValue}:");
        Console.WriteLine(JoinArray(randomInts));

        Separator();
    }

    private static int[] GenerateRandomIntegers(int minValue, int maxValue, int numberCount)
    {
        var rnd = new Random();
        var result = new int[numberCount];

        for (var i = 0; i < numberCount; i++)
            result[i] = rnd.Next(minValue, maxValue);

        return result;
    }

    private static void Task1_2()
    {
        var boolCount = 10;

        var randomInts = GenerateRandomBools(boolCount);

        Console.WriteLine($"{boolCount} bool array:");
        Console.WriteLine(JoinArray(randomInts));

        Separator();
    }

    private static bool[] GenerateRandomBools(int numberCount)
    {
        var rnd = new Random();
        var result = new bool[numberCount];

        for (var i = 0; i < numberCount; i++)
            result[i] = rnd.Next(0, 2) == 1;

        return result;
    }

    private static void Task1_3()
    {
        var stringLenght = 10;

        var randomString = GenerateRandomUpperCaseString(stringLenght);

        Console.WriteLine($"{stringLenght} random char array:");
        Console.WriteLine(JoinArray(randomString));

        Separator();
    }

    private static string GenerateRandomUpperCaseString(int length)
    {
        var chars = new char[length];
        var rnd = new Random();

        for (var i = 0; i < length; i++)
            chars[i] = (char)('A' + rnd.Next(0, 26));

        return new string(chars);
    }

    private static void Task1_4()
    {
        var length = 100;
        var sumOfRandomInts = SumOfRandomInts(length);

        Console.WriteLine($"Sum of {length} random integers: {sumOfRandomInts}");

        Separator();
    }

    private static int SumOfRandomInts(int length)
    {
        var sum = 0;
        var rnd = new Random();

        for (var i = 0; i < length; i++) sum += rnd.Next(1, 7);

        return sum;
    }

    private static void Task1_5()
    {
        var rnd = new Random();
        var number = rnd.Next(1, 101);

        Console.Write("Guess the number: ");

        while (true)
        {
            var guess = int.Parse(Console.ReadLine());
            if (guess == number)
                break;

            if (guess > number)
                Console.Write("Enter lower number: ");
            else if (guess < number)
                Console.Write("Enter higher number: ");
        }

        Console.WriteLine($"You've guessed correctly! The number was {number}");
        Separator();
    }

    private static void Task3_1()
    {
        var matrix = GenerateRandomMatrix();
        DisplayMatrix(matrix);
        CalculateAndDisplayPercentages(matrix);
        DrawLotteryAndMarkTicket(matrix);

        Separator();
    }

    private static void CalculateAndDisplayPercentages(int[,] matrix)
    {
        var totalNumbers = matrix.GetLength(0) * matrix.GetLength(1);
        var evenCount = 0;

        foreach (var item in matrix)
            if (item % 2 == 0)
                evenCount++;

        var evenPercentage = Math.Round((double)evenCount / totalNumbers * 100, 2);
        var oddPercentage = Math.Round(100 - evenPercentage, 2);

        Console.WriteLine($"Even Numbers: {evenPercentage}%");
        Console.WriteLine($"Odd Numbers: {oddPercentage}%");
    }

    private static void DisplayMatrix(int[,] matrix)
    {
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j]}\t");

            Console.WriteLine();
        }
    }

    private static int[,] GenerateRandomMatrix()
    {
        var rnd = new Random();
        var rows = rnd.Next(1, 9);
        var cols = rnd.Next(1, 9);
        var matrix = new int[rows, cols];
        var usedNumbers = Enumerable.Range(0, cols).Select(x => new bool[10]).ToArray();

        for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
        {
            int num;
            do
            {
                num = rnd.Next(1, 11) + j * 10;
            } while (usedNumbers[j][num % 10]);

            usedNumbers[j][num % 10] = true;
            matrix[i, j] = num;
        }

        return matrix;
    }

    private static void DrawLotteryAndMarkTicket(int[,] ticket)
    {
        Console.WriteLine();
        var (drawnNumbers, drawCounts) = DrawNumbers(ticket);
        Console.WriteLine($"\nDrawn Numbers: {JoinArray(drawnNumbers)}");

        Console.WriteLine("\nNumber of draws before each number was matched:");
        for (var i = 0; i < ticket.GetLength(0); i++)
        for (var j = 0; j < ticket.GetLength(1); j++)
        {
            var number = ticket[i, j];
            var drawCount = drawCounts[Array.IndexOf(drawnNumbers, number)];
            Console.WriteLine($"Number {number}: {drawCount} draws");
        }

        Console.WriteLine("\nTicket with marked drawn numbers:");
        MarkAndDisplayTicket(ticket, drawnNumbers, true);

        Console.WriteLine("\nTicket with X for drawn numbers:");
        MarkAndDisplayTicket(ticket, drawnNumbers, false);

        Separator();
    }

    private static (int[], int[]) DrawNumbers(int[,] matrix)
    {
        var rnd = new Random();
        var flatMatrix = matrix.Cast<int>().ToArray();
        var drawnNumbers = new int[flatMatrix.Length];
        var drawCounts = new int[flatMatrix.Length];
        var usedNumbers = new bool[81];

        for (var i = 0; i < flatMatrix.Length; i++)
        {
            int num;
            var draws = 0;
            do
            {
                num = rnd.Next(1, 81);
                draws++;
            } while (usedNumbers[num] || !flatMatrix.Contains(num));

            usedNumbers[num] = true;
            drawnNumbers[i] = num;
            drawCounts[i] = draws;
        }

        return (drawnNumbers, drawCounts);
    }

    private static void MarkAndDisplayTicket(int[,] ticket, int[] drawnNumbers, bool mark)
    {
        var markedTicket = (int[,])ticket.Clone();
        for (var i = 0; i < markedTicket.GetLength(0); i++)
        {
            for (var j = 0; j < markedTicket.GetLength(1); j++)
                if (drawnNumbers.Contains(markedTicket[i, j]))
                {
                    if (mark)
                        Console.Write($"[{markedTicket[i, j]}]\t");
                    else
                        Console.Write("X\t");
                }
                else
                {
                    Console.Write($"{markedTicket[i, j]}\t");
                }

            Console.WriteLine();
        }
    }
}