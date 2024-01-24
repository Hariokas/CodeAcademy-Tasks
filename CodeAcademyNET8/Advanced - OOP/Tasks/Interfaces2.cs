using CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class Interfaces2
{
    public static void Run()
    {
        //Task1();
        Task2();
    }

    private static void Task1()
    {
        var dog = new InterfaceDog("Bob");
        var cat = new InterfaceCat("Dollar");
        var fish = new InterfaceFish("Godzilla");

        List<IAnimal> animals = [dog, cat, fish];
        List<IMammal> mammals = [dog, cat];
        List<IFish> fishes = [fish];

        foreach (var animal in animals)
            animal.Eat();

        foreach (var mammal in mammals)
            mammal.GiveBirth();

        foreach (var fishItem in fishes)
            fishItem.Swim();

        Separator();
    }

    private static void Task2()
    {
        var triangle = new InterfaceTriangle(3, 4, 5);
        var quadrilateral = new InterfaceQuadrilateral(3, 4);
        var pentagon = new InterfacePentagon(3);
        var hexagon = new InterfaceHexagon(3);

        List<IPolygon> shapeList = [triangle, quadrilateral, pentagon, hexagon];

        foreach (var shape in shapeList)
            shape.WriteToFile("shapes.txt");

        for (var i = 0; i < shapeList.Count; i++)
        {
            var source = shapeList[i];

            for (var j = 0; j < shapeList.Count; j++)
            {
                if (i == j)
                    continue;

                var comparison = shapeList[j];
                PrintComparison(source, comparison);
            }

            Console.WriteLine("***");
        }

        Separator();
    }

    private static void PrintComparison(IPolygon source, IPolygon? comparison)
    {
        var result = source.CompareTo(comparison);

        var sourceArea = source.GetArea();
        var comparisonArea = comparison?.GetArea() ?? 0;

        switch (result)
        {
            case 0:
                Console.WriteLine(
                    $"{source.GetType().Name} [{sourceArea}] is equal to {comparison?.GetType().Name} [{comparisonArea}]");
                break;
            case 1:
                Console.WriteLine(
                    $"{source.GetType().Name} [{sourceArea}] is greater than {comparison?.GetType().Name} [{comparisonArea}]");
                break;
            case -1:
                Console.WriteLine(
                    $"{source.GetType().Name} [{sourceArea}] is less than {comparison?.GetType().Name} [{comparisonArea}]");
                break;
            default:
                Console.WriteLine($"{source.GetType().Name} is not comparable to {comparison?.GetType().Name}");
                break;
        }
    }
}