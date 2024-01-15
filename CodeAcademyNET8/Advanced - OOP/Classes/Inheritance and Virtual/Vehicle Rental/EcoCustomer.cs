namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual.Vehicle_Rental;

internal class EcoCustomer(string name) : Customer(name)
{
    public override decimal CalculateTotal(decimal ratePerHour, int rentalHours)
    {
        var total = 0m;
        var discountHours = Math.Min(2, rentalHours);
        total += discountHours * ratePerHour * 0.8m;

        if (rentalHours > 2) 
            total += (rentalHours - 2) * ratePerHour;

        return total;
    }
}