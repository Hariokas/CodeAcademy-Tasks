namespace CodeAcademyNET8.Advanced___OOP.Classes.LinqAndLambda;

internal class Pet(string name, int age)
{
    internal string Name { get; set; } = name;
    internal int Age { get; set; } = age;

    public override string ToString()
    {
        return $"{Name} is {Age} years old";
    }
}