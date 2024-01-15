namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual;

internal class Food(string name, decimal price, DateTime expirationTime) : Product(name, price)
{
    public DateTime ExpirationTime { get; set; } = expirationTime;

    public void PrintDetails()
    {
        Console.WriteLine($"Food Name: {Name}, Price: ${Price}, Expiration Time: {ExpirationTime}");
    }
}