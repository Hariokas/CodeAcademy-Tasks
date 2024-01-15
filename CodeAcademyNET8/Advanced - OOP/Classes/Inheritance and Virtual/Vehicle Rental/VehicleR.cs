namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual.Vehicle_Rental;

internal abstract class VehicleR(string model)
{
    public string Model { get; set; } = model;

    public abstract void Drive();
    public abstract void PrintMaxSpeed();
    public abstract void GetCapacity();
    public abstract void GetFuelEfficiency();
}