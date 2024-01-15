namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual.Vehicle_Rental;

internal class VipCustomer(string name) : Customer(name)
{
    public override decimal CalculateTotal(decimal ratePerHour, int rentalHours)
    {
        if (rentalHours > 5)
            return ratePerHour * rentalHours * 0.9m;

        return ratePerHour * rentalHours;
    }
}