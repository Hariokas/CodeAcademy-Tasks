namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class AudiCar(string model, bool isQuattro, int fuel = 0) : AbstractCar
{
    public override string Model { get; set; } = model;
    public override int Fuel { get; set; } = fuel;
    public bool IsQuattro { get; set; } = isQuattro;

    public override void Drive()
    {
        if (Fuel > 0)
        {
            Console.WriteLine(isQuattro ? $"{Model} quattro go VROOOOOM!" : $"{Model} no quattro - no vroom.");
            Fuel--;
        }
        else
        {
            Console.WriteLine($"Not enough fuel to drive {Model}!");
        }
    }
}