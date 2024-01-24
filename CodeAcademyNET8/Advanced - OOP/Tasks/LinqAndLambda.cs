using System.Text;
using CodeAcademyNET8.Advanced___OOP.Classes.LinqAndLambda;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class LinqAndLambda
{
    public static void Run()
    {
        Task1_1();
        Task1_2();
        Task1_3();
        Task1_4();
        Task1_5();
        Task1_6();
        Task1_7();
        Task2_1();
        Task2_2();
        Task3();
    }

    private static void Task1_1()
    {
        List<int> integerList = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        var squaredList = integerList.Select(x => x * x).ToList();
        Console.WriteLine($"Original list: {JoinArray(integerList)}");
        Console.WriteLine($"Squared list: {JoinArray(squaredList)}");

        Separator();
    }

    private static void Task1_2()
    {
        List<int> integerList = [];
        integerList.AddRange(GetRandomNumberArr(-50, 51, 10));

        var positiveList = integerList.Where(x => x > 0).ToList();

        Console.WriteLine($"Original list: {JoinArray(integerList)}");
        Console.WriteLine($"Positive number list: {JoinArray(positiveList)}");

        Separator();
    }

    private static void Task1_3()
    {
        List<int> integerList = [];
        integerList.AddRange(GetRandomNumberArr(-50, 51, 10));

        int[] numbers = [3, 7];
        integerList.AddRange(numbers);

        var evenList = integerList.Where(x => x is > 0 and <= 10).ToList();

        Console.WriteLine($"Original list: {JoinArray(integerList)}");
        Console.WriteLine($"Positive but not greater than 10 number list: {JoinArray(evenList)}");

        Separator();
    }

    private static void Task1_4()
    {
        List<int> integerList = [];
        integerList.AddRange(GetRandomNumberArr(-50, 51, 10));

        var ascending = integerList.OrderBy(x => x).ToList();

        Console.WriteLine($"Original list: {JoinArray(integerList)}");
        Console.WriteLine($"Ascending list: {JoinArray(ascending)}");

        Separator();
    }

    private static void Task1_5()
    {
        List<int> integerList = [];
        integerList.AddRange(GetRandomNumberArr(-50, 51, 10));

        var descendingList = integerList.OrderByDescending(x => x).ToList();

        Console.WriteLine($"Original list: {JoinArray(integerList)}");
        Console.WriteLine($"Descending list: {JoinArray(descendingList)}");

        Separator();
    }

    private static void Task1_6()
    {
        List<int> integerList = [];
        integerList.AddRange(GetRandomNumberArr(-50, 51, 10));

        var maxValue = integerList.Max();

        Console.WriteLine($"Original list: {JoinArray(integerList)}");
        Console.WriteLine($"Biggest element: {maxValue}");

        Separator();
    }

    private static void Task1_7()
    {
        var peopleList = new List<Classes.LinqAndLambda.Person>
        {
            new("Severus Snape", GetRandomNumberArr(5, 101, 1).First()),
            new("Jane Doe", GetRandomNumberArr(5, 101, 1).First()),
            new("Anthony Smith", GetRandomNumberArr(5, 101, 1).First()),
            new("Lola Smith", GetRandomNumberArr(5, 101, 1).First()),
            new("Jamie Wayne", GetRandomNumberArr(5, 101, 1).First()),
            new("Jane Wayne", GetRandomNumberArr(5, 101, 1).First()),
            new("Albus Dombledore", GetRandomNumberArr(5, 101, 1).First()),
            new("Big Ben", GetRandomNumberArr(5, 101, 1).First()),
            new("John Lennon", GetRandomNumberArr(5, 101, 1).First()),
            new("Lord Voldemort", GetRandomNumberArr(5, 101, 1).First())
        };

        Console.WriteLine($"Original people list:\n{ForeachToString(peopleList)}");

        var peopleNameList = peopleList.Select(x => x.Name).ToList();
        Console.WriteLine($"People name list:\n{ForeachToString(peopleNameList)}");

        var sortedByAgeDesc = peopleList.OrderByDescending(x => x.Age).ToList();
        Console.WriteLine($"Sorted by age descending:\n{ForeachToString(sortedByAgeDesc)}");

        var peopleNameStartingWithA = peopleList.Where(x => x.Name.StartsWith("A")).ToList();
        Console.WriteLine($"People name list with name starting with A:\n{ForeachToString(peopleNameStartingWithA)}");

        var peopleOlderThan40 = peopleList.Where(x => x.Age >= 40).OrderBy(x => x.Name).ToList();
        Console.WriteLine($"People older are 40+ sorted by name:\n{ForeachToString(peopleOlderThan40)}");

        Separator();
    }

    private static void Task2_1()
    {
        List<PersonWithPet> peopleWithPets =
        [
            new PersonWithPet("John",
            [
                new Pet("Rex", GetRandomNumberArr(1, 16, 1).First()),
                new Pet("Mia", GetRandomNumberArr(1, 16, 1).First())
            ]),
            new PersonWithPet("Jane",
            [
                new Pet("Max", GetRandomNumberArr(1, 16, 1).First()),
                new Pet("Charlie", GetRandomNumberArr(1, 16, 1).First())
            ]),
            new PersonWithPet("Bob",
            [
                new Pet("Buddy", GetRandomNumberArr(1, 16, 1).First()),
                new Pet("Molly", GetRandomNumberArr(1, 16, 1).First())
            ]),
            new PersonWithPet("Lisa",
            [
                new Pet("Rocky", GetRandomNumberArr(1, 16, 1).First()),
                new Pet("Bella", GetRandomNumberArr(1, 16, 1).First())
            ])
        ];

        var petsList = peopleWithPets.SelectMany(x => x.PetList).ToList();
        Console.WriteLine($"Pets list:\n{ForeachToString(petsList)}");

        var selectedPets = petsList.Where(x => x.Age > 5 && x.Name.ToUpper().Contains('A')).ToList();
        Console.WriteLine($"Pets over 5 years old with letter A in name:\n{ForeachToString(selectedPets)}");

        Separator();
    }

    private static void Task2_2()
    {
        var sentence = "The quick Brown Fox jumps over the Lazy Dog";
        Console.WriteLine($"Original sentence: {sentence}");
        Console.WriteLine($"Words starting with uppercase: {GetWordsStartingWithUppercase(sentence)}");

        Separator();
    }

    private static void Task3()
    {
        var projectDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "";
        var files = Directory.GetFiles(projectDirectory, "*.*", SearchOption.AllDirectories);

        var fileExtensions = files.Select(x => Path.GetExtension(x)).Distinct().ToList();
        Console.WriteLine($"File extensions:\n{ForeachToString(fileExtensions)}");

        var textFiles = files.Where(x => Path.GetExtension(x) == ".txt").ToList();
        Console.WriteLine($"Text files:\n{ForeachToString(textFiles)}");

        var fileNames = files.Select(x => Path.GetFileName(x)).ToList();
        Console.WriteLine($"File names:\n{ForeachToString(fileNames)}");

        Separator();
    }

    private static string GetWordsStartingWithUppercase(string input, string separator = " ")
    {
        return string.Join(separator, input.Split(' ').Where(x => char.IsUpper(x[0])));
    }

    private static string ForeachToString<T>(IEnumerable<T> items)
    {
        var sb = new StringBuilder();
        foreach (var item in items)
            sb.Append($"{item}\n");

        return sb.ToString();
    }
}