using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

internal class Lecture12
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
        //Task3_1();
        //Task3_2();
        //Task3_3();
        //Task3_4();
    }

    private static void Task1_1()
    {
        var input = new[] { 1, 2, 3 };
        Console.WriteLine($"Input: {string.Join(", ", input)}");
        var output = IntArrayToPow(input);
        Console.WriteLine($"Output: {string.Join(", ", output)}");

        Separator();
    }

    private static int[] IntArrayToPow(int[] input)
    {
        var result = new int[input.Length];

        for (var i = 0; i < input.Length; i++) result[i] = (int)Math.Pow(input[i], 2);

        return result;
    }

    private static void Task1_2()
    {
        var input = new[] { 1, 2, 3 };
        Console.WriteLine($"Input: {string.Join(", ", input)}");
        var output = IntArrayToSum(input);
        Console.WriteLine($"The sum of array is: {output}");

        Separator();
    }

    private static int IntArrayToSum(int[] input)
    {
        var result = 0;

        for (var i = 0; i < input.Length; i++) result += input[i];

        return result;
    }

    private static void Task1_3()
    {
        var input = new[] { 1, 2, 3 };
        Console.WriteLine($"Input: {string.Join(", ", input)}");
        var output = MaxArrayItem(input);
        Console.WriteLine($"The max from array is: {output}");

        Separator();
    }

    private static int MaxArrayItem(int[] input)
    {
        var max = int.MinValue;

        for (var i = 0; i < input.Length; i++)
            if (input[i] > max)
                max = input[i];

        return max;
    }

    private static void Task1_4()
    {
        var input = new[] { 1, 2, 3 };
        Console.WriteLine($"Input: {string.Join(", ", input)}");
        var output = IntArrayToReverse(input);
        Console.WriteLine($"The reverse array is: {string.Join(", ", output)}");

        Separator();
    }

    private static int[] IntArrayToReverse(int[] input)
    {
        var result = new int[input.Length];

        for (var i = 0; i < input.Length; i++) result[i] = input[input.Length - i - 1];

        return result.Reverse().ToArray();
    }

    private static void Task2_1()
    {
        var input = "hello";
        var output = StringToCharArray(input);
        Console.WriteLine($"[{input}] gets converted to [{string.Join(", ", output)}]");
        Separator();
    }

    private static char[] StringToCharArray(string input)
    {
        var charArray = new char[input.Length];

        for (var i = 0; i < charArray.Length; i++) charArray[i] = input[i];

        return charArray;
    }

    private static void Task2_2()
    {
        var input = "hello";
        var firstLetter = GetFirstLetter(input);
        Console.WriteLine($"First letter of [{input}] is [{string.Join(string.Empty, firstLetter)}]");
        Separator();
    }

    private static char[] GetFirstLetter(string sentence)
    {
        return sentence.First().ToString().ToCharArray() ?? new[] { ' ' };
    }

    private static void Task2_3()
    {
        var input = "hello";
        var lastLetter = GetLastLetter(input);
        Console.WriteLine($"Last letter of [{input}] is [{string.Join(string.Empty, lastLetter)}]");
        Separator();
    }

    private static char[] GetLastLetter(string sentence)
    {
        return sentence.Last().ToString().ToCharArray() ?? new[] { ' ' };
    }


    // Advanced tasks
    private static void Task3_1()
    {
        var intArr = new int[10];
        for (var i = 0; i < intArr.Length; i++)
            intArr[i] = new Random().Next(0, 41);

        var ascendingArray = SortArrayAscending(intArr);

        Console.WriteLine($"Unsorted array: [{string.Join(", ", intArr)}]");
        Console.WriteLine($"Ascending array: [{string.Join(", ", ascendingArray)}]");

        Separator();
    }

    public static int[] SortArrayAscending(int[] array)
    {
        int temp;
        var sortedArray = (int[])array.Clone();
        for (var i = 0; i < sortedArray.Length - 1; i++)
        for (var j = 0; j < sortedArray.Length - i - 1; j++)
            if (sortedArray[j] > sortedArray[j + 1])
            {
                // Swap the elements
                temp = sortedArray[j];
                sortedArray[j] = sortedArray[j + 1];
                sortedArray[j + 1] = temp;
            }

        return sortedArray;
    }

    private static void Task3_2()
    {
        var intArr = new int[10];
        for (var i = 0; i < intArr.Length; i++)
            intArr[i] = new Random().Next(0, 41);

        var descendingArray = SortArrayDescending(intArr);

        Console.WriteLine($"Unsorted array: [{string.Join(", ", intArr)}]");
        Console.WriteLine($"Descending array: [{string.Join(", ", descendingArray)}]");

        Separator();
    }

    public static int[] SortArrayDescending(int[] array)
    {
        int temp;
        var sortedArray = (int[])array.Clone();
        for (var i = 0; i < sortedArray.Length - 1; i++)
        for (var j = 0; j < sortedArray.Length - i - 1; j++)
            if (sortedArray[j] < sortedArray[j + 1])
            {
                // Swap the elements
                temp = sortedArray[j];
                sortedArray[j] = sortedArray[j + 1];
                sortedArray[j + 1] = temp;
            }

        return sortedArray;
    }

    private static void Task3_3()
    {
        var input = new[] { 1, 2, 3 };
        var newElement = 4;
        var output = AddArrayElement(input, newElement);

        Console.WriteLine(
            $"Adding [{newElement}] to [{string.Join(", ", input)}] result: [{string.Join(", ", output)}]");

        Separator();
    }

    private static int[] AddArrayElement(int[] array, int elementToAdd)
    {
        var newArr = new int[array.Length + 1];

        for (var i = 0; i < array.Length; i++) newArr[i] = array[i];
        newArr[array.Length] = elementToAdd;

        return newArr;
    }

    private static void Task3_4()
    {
        var input = new[] { 1, 2, 3, 4, 5, 6 };
        var removeIndex = 4;
        var output = RemoveArrayElement(input, removeIndex);

        Console.WriteLine(
            $"Removing element with index [{removeIndex}] from [{string.Join(", ", input)}] result: [{string.Join(", ", output)}]");
        Separator();
    }

    private static int[] RemoveArrayElement(int[] array, int indexToRemove)
    {
        if (indexToRemove < 0 || indexToRemove >= array.Length)
            throw new ArgumentOutOfRangeException(nameof(indexToRemove),
                "Index must be within the bounds of the array.");

        var newArr = new int[array.Length - 1];

        for (var i = 0; i < indexToRemove; i++) newArr[i] = array[i];

        for (var i = indexToRemove + 1; i < array.Length; i++) newArr[i - 1] = array[i];

        return newArr;
    }
}