namespace CodeAcademyNET8;

public static class Helpers
{
    private static readonly string Line = new('-', 40);

    public static void Filler()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }

    public static void Separator()
    {
        Console.WriteLine(Line);
    }

    public static int[] GetRandomNumberArr(int minValue, int maxValue, int arraySize)
    {
        if (arraySize < 1 || minValue > maxValue)
            return Array.Empty<int>();

        var intArr = new int[arraySize];
        for (var i = 0; i < intArr.Length; i++)
            intArr[i] = new Random().Next(minValue, maxValue);

        return intArr;
    }

    public static string JoinArray<T>(IEnumerable<T> input, string separator = ", ")
    {
        return string.Join(separator, input);
    }
}