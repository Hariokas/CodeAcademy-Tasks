namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class InterfaceFish(string name) : IFish
{
    public string Name { get; set; } = name;

    public void Swim()
    {
        Console.WriteLine($"Fish {Name} is swimming!");
    }

    public void Eat()
    {
        Console.WriteLine($"Fish {Name} is eating. *Om-nom-nom*");
    }
}