namespace CodeAcademyNET8.Advanced___OOP.Classes.Generics;

internal static class Validation
{
    public static void Validate<T>(T value)
    {
        if (value is null)
        {
            Console.WriteLine($"Object of type \"{typeof(T).Name}\" is null!");
            //throw new ArgumentNullException(nameof(value));
            return;
        }

        Console.WriteLine($"Object of type \"{typeof(T).Name}\" is not null.");

        if (typeof(T) == typeof(string))
            Console.WriteLine($"Object of type \"{typeof(T).Name}\" is a string.");
    }

    public static void Compare<T1, T2>(T1 value1, T2 value2)
    {
        if (value1 is null || value2 is null)
        {
            Console.WriteLine("One of the objects is null!");
            //throw new ArgumentNullException(nameof(value));
            return;
        }

        if (typeof(T1) == typeof(T2))
        {
            Console.WriteLine($"Both objects are of [{typeof(T1).Name}] type!");
            return;
        }

        Console.WriteLine($"Type of T1 is [{typeof(T1).Name}]");
        Console.WriteLine($"Type of T2 is [{typeof(T2).Name}]");
    }
}