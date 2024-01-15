namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Car
{
    private readonly Engine _engine;

    public Car()
    {
        _engine = new Engine();
    }

    public void StartEngine()
    {
        _engine.Start();
    }

    public Engine GetEngine()
    {
        return _engine;
    }
}