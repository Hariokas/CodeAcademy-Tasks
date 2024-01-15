namespace CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;

internal class Computer
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Ram { get; set; }
    public int Storage { get; set; }

    public bool CanComputerRunApplication(int requiredRamAmount)
    {
        return Ram >= requiredRamAmount;
    }
}