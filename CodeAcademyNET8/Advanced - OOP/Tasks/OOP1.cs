using CodeAcademyNET8.Advanced___OOP.Classes;
using CodeAcademyNET8.Advanced___OOP.Classes.OOP1;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class OOP1
{
    public static void RunTasks()
    {
        //Task1_1();
        //Task1_2();
        //Task2_1();
        ////Task2_2();
        //Task3_1();
        //Task3_2();
        //Task4_1();
        //Task4_2();
        Task4_3();
    }

    private static void Task1_1()
    {
        var person = new Person("John", 25);
        var person2 = new Person("Jane", 23, 180);

        Console.WriteLine($"{person.Name}'s age: {person.Age}");
        Console.WriteLine($"{person2.Name}'s age: {person2.Age}; Height: {person2.Height}");

        Separator();
    }

    private static void Task1_2()
    {
        var school = new School("CodeAcademy", "Vilnius");
        var school2 = new School("CodeUniversity", "Kaunas", 1000);

        Console.WriteLine($"{school.Name} in {school.City}");
        Console.WriteLine($"{school2.Name} in {school2.City}; Number of students: {school2.NumberOfStudents}");

        Separator();
    }

    private static void Task2_1()
    {
        var listOfBooks = new List<Book>
        {
            new("The Lord of the Rings", "J. R. R. Tolkien", new DateTime(1954, 7, 29), "United Kingdom"),
            new("The Little Prince", "Antoine de Saint-Exupéry", new DateTime(1943, 4, 6), "France"),
            new("Harry Potter and the Philosopher's Stone", "J. K. Rowling", new DateTime(1997, 6, 26),
                "United Kingdom"),
            new("And Then There Were None", "Agatha Christie", new DateTime(1939, 11, 6), "United Kingdom"),
            new("Dream of the Red Chamber", "Cao Xueqin", new DateTime(1791, 1, 1), "China"),
            new("The Hobbit", "J. R. R. Tolkien", new DateTime(1937, 9, 21), "United Kingdom"),
            new("She: A History of Adventure", "H. Rider Haggard", new DateTime(1887, 11, 1), "United Kingdom"),
            new("The Lion, the Witch and the Wardrobe", "C. S. Lewis", new DateTime(1950, 10, 16), "United Kingdom"),
            new("The Da Vinci Code", "Dan Brown", new DateTime(2003, 3, 18), "United States"),
            new("The Catcher in the Rye", "J. D. Salinger", new DateTime(1951, 7, 16), "United States")
        };

        foreach (var book in listOfBooks)
            Console.WriteLine($"{book.Title} by {book.Author} ({book.Year.Year}), edited at {book.CountryOfEdition}");

        Console.WriteLine();

        var author = "J. R. R. Tolkien";
        var listOfBooksByAuthor = Book.GetListOfBooksByAuthor(listOfBooks, author);

        Console.WriteLine($"Books written by {author}: {string.Join(", ", listOfBooksByAuthor.Select(x => x.Title))}");

        Separator();
    }

    private static void Task2_2()
    {
        var store1 = new Store
        {
            Name = "Maxima",
            YearOfOpening = 1992,
            Products = new List<string> { "Milk", "Banana", "Coca-Cola", "Chocolate" }
        };

        var store2 = new Store
        {
            Name = "Rimi",
            YearOfOpening = 1993,
            Products = new List<string> { "Potato", "Tomato", "Bread", "Plant" }
        };

        var store3 = new Store
        {
            Name = "Iki",
            YearOfOpening = 1997,
            Products = new List<string> { "Orange", "Cucumber", "Flour", "Bread" }
        };

        var listOfStores = new List<Store> { store1, store2, store3 };

        foreach (var store in listOfStores)
            Console.WriteLine($"{store.Name} {store.YearOfOpening} - {string.Join(", ", store.Products)}");

        Separator();
    }

    private static void Task3_1()
    {
        var dog = new Dog("Buddy");
        var cat = new Cat("Whiskers");
        var hamster = new Hamster("Nibbles");

        var names = GetNames(dog, cat, hamster);
        foreach (var name in names) Console.WriteLine(name);

        var animals = new List<Dog> { new("Max"), new("Charlie") };
        var cats = new List<Cat> { new("Bella"), new("Kitty") };
        var hamsters = new List<Hamster> { new("Gizmo"), new("Fuzzy") };

        var animalCount = CountAnimals(animals, cats, hamsters);
        foreach (var pair in animalCount) Console.WriteLine($"{pair.Key}: {pair.Value}");


        Separator();
    }

    private static List<string> GetNames(Dog dog, Cat cat, Hamster hamster)
    {
        return new List<string> { dog.Name, cat.Name, hamster.Name };
    }

    private static Dictionary<string, int> CountAnimals(List<Dog> dogs, List<Cat> cats, List<Hamster> hamsters)
    {
        var counts = new Dictionary<string, int>
        {
            { "Dog", dogs.Count },
            { "Cat", cats.Count },
            { "Hamster", hamsters.Count }
        };

        return counts;
    }

    private static void Task3_2()
    {
        var triangle = new Triangle(3, 4, 3, 4, 5);
        var square = new Square(5);
        var circle = new Circle(2);

        Console.WriteLine($"Triangle: Area = {triangle.Area()}, Perimeter = {triangle.Perimeter()}");
        Console.WriteLine($"Square: Area = {square.Area()}, Perimeter = {square.Perimeter()}");
        Console.WriteLine($"Circle: Area = {circle.Area()}, Perimeter = {circle.Perimeter()}");

        Separator();
    }

    private static void Task4_1()
    {
        var car = new Car();
        car.StartEngine();
        CheckEngineState(car);

        Separator();
    }

    private static void CheckEngineState(Car car)
    {
        Console.WriteLine(car.GetEngine().IsOn ? "The engine is on." : "The engine is off.");
    }

    private static void Task4_2()
    {
        var address = new Address("New York City", "5th Avenue");
        var person = new Person4Task("John Doe", 30, address);
        var person2 = new Person4Task("John Doe", 30, new Address("New York City", "5th Avenue"));


        Console.WriteLine(person.ToString());

        Separator();
    }

    private static void Task4_3()
    {
        var bank = new Bank();

        var account1 = bank.OpenAccount("John Doe", 1000);
        var account2 = bank.OpenAccount("Jane Doe", 500);

        account1.Deposit(500);
        account2.Withdraw(200);

        bank.PrintAccounts();

        Separator();
    }
}