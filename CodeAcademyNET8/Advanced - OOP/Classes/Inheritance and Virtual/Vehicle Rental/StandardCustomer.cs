namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual.Vehicle_Rental;

internal class StandardCustomer(string name) : Customer(name)
{
    public override decimal CalculateTotal(decimal ratePerHour, int rentalHours)
    {
        return ratePerHour * rentalHours;
    }
}