using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal class Delegates
{
    public delegate int CountSumDelegate(int a, int b);

    public delegate List<int> GetTheNextNumberDelegate(List<int> integerList, int step);

    public delegate string PrintUserInfoDelegate(string firstName, string lastName, int age);

    public delegate string GetTypeOfElementDelegate<in T>(T element);

    public static void Run()
    {
        Task1_1();
        Task1_2();
        Task1_3();
        Task1_4();
    }

    private static void Task1_1()
    {
        var printUserInfoDelegate = new PrintUserInfoDelegate(PrintUserInfo);
        var userInfo = printUserInfoDelegate.Invoke("John", "Doe", 57);
        Console.WriteLine(userInfo);

        Separator();
    }

    private static string PrintUserInfo(string firstName, string lastName, int age)
    {
        return $"{firstName} {lastName} is {age} years old";
    }

    private static void Task1_2()
    {
        const int a = 5;
        const int b = 10;

        var countSum = new CountSumDelegate(Sum);
        var sum = countSum.Invoke(a, b);
        Console.WriteLine($"{a} + {b} = {sum}");

        Separator();
    }

    private static int Sum(int a, int b)
    {
        return a + b;
    }

    private static void Task1_3()
    {
        List<int> integerList = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        const int step = 3;
        var getTheNextNumberDelegate = new GetTheNextNumberDelegate(GetTheNextNumber);
        var newList = getTheNextNumberDelegate.Invoke(integerList, step);

        Console.WriteLine($"Original list: {JoinArray(integerList)}");
        Console.WriteLine($"New list with step count of {step}: {JoinArray(newList)}");

        Separator();
    }

    private static List<int> GetTheNextNumber(IReadOnlyList<int> integerList, int step)
    {
        var newList = new List<int>();

        for (var i = 0; i < integerList.Count; i += step)
            newList.Add(integerList[i]);

        return newList;
    }

    private static void Task1_4()
    {
        //var getTypeOfElementDelegate = new GetTypeOfElementDelegate<string>(GetType);
        var getTypeOfElementDelegate = GetType<string>;
        var type = getTypeOfElementDelegate.Invoke("John Doe");
        Console.WriteLine($"Object's type is: {type}");

        Separator();
    }

    private static string GetType<T>(T element)
    {
        return element?.GetType().Name ?? "NULL";
    }
}

//public delegate string NameDelegate();
//public delegate string DomainDelegate();

//public static void Run()
//{
//    Generate(GetFullName, GetOfficialDomain);
//    Generate(GetName, GetPrivateDomain);

//    Generate(GetFullName(), GetOfficialDomain());
//    Generate(GetName(), GetPrivateDomain());
//}

//private static void Generate(NameDelegate name, DomainDelegate domain)
//{
//    Console.WriteLine($"{name()}@{domain()}");
//}

//private static void Generate(string name, string domain)
//{
//    Console.WriteLine($"{name}@{domain}");
//}

//private static string GetName()
//{
//    return "John";
//}

//private static string GetFullName()
//{
//    return "JohnDoe";
//}

//private static string GetOfficialDomain()
//{
//    return "CodeAcademy.lt";
//}

//private static string GetPrivateDomain()
//{
//    return "gmail.com";
//}