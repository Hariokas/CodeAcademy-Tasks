using CodeAcademyNET8.Advanced___OOP.Classes.Generics;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal class Generics
{
    public static void RunTasks()
    {
        Task1();
        Task3();
        Task4();
    }

    private static void Task1()
    {
        Validation.Validate<string>("Hello World!");
        Validation.Validate<object>(null);
        Separator();
    }

    private static void Task3()
    {
        Validation.Compare<string, string>("Hello World!", "Hello World!");
        Validation.Compare<string, object>("Hello World!", new object());
        Validation.Compare(new object(), new object());
        Validation.Compare<List<object>, object>([], null);
        Separator();
    }

    private static void Task4()
    {
        var myList = new MySelfMadeList<int>(2);

        Console.WriteLine("Adding values to the list");
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);
        myList.Add(4);
        myList.Print();

        Console.WriteLine("Clearing the list");
        myList.Clear();

        Console.WriteLine("Adding the value to the list");
        myList.Add(1337);
        myList.Print();

        Console.WriteLine("Removing the value from the list");
        myList.Remove(1337);
        myList.Print();

        Separator();
    }
}