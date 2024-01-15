namespace CodeAcademyNET8.Advanced___OOP.Classes.ExtensionMethods;

internal static class ExtensionMethods
{
    internal static bool IsPositive(this int number)
    {
        return number > 0;
    }

    internal static bool IsNegative(this int number)
    {
        return number < 0;
    }

    internal static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }

    internal static bool IsGreaterThan(this int number, int otherNumber)
    {
        return number > otherNumber;
    }

    internal static bool ContainsWhiteSpace(this string text)
    {
        return text.Contains(' ');
    }

    internal static string ToEmailAddress(this string fullname, int yearOfBirth, string domain)
    {
        return $"{fullname.ToLower().Replace(" ", ".")}{yearOfBirth}@{domain}";
    }

    internal static List<T> FindAndReturnIfEqual<T>(this List<T> list, T item)
    {
        return list.FindAll(element => element?.Equals(item) ?? false);
    }

    internal static List<T> EveryOtherWord<T>(this List<T> list)
    {
        return list.Where((element, index) => index % 2 == 0).ToList();
    }

    internal static string[] ReadEveryOtherLine(this string[] lines)
    {
        return lines.Where((line, index) => index % 2 == 0).ToArray();
    }
}