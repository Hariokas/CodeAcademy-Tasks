namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class InterfaceDog(string name) : IMammal
{
    public string Name { get; set; } = name;

    public void Eat()
    {
        Console.WriteLine($"Doggo {Name} is eating. *Om-nom-nom*");
    }

    public void GiveBirth()
    {
        Console.WriteLine($"Doggo {Name} just gave birth to some puppies!");
    }
}