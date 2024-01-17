namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal abstract class AbstractCar
{
    public abstract string Model { get; set; }
    public abstract int Fuel { get; set; }

    public abstract void Drive();

    public virtual void Refuel(int fuelLiters)
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