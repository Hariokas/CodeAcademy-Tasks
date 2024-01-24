namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class InterfaceCat(string name) : IMammal
{
    public string Name { get; set; } = name;

    public void Eat()
    {
        Console.WriteLine($"Cat {Name} is eating. *Om-nom-nom*");
    }

    public void GiveBirth()
    {
        Console.WriteLine($"Cat {Name} just gave birth to some kittens!");
    }
}