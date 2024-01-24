namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility;

internal class PersonAccessibility(string name, int age)
{
    public string Name { get; } = name;

    public int Age { get; } = age;

    protected internal void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}; Age: {Age}");
    }
}