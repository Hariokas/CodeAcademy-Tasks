namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual.Vehicle_Rental;

internal abstract class Customer(string name)
{
    public string Name { get; set; } = name;

    public abstract decimal CalculateTotal(decimal ratePerHour, int rentalHours);
}