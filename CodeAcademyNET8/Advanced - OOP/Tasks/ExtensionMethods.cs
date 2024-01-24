using CodeAcademyNET8.Advanced___OOP.Classes.ExtensionMethods;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class ExtensionMethods
{
    public static void RunTasks()
    {
        Task1();
    }

    private static void Task1()
    {
        const int number = 5;
        const int greaterThan = 10;
        var isPositive = number.IsPositive();
        var isNegative = number.IsNegative();
        var isEven = number.IsEven();
        var isGreaterThan = number.IsGreaterThan(greaterThan);

        Console.WriteLine(
            $"Number {number}\nisPositive: {isPositive}\nisNegative: {isNegative}\nisEven: {isEven}\nisGreaterThan {greaterThan}: {isGreaterThan}");
        Console.WriteLine("---");

        const string fullname = "John Doe";
        var containsWhiteSpace = fullname.ContainsWhiteSpace();
        var email = fullname.ToEmailAddress(1990, "gmail.com");

        Console.WriteLine($"Fullname: {fullname}\ncontainsWhiteSpace: {containsWhiteSpace}\nemail: {email}");
        Console.WriteLine("---");

        var list = new List<string?> { "Whatchamacallit", "Hullabaloo", null, "Kerfuffle", "Thingamajig" };
        const string searchingFor = "Hullabaloo";
        var foundItems = list.FindAndReturnIfEqual(searchingFor);
        var everyOtherWord = list.EveryOtherWord();

        Console.WriteLine(
            $"{list.GetType().Name}: {JoinArray(list)}\nFound {searchingFor}?: {JoinArray(foundItems)}\nEvery other word: {JoinArray(everyOtherWord)}");
        Console.WriteLine("---");

        var everyOtherLine =
            File.ReadAllLines(@"C:\Dev\CodeAcademyNET8\CodeAcademyNET8\Advanced - OOP\Classes\Streams\FileWithText.txt")
                .ReadEveryOtherLine();
        Console.WriteLine($"Every other line:\n{JoinArray(everyOtherLine, "\n")}");

        Separator();
    }
}