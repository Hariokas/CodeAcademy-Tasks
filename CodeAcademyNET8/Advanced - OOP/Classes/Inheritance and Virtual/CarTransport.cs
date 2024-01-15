namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual;

internal class CarTransport : Transport
{
    public override string MeasureSpeed()
    {
        return $"Car speed is {Speed} km/h";
    }
}