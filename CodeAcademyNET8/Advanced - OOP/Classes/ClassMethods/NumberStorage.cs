namespace CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;

internal class NumberStorage
{
    public List<int> Numbers { get; set; } = new();

    public void AddNumber(int number)
    {
        Numbers.Add(number);
    }

    public void PrintNumbers()
    {
        foreach (var number in Numbers)
            Console.WriteLine(number);
    }
}