namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual.Vehicle_Rental;

internal class CarR(string model) : VehicleR(model)
{
    public override void Drive()
    {
        Console.WriteLine($"Driving the car: {Model}");
    }

    public override void PrintMaxSpeed()
    {
        Console.WriteLine("Max speed is 240 km/h.");
    }

    public override void GetCapacity()
    {
        Console.WriteLine("Capacity is 5 passengers.");
    }

    public override void GetFuelEfficiency()
    {
        Console.WriteLine("Fuel efficiency is 6 liters/100 km.");
    }
}