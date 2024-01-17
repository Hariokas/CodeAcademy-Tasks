namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class InterfaceCar(string model, int fuel = 0) : IVehicle
{
    public string Model { get; set; } = model;
    public int Fuel { get; set; } = fuel;

    public void Drive()
    {
        if (Fuel > 0)
        {
            Console.WriteLine($"Driving {Model}...");
            Fuel--;
        }
        else
        {
            Console.WriteLine($"Not enough fuel to drive {Model}!");
        }
    }

    public void Refuel(int fuelLiters)
    {
        if (fuelLiters > 0)
        {
            Console.WriteLine($"Refueling {Model} with {fuelLiters} liters...");
            Fuel += fuelLiters;
        }
        else
        {
            Console.WriteLine($"Invalid fuel amount for {Model}!");
        }
    }
}