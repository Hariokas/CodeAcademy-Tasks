using CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class InterfacesAndIComparer
{
    public static void Run()
    {
        Task1();
        Task2();
    }

    private static void Task1()
    {
        var car = new InterfaceCar("Tesla");
        car.Drive();
        car.Refuel(10);
        car.Refuel(-10);
        car.Drive();

        Separator();
    }

    private static void Task2()
    {
        var bmw = new BmwCar("M5", true);
        bmw.Drive();
        bmw.Refuel(10);
        bmw.Drive();

        var audi = new AudiCar("RS6", true, 9000);
        audi.Drive();

        Separator();
    }
}