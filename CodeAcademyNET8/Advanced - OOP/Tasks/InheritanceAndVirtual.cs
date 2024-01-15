using CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual;
using CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual.Vehicle_Rental;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class InheritanceAndVirtual
{
    public static void RunTasks()
    {
        Task1_1();
        Task1_2();
        Task2_1();
        Task2_2();
        Task3_1();
        Task3_2();
        Task4_1();
    }

    private static void Task1_1()
    {
        var car = new Car { Speed = 240 };
        var bike = new Bike { Speed = 40 };

        Console.WriteLine($"Car's speed: {car.Speed}");
        Console.WriteLine($"Bike's speed: {bike.Speed}");

        Separator();
    }

    private static void Task1_2()
    {
        var employees = new List<Employee>
        {
            new("John Smith", 2000),
            new("Jane Smith", 2200),
            new("John Doe", 1800),
            new("Jane Doe", 2300),
            new Programmer("John Programmer", 2500,"C#"),
            new Programmer("Jane Programmer", 3800, "Scratch")
        };

        var manager = new Manager("Chad Chadzwin", 5000, employees);

        foreach (var employee in manager.Employees)
            Console.WriteLine($"{employee.Name} - {employee.Salary} EUR");

        manager.PrintProgrammersInfo();

        Separator();
    }

    private static void Task2_1()
    {
        var food = new Food("Bread", 1.5m, DateTime.Now.AddDays(1));
        var electronic = new Electronic("Laptop", 1500, "2 years");

        food.PrintDetails();
        electronic.PrintDetails();

        Separator();
    }

    private static void Task2_2()
    {
        // Describe the vehicle rental system.
        // Your system should have classes of customers, classes of vehicles, classes of different payment methods.
        // Create a short scenario where you as a customer can reserve the vehicle you want
        // and depending on the vehicle it should throw a message when the methods
        // "Drive()", "PrintMaxSpeed", "GetCapacity" and "GetFuelEfficiency" are used.​
        
        // Complement your solution [Task 2.2 (vehicle rental system)] and make everything work using virtual methods.
        // Extend the program so that clients can be of several types ["VIP", "Standard", "Eco"]
        // each of these types should have their own CalculateTotal() implementation.
        // "VIP" would have lower prices if they rent transport for more than 5 hours,
        // "Standard" would always have a simple calculation
        // "Eco" should have a reduced tariff for the first 2 hours.​

        var rentalSystem = new RentalSystem();
        var customer = new EcoCustomer("John Cena");

        var vehicle = rentalSystem.ReserveVehicle("VW Polo");
        vehicle.Drive();
        vehicle.PrintMaxSpeed();
        vehicle.GetCapacity();
        vehicle.GetFuelEfficiency();

        var ratePerHour = 20m;
        var rentalHours = 6;
        var totalCost = customer.CalculateTotal(ratePerHour, rentalHours);

        var paymentMethod = new CreditCardPayment();
        paymentMethod.ProcessPayment(totalCost);

        Console.WriteLine($"Total cost for rental of {vehicle.Model}: {totalCost} EUR");

        Separator();
    }

    private static void Task3_1()
    {
        var transport = new Transport { Speed = 150 };
        var car = new CarTransport { Speed = 240 };

        Console.WriteLine(transport.MeasureSpeed());
        Console.WriteLine(car.MeasureSpeed());

        Separator();
    }

    private static void Task3_2()
    {
        var employees = new List<Employee>
        {
            new("John Smith", 2000),
            new("Jane Smith", 2200),
            new("John Doe", 1800),
            new("Jane Doe", 2300),
            new Programmer("John Programmer", 2500,"C#"),
            new Programmer("Jane Programmer", 3800, "Scratch")
        };

        var manager = new Manager("Chad Chadzwin", 5000, employees);

        foreach (var employee in manager.Employees)
            Console.WriteLine(employee.Greeting());

        Console.WriteLine(manager.Greeting());

        Separator();
    }

    private static void Task4_1()
    {
        var shape = new Shape();
        var circle = new Circle();
        var rectangle = new Rectangle();

        shape.Draw();
        circle.Draw();
        rectangle.Draw();

        Separator();
    }
}