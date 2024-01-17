namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class BmwCar(string model, bool isXDrive, int fuel = 0) : AbstractCar
{
    public override string Model { get; set; } = model;
    public override int Fuel { get; set; } = fuel;
    public bool IsXDrive { get; set; } = isXDrive;

    public override void Drive()
    {
        if (Fuel > 0)
        {
            Console.WriteLine(IsXDrive ? $"Driving {Model} with XDrive..." : $"Driving {Model}...");
            Fuel--;
        }
        else
        {
            Console.WriteLine($"Not enough fuel to drive {Model}!");
        }
    }
}