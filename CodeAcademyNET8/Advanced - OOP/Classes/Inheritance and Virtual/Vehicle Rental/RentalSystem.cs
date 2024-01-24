namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual.Vehicle_Rental;

internal class RentalSystem
{
    public VehicleR ReserveVehicle(string model)
    {
        return new CarR(model);
    }
}