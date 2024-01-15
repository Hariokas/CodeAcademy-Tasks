namespace CodeAcademyNET8.Advanced___OOP.Classes.Generics;

internal class Generator
{
    public static void Show<T>(T input)
    {
        Console.WriteLine(input?.ToString() ?? "null");
    }
}