namespace CodeAcademyNET8.Advanced___OOP.Classes.Generics;

internal class Type
{
    public static void GetType<T1, T2>(T1 type1, T2 type2)
    {
        Console.WriteLine($"{nameof(type1)} type: {typeof(T1).Name}");
        Console.WriteLine($"{nameof(type2)} type: {typeof(T2).Name}");
    }
}