namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility;

internal class Dog : Animal
{
    public sealed override void MakeSound()
    {
        Console.WriteLine("**Woof Woof**");
    }
}