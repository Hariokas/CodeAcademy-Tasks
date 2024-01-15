namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Engine
{
    public Engine()
    {
        IsOn = false;
    }

    public bool IsOn { get; private set; }

    public void Start()
    {
        IsOn = true;
    }

    public void Stop()
    {
        IsOn = false;
    }
}