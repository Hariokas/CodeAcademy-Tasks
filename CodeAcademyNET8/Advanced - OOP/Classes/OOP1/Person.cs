namespace CodeAcademyNET8.Advanced___OOP;

internal class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Person(string name, int age, int height) : this(name, age)
    {
        Height = height;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public int Height { get; set; }
}