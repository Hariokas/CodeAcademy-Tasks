using CodeAcademyNET8.Advanced___OOP.Classes.Generics;
using static CodeAcademyNET8.Helpers;
using Type = CodeAcademyNET8.Advanced___OOP.Classes.Generics.Type;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class Generics2
{
    public static void RunTasks()
    {
        Task1();
        Task2();
        Task3();
        Task4();
    }

    private static void Task1()
    {
        Separator();
    }

    private static void Task2()
    {
        var figure = new FourSideGeometricFigure
        {
            Name = "Rectangle",
            Base = 5,
            Height = 10
        };

        Generator.Show(figure);

        Separator();
    }

    private static void Task3()
    {
        var type1 = "Hello World!";
        var type2 = new FourSideGeometricFigure
        {
            Name = "Rectangle",
            Base = 5,
            Height = 10
        };

        Type.GetType(type1, type2);
        Separator();
    }

    private static void Task4()
    {
        var basketballLeague = new SportsGameLeague<BasketballTeam>();
        var footballLeague = new SportsGameLeague<FootballTeam>();

        basketballLeague.AddTeam(new BasketballTeam("The Bouncing Bagels"));
        basketballLeague.AddTeam(new BasketballTeam("The Hoops Hooligans"));
        basketballLeague.AddTeam(new BasketballTeam("The Alley-Oopsies"));

        footballLeague.AddTeam(new FootballTeam("The Wacky Wingbacks"));
        footballLeague.AddTeam(new FootballTeam("The Goal Diggers"));
        footballLeague.AddTeam(new FootballTeam("The Puntastic Punters"));

        Console.WriteLine("---");

        basketballLeague.PrintTeams();
        footballLeague.PrintTeams();

        Separator();
    }

}