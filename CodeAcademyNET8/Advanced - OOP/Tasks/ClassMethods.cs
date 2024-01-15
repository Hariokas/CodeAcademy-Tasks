using CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class ClassMethods
{
    public static void RunTasks()
    {
        Task1_1();
        Task1_2();
        Task1_3();
        Task1_4();
        Task1_5();
        Task1_6();
        Task1_7();
    }

    private static void Task1_1()
    {
        var numberStorage = new NumberStorage();

        for (var i = 0; i < 10; i++)
        {
            var number = Random.Shared.Next(1, 100);
            numberStorage.AddNumber(number);
        }

        numberStorage.PrintNumbers();

        Separator();
    }

    private static void Task1_2()
    {
        var rectangle = new Rectangle
        {
            Height = 10,
            Width = 20
        };

        Console.WriteLine($"Area: {rectangle.GetArea()}");
        Console.WriteLine($"Perimeter: {rectangle.GetPerimeter()}");

        Separator();
    }

    private static void Task1_3()
    {
        var circle = new Circle
        {
            Radius = 10
        };

        Console.WriteLine($"Area: {Math.Round(circle.GetArea(), 2)}");

        Separator();
    }

    private static void Task1_4()
    {
        var library = new Library();

        var book1 = new Book
        {
            Title = "Book1",
            Description = "Description1",
            Author = "Author1",
            Pages = 100
        };

        var book2 = new Book
        {
            Title = "Book2",
            Description = "Description2",
            Author = "Author2",
            Pages = 200
        };

        var book3 = new Book
        {
            Title = "Book3",
            Description = "Description3",
            Author = "Author3",
            Pages = 199
        };

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        library.RemoveBook(book2);

        library.PrintBooks();

        foreach (var book in library.Books)
            Console.WriteLine($"Reading time for {book.Title}: {library.GetReadingTime(book)}");

        Separator();
    }

    private static void Task1_5()
    {
        var playlist = new Playlist();

        playlist.AddSong(new Song
        {
            Title = "Song1",
            Artist = "Artist1",
            Album = "Album1",
            Length = 100
        });

        playlist.AddSong(new Song
        {
            Title = "Song2",
            Artist = "Artist2",
            Album = "Album2",
            Length = 200
        });

        playlist.AddSong(new Song
        {
            Title = "Song3",
            Artist = "Artist3",
            Album = "Album3",
            Length = 300
        });

        playlist.PrintSongs();

        Separator();
    }

    private static void Task1_6()
    {
        var movieList = new List<Movie>
        {
            new()
            {
                Title = "Movie1",
                Genre = "Genre1",
                Rating = 8.5
            },
            new()
            {
                Title = "Movie2",
                Genre = "Genre2",
                Rating = 9.5
            },
            new()
            {
                Title = "Movie3",
                Genre = "Genre3",
                Rating = 7.5
            },
            new()
            {
                Title = "Movie4",
                Genre = "Genre4",
                Rating = 3.5
            }
        };

        foreach (var movie in movieList)
            Console.WriteLine($"Is {movie.Title} watchable? {movie.IsWatchable}");

        Separator();
    }

    private static void Task1_7()
    {
        var computer = new Computer
        {
            Brand = "Pear",
            Model = "HesBook Pro",
            Ram = 4,
            Storage = 64
        };

        Console.WriteLine(
            $"Can my {computer.Model} by {computer.Brand} having {computer.Ram} GB of RAM run the Doom? {computer.CanComputerRunApplication(32)}");

        Separator();
    }
}