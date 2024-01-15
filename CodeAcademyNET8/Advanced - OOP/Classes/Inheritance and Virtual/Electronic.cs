namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual;

internal class Electronic(string name, decimal price, string warranty) : Product(name, price)
{
    public string Warranty { get; set; } = warranty;

    public void PrintDetails()
    {
        Console.WriteLine($"Electronics Name: {Name}, Price: ${Price}, Warranty Period: {Warranty}");
    }
}