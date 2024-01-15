using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

internal static class ForeachAndMultidimensionalArrays
{
    public static void RunTasks()
    {
        //Task1_1();
        //Task1_2();
        //Task1_3();
        //Task1_4();
        //Task2_1();
        //Task2_2();
        //Task2_3();
        //Task2_4();
        //Task3_1();
        //Task3_2();
        //Task3_3();
        Task3_4();
    }

    private static void Task1_1()
    {
        var intArr = GetRandomNumberArr(0, 25, 5);
        var average = GetAverage(intArr);

        Console.WriteLine($"Average of numbers [{JoinArray(intArr)}] is [{average}]");

        Separator();
    }

    private static double GetAverage(int[] input)
    {
        var result = 0.0;

        foreach (var item in input)
            result += item;

        result /= input.Length;
        return result;
    }

    private static void Task1_2()
    {
        var input = GetRandomNumberArr(-100, 101, 10);
        var output = GetPositiveNumbers(input);

        Console.WriteLine($"Original array: [{JoinArray(input)}]");
        Console.WriteLine($"Array with positive numbers only: [{JoinArray(output)}]");

        Separator();
    }

    private static int[] GetPositiveNumbers(int[] input)
    {
        var positiveCount = 0;

        foreach (var item in input)
            if (item > 0)
                positiveCount++;

        if (positiveCount < 1)
            return Array.Empty<int>();

        var positiveArr = new int[positiveCount];
        var index = 0;

        foreach (var item in input)
            if (item > 0)
            {
                positiveArr[index] = item;
                index++;
            }

        return positiveArr;
    }

    private static void Task1_3()
    {
        var input = GetRandomNumberArr(1, 101, 5);
        var output = GetVatAmmount(input);

        Console.WriteLine($"Array of [{JoinArray(input)}] gets the VAT of [{output} \u00a7]");
        Separator();
    }

    private static double GetVatAmmount(int[] input)
    {
        const int vat = 15;
        var result = 0.0;

        foreach (var item in input)
            result += item;

        return Math.Round(result / 100 * vat, 2);
    }

    private static void Task1_4()
    {
        var input = "This is some text where the majority will be removed.";
        var output = GetStringLongerThanFive(input);

        Console.WriteLine($"[{input}] got chopped to [{JoinArray(output, " ")}]");

        Separator();
    }

    private static string[] GetStringLongerThanFive(string input)
    {
        if (string.IsNullOrEmpty(input))
            return Array.Empty<string>();

        var wordCount = 0;
        foreach (var item in input.Split(" "))
            if (item.Trim().Length >= 5)
                wordCount++;

        if (wordCount == 0)
            return Array.Empty<string>();

        var result = new string[wordCount];
        var index = 0;

        foreach (var item in input.Split(" "))
        {
            var trimmedItem = item.Trim();
            if (trimmedItem.Length < 5) continue;

            result[index] = trimmedItem;
            index++;
        }

        return result;
    }

    private static void Task2_1()
    {
        var matrix = CreateAndPopulateMatrix(3, 3);

        Console.WriteLine("Populated matrix:");

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j]}\t");

            Console.WriteLine();
        }

        Separator();
    }

    private static int[,] CreateAndPopulateMatrix(int rows, int cols)
    {
        if (rows < 1 || cols < 1)
            return new int[0, 0];

        var matrix = new int[rows, cols];

        Console.WriteLine($"Enter the numbers for the matrix ({rows * cols} numbers, row by row)");
        for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
        {
            int.TryParse(Console.ReadLine(), out var number);
            matrix[i, j] = number;
        }

        return matrix;
    }

    private static void Task2_2()
    {
        var matrix = new[,]
        {
            { 6, 7, 1 },
            { 7, 0, 8 },
            { 8, 1, 9 }
        };

        var duplicates = GetDuplicateNumbers(matrix);

        Console.WriteLine("Original array:");
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j]}\t");

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine($"Duplicates found: [{JoinArray(duplicates)}]");

        Separator();
    }

    private static int[] GetDuplicateNumbers(int[,] input)
    {
        var unique = new HashSet<int>();
        var duplicates = new HashSet<int>();

        for (var i = 0; i < input.GetLength(0); i++)
        for (var j = 0; j < input.GetLength(1); j++)
            if (unique.Contains(input[i, j]))
                duplicates.Add(input[i, j]);
            else
                unique.Add(input[i, j]);

        return duplicates.ToArray();
    }

    private static void Task2_3()
    {
        var matrix = new[,]
        {
            { "banana", "apple", "carrot" },
            { "carrot", "potato", "orange" },
            { "potato", "cabbage", "helicopter" }
        };

        var duplicates = GetDuplicateStrings(matrix);

        Console.WriteLine("Original array:");
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j]}\t");

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine($"Duplicates found: [{JoinArray(duplicates)}]");

        Separator();
    }

    private static string[] GetDuplicateStrings(string[,] input)
    {
        var unique = new HashSet<string>();
        var duplicates = new HashSet<string>();

        for (var i = 0; i < input.GetLength(0); i++)
        for (var j = 0; j < input.GetLength(1); j++)
            if (unique.Contains(input[i, j]))
                duplicates.Add(input[i, j]);
            else
                unique.Add(input[i, j]);

        return duplicates.ToArray();
    }

    private static void Task2_4()
    {
        AddMatrices();
        Separator();
    }

    private static void AddMatrices()
    {
        int[,] aMatrix =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        int[,] bMatrix =
        {
            { 1 },
            { 1 },
            { 1 }
        };

        var result = new int[3, 3];

        for (var i = 0; i < aMatrix.GetLength(0); i++)
        for (var j = 0; j < aMatrix.GetLength(1); j++)
            result[i, j] = aMatrix[i, j] + bMatrix[i, 0];

        Console.WriteLine("Matrix A:");
        for (var i = 0; i < aMatrix.GetLength(0); i++)
        {
            for (var j = 0; j < aMatrix.GetLength(1); j++)
                Console.Write(aMatrix[i, j] + " ");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Matrix B:");
        for (var i = 0; i < bMatrix.GetLength(0); i++)
        {
            for (var j = 0; j < bMatrix.GetLength(1); j++)
                Console.Write(bMatrix[i, j] + " ");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Result:");
        for (var i = 0; i < result.GetLength(0); i++)
        {
            for (var j = 0; j < result.GetLength(1); j++)
                Console.Write(result[i, j] + " ");
            Console.WriteLine();
        }
    }

    private static void Task3_1()
    {
        int[,] matrix =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 25, 9 }
        };

        Console.WriteLine("Original array:");
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j]}\t");

            Console.WriteLine();
        }

        FindAndDisplayMaxValueAndPos(matrix);
        Separator();
    }

    private static void FindAndDisplayMaxValueAndPos(int[,] input)
    {
        var maxNum = int.MinValue;
        var maxCol = -1;
        var maxRow = -1;

        for (var i = 0; i < input.GetLength(0); i++)
        for (var j = 0; j < input.GetLength(1); j++)
            if (input[i, j] > maxNum)
            {
                maxNum = input[i, j];
                maxRow = i;
                maxCol = j;
            }

        Console.WriteLine($"The maximum value is [{maxNum}] located at int[{maxCol}, {maxRow}]");
    }

    private static void Task3_2()
    {
        Console.WriteLine("Not implemented -- it's supposed to check if matrix is symmetrical");
        Separator();
    }

    private static void Task3_3()
    {
        Console.WriteLine(
            "Not implemented -- it's supposed to create a 2d array and populate with animal name, type, coat color and behaviour");
        Separator();
    }

    private static void Task3_4() // Print a plus! 🔥🔥🔥
    {
        var charMatrix = new char[4, 4];

        var colCount = charMatrix.GetLength(0);
        var rowCount = charMatrix.GetLength(1);

        for (var i = 0; i < colCount; i++)
        for (var j = 0; j < rowCount; j++)
            if ((i == 0 && j == 0)
                || (i == colCount - 1 && j == rowCount - 1)
                || (i == colCount - 1 && j == 0)
                || (i == 0 && j == rowCount - 1))
                charMatrix[i, j] = ' ';
            else
                charMatrix[i, j] = '*';

        for (var i = 0; i < colCount; i++)
        {
            for (var j = 0; j < rowCount; j++)
                Console.Write(charMatrix[i, j]);

            Console.WriteLine();
        }


        Separator();
    }
}