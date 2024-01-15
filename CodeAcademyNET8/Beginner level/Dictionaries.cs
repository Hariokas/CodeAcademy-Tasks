using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8;

internal static class Dictionaries
{
    public static void RunTasks()
    {
        //Task1();
        //Task1_2();
        //Task1_3();
        //Task2_1();
        //Task2_2();
        //Task2_3();
        //Task2_4();
        //Task3_1();
        //Task3_2();
        //Task3_3();
        Task4();
    }

    private static void Task1()
    {
        PopulateAndPrintDictionary();
    }

    private static void PopulateAndPrintDictionary()
    {
        var numberOfPeople = 3;
        var people = new Dictionary<string, int>();

        for (var i = 0; i < numberOfPeople; i++)
        {
            Console.Write("Enter the name: ");
            var name = Console.ReadLine() ?? "n/a";
            Console.Write($"Enter {name}'s age: ");
            int.TryParse(Console.ReadLine(), out var age);
            people.Add(name, age);
        }

        foreach (var person in people) Console.WriteLine($"{person.Key} is {person.Value} years old.");

        Separator();
    }

    private static void Task1_2()
    {
        var country = "Lithuania";
        var capital = GetCapital(country);
        Console.WriteLine($"Capital of {country} is {capital}");

        Separator();
    }

    private static string GetCapital(string country)
    {
        var capitals = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Bulgaria", "Sofia" },
            { "Romania", "Bucharest" },
            { "Serbia", "Belgrade" },
            { "Greece", "Athens" },
            { "Turkey", "Ankara" },
            { "Macedonia", "Skopje" },
            { "Montenegro", "Podgorica" },
            { "Kosovo", "Pristina" },
            { "Albania", "Tirana" },
            { "Bosnia and Herzegovina", "Sarajevo" },
            { "France", "Paris" },
            { "Germany", "Berlin" },
            { "Italy", "Rome" },
            { "Spain", "Madrid" },
            { "Portugal", "Lisbon" },
            { "United Kingdom", "London" },
            { "Ireland", "Dublin" },
            { "Russia", "Moscow" },
            { "China", "Beijing" },
            { "Japan", "Tokyo" },
            { "Lithuania", "Vilnius" }
        };

        return capitals.TryGetValue(country, out var capital) ? capital : "n/a";
    }

    private static void Task1_3()
    {
        FruitsTask();
    }

    private static void FruitsTask()
    {
        var fruits = new Dictionary<string, int>
        {
            { "Apple", 5 },
            { "Banana", 10 },
            { "Orange", 15 },
            { "Pineapple", 20 },
            { "Watermelon", 25 }
        };

        PrintFruits(fruits);

        Console.WriteLine("Enter fruit name: ");
        var fruitName = Console.ReadLine() ?? "n/a";
        Console.WriteLine("Enter fruit quantity: ");
        int.TryParse(Console.ReadLine(), out var fruitQuantity);

        AddOrUpdateFruit(fruits, fruitName, fruitQuantity);

        PrintFruits(fruits);

        Separator();

        int? nullInt = null;
        string? nullString = null;

        fruits.Add(nullString ?? "n/a", nullInt ?? 0);
    }

    private static void PrintFruits(Dictionary<string, int> fruits)
    {
        foreach (var fruit in fruits)
            Console.WriteLine($"{fruit.Key} - {fruit.Value}");
    }

    private static void AddOrUpdateFruit(Dictionary<string, int> fruits, string fruitName, int fruitQuantity)
    {
        fruits[fruitName] = fruitQuantity;
    }

    private static void Task2_1()
    {
        //Create a dictionary to store the names of cities and their populations. Ask the user to enter the name of the city and show its population. 

        var cities = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase)
        {
            { "Vilnius", 580020 },
            { "Kaunas", 288061 },
            { "Klaipėda", 147810 },
            { "Šiauliai", 100575 },
            { "Panevėžys", 93053 },
            { "Alytus", 54128 },
            { "Marijampolė", 34357 },
            { "Mažeikiai", 33872 },
            { "Jonava", 34000 },
            { "Utena", 28000 },
            { "Kėdainiai", 23000 },
            { "Telšiai", 21000 },
            { "Visaginas", 18000 },
            { "Tauragė", 15000 },
            { "Ukmergė", 14000 },
            { "Plungė", 13000 },
            { "Kretinga", 13000 },
            { "Palanga", 10000 },
            { "Radviliškis", 10000 },
            { "Druskininkai", 10000 },
            { "Rokiškis", 10000 },
            { "Biržai", 10000 },
            { "Gargždai", 10000 },
            { "Kuršėnai", 10000 },
            { "Elektrėnai", 10000 },
            { "Jurbarkas", 10000 },
            { "Garliava", 10000 },
            { "Vilkaviškis", 10000 },
            { "Raseiniai", 10000 },
            { "Anykščiai", 10000 },
            { "Prienai", 10000 },
            { "Joniškis", 10000 },
            { "Kelmė", 10000 },
            { "Varėna", 10000 },
            { "Pasvalys", 10000 },
            { "Kupiškis", 10000 },
            { "Zarasai", 10000 },
            { "Šilutė", 10000 },
            { "Kaišiadorys", 10000 },
            { "Naujoji Akmenė", 10000 },
            { "Rietavas", 10000 },
            { "Širvintos", 10000 }
        };

        Console.Write("Enter city name: ");
        var cityName = Console.ReadLine() ?? "n/a";

        Console.WriteLine(cities.TryGetValue(cityName, out var cityPopulation)
            ? $"Population of {cityName} is {cityPopulation}"
            : $"City {cityName} not found");

        Separator();
    }

    private static void Task2_2()
    {
        //Create a dictionary to store words and their translations. Allow the user to enter a word and display its translation. 
        //If the word is not found, display a message that the word is not in the dictionary and allow the user to add it.
        //If the word is not found and the user does not want to add it, display a message that the word is not in the dictionary and exit the program.

        var translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Labas", "Hello" },
            { "Rytas", "Morning" },
            { "Vakaras", "Evening" },
            { "Naktis", "Night" },
            { "Ačiū", "Thank you" },
            { "Prašom", "You're welcome" },
            { "Sveikas", "Hi" },
            { "Sudie", "Bye" },
            { "Kiek", "How much" },
            { "Kiek kainuoja", "How much does it cost" },
            { "Kur", "Where" },
            { "Kur yra", "Where is" },
            { "Viso gero", "Good bye" }
        };

        Console.Write("Enter word: ");
        var word = Console.ReadLine() ?? "n/a";

        if (translations.TryGetValue(word, out var translation))
        {
            Console.WriteLine($"Translation of {word} is {translation}");
        }
        else
        {
            Console.WriteLine($"Word {word} not found");
            Console.Write("Do you want to add it? (y/n): ");
            var answer = Console.ReadLine() ?? "n/a";
            if (answer.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter translation: ");
                var newTranslation = Console.ReadLine() ?? "n/a";
                translations.Add(word, newTranslation);
                Console.WriteLine($"Translation of {word} is {newTranslation}");
            }
            else
            {
                Console.WriteLine("Exiting...");
            }
        }

        Separator();
    }

    private static void Task2_3()
    {
        //Create a dictionary to store students' names and grades. Ask the user to enter the student's name and display their grades. 

        var students = new Dictionary<string, List<int>>(StringComparer.OrdinalIgnoreCase)
        {
            { "Jonas", new List<int> { 10, 9, 8, 7, 6 } },
            { "Petras", new List<int> { 9, 8, 7, 6, 5 } },
            { "Antanas", new List<int> { 8, 7, 6, 5, 4 } },
            { "Kazys", new List<int> { 7, 6, 5, 4, 3 } },
            { "Juozas", new List<int> { 6, 5, 4, 3, 2 } },
            { "Ona", new List<int> { 5, 4, 3, 2, 1 } },
            { "Marytė", new List<int> { 4, 3, 2, 1, 0 } },
            { "Jurgis", new List<int> { 3, 2, 1, 0, 0 } },
            { "Kęstas", new List<int> { 2, 1, 0, 0, 0 } },
            { "Giedrė", new List<int> { 1, 0, 0, 0, 0 } }
        };

        Console.Write("Enter student name: ");
        var studentName = Console.ReadLine() ?? "n/a";

        if (students.TryGetValue(studentName, out var grades))
            Console.WriteLine($"Grades of {studentName} are {JoinArray(grades)}");
        else
            Console.WriteLine($"Student {studentName} not found");

        Separator();
    }

    private static void Task2_4()
    {
        //Create a dictionary to store the names of the months and their day numbers. Print out the names of months with fewer than 31 days.

        var months = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "January", 31 },
            { "February", 28 },
            { "March", 31 },
            { "April", 30 },
            { "May", 31 },
            { "June", 30 },
            { "July", 31 },
            { "August", 31 },
            { "September", 30 },
            { "October", 31 },
            { "November", 30 },
            { "December", 31 }
        };

        var monthsWithLessThan31Days = months.Where(m => m.Value < 31).Select(m => m.Key);

        Console.WriteLine($"Months with less than 31 days: {JoinArray(monthsWithLessThan31Days)}");

        Separator();
    }

    private static void Task3_1()
    {
        //Create an application that allows the user to enter a list of words. The program must count the number of times each word appears in the list and print the results. Use a dictionary to complete this task. 

        do
        {
            Console.Write("Enter a list of words separated by space: ");
            var words = Console.ReadLine()?.Split(' ') ?? Array.Empty<string>();

            var wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var word in words)
                if (wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount.Add(word, 1);

            foreach (var word in wordCount) Console.WriteLine($"{word.Key} - {word.Value}");

            Console.Write("Do you want to continue? (y/n): ");
            var answer = Console.ReadLine() ?? "n/a";
            if (!answer.Equals("y", StringComparison.OrdinalIgnoreCase))
                break;
        } while (true);

        Separator();
    }

    private static void Task3_2()
    {
        //Create a dictionary to store film titles and genres. Write a function that accepts a genre name and returns a list of films belonging to that genre. Allow the user to select the genre and print the list of films. 

        var films = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            {
                "Action",
                new List<string> { "The Dark Knight", "The Matrix", "Inception", "The Terminator", "Die Hard" }
            },
            { "Comedy", new List<string> { "The Hangover", "Knocked Up", "Ted", "Borat", "Superbad" } },
            {
                "Drama",
                new List<string>
                {
                    "The Shawshank Redemption", "The Godfather", "Schindler's List", "Forrest Gump", "Good Will Hunting"
                }
            },
            {
                "Horror",
                new List<string>
                    { "Halloween", "The Shining", "The Exorcist", "The Conjuring", "The Texas Chainsaw Massacre" }
            },
            {
                "Romance",
                new List<string> { "Titanic", "The Notebook", "La La Land", "The Fault in Our Stars", "The Vow" }
            }
        };

        Console.WriteLine($"Available genres: {JoinArray(films.Keys)}");
        Console.Write("Enter genre: ");
        var genre = Console.ReadLine() ?? "n/a";

        if (films.TryGetValue(genre, out var film))
            PrintFilms(film, genre);
        else
            Console.WriteLine($"Genre {genre} not found");

        Separator();
    }

    private static void PrintFilms(IEnumerable<string> films, string genre)
    {
        Console.WriteLine($"Movies of {genre} genre: {JoinArray(films)}");
    }

    private static void Task3_3()
    {
        //Create a program that generates a random sequence of numbers. Allow the user to enter the desired length and range of the sequence. The program must generate the sequence of numbers and store it in a dictionary, where the key is a number and the value is the number of occurrences of the number. Print the generated sequence and the number of repetitions.

        var random = new Random();
        var numbers = new Dictionary<int, int>();

        Console.Write("Enter desired length of the sequence: ");
        int.TryParse(Console.ReadLine(), out var length);

        Console.Write("Enter lower bound of the sequence: ");
        int.TryParse(Console.ReadLine(), out var lowerBound);

        Console.Write("Enter upper bound of the sequence: ");
        int.TryParse(Console.ReadLine(), out var upperBound);

        for (var i = 0; i < length; i++)
        {
            var number = random.Next(lowerBound, upperBound + 1);

            if (!numbers.TryAdd(number, 1))
                numbers[number]++;
        }

        foreach (var number in numbers.OrderBy(kvp => kvp.Key))
            Console.WriteLine($"Number {number.Key} occurred {number.Value} times.");

        Separator();
    }

    private static void Task4()
    {
        // Create a method that returns whether a coin flip resulted in heads or tails. Enhance your program so that it asks the user to enter their first and last name when starting. The user should see the following menu options: 1. Flip a coin 2. Print current results 3. Log out.
        // When option 1 is chosen, the program flips a coin and updates the count of how many times the user has flipped heads. When option 2 is selected, the program should display the percentage of times the user has flipped heads or tails.
        // Upon selecting option 3, the program asks to enter a first and last name. If a new name is entered, a new record should be created in a dictionary to track the results for the new person.​
        // If "Admin Admin" is entered during the login process, the program should only display two menu options for the user: 1. Print current results 2. Log out.​
        // When option 1 is selected, it should print the percentage statistics of all users' coin flips.

        var keepRunning = true;
        var users = new Dictionary<string, int[]>();

        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to Coin Flipper 3000!");
            Console.Write("Enter your first name: ");
            var firstName = Console.ReadLine() ?? "n/a";
            Console.Write("Enter your last name: ");
            var lastName = Console.ReadLine() ?? "n/a";
            var fullName = $"{firstName} {lastName}";

            do
            {
                if (fullName.Equals("Admin Admin", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Admin mode");
                    Console.WriteLine("Available options:\n1. Print current results\n2. Log out\n3. Exit");
                    Console.Write("Enter option: ");
                    var option = Console.ReadLine() ?? "n/a";
                    if (option.Equals("1"))
                    {
                        PrintStatistics(users, fullName);
                    }
                    else if (option.Equals("2"))
                    {
                        Console.WriteLine("Logging out...");
                        break;
                    }
                    else if (option.Equals("3"))
                    {
                        keepRunning = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option");
                    }
                }
                else
                {
                    users.TryAdd(fullName, new int[2]);

                    Console.WriteLine(
                        "Available options:\n1. Flip a coin\n2. Print current results\n3. Log out\n4. Exit");
                    Console.Write("Enter option: ");
                    var option = Console.ReadLine() ?? "n/a";
                    if (option.Equals("1"))
                    {
                        var result = FlipCoin();
                        if (result.Equals("Heads"))
                            users[fullName][0]++;
                        else
                            users[fullName][1]++;
                    }
                    else if (option.Equals("2"))
                    {
                        PrintStatistics(users, fullName);
                    }
                    else if (option.Equals("3"))
                    {
                        Console.WriteLine("Logging out...");
                        break;
                    }
                    else if (option.Equals("4"))
                    {
                        keepRunning = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option");
                    }
                }
            } while (true);
        } while (keepRunning);

        Separator();
    }

    private static string FlipCoin()
    {
        var rnd = new Random();
        var result = rnd.Next(0, 2) == 0 ? "Heads" : "Tails";
        Console.Clear();
        Console.WriteLine($"Coin flip result: {result}");
        Console.WriteLine(new string('-', 5));
        return result;
    }

    private static void PrintStatistics(Dictionary<string, int[]> usersDictionary, string fullName)
    {
        var localDictionary = usersDictionary;

        if (!fullName.Equals("Admin Admin", StringComparison.OrdinalIgnoreCase))
            localDictionary = localDictionary
                .Where(u => u.Key.Equals(fullName))
                .ToDictionary(u => u.Key, u => u.Value);

        foreach (var user in localDictionary)
        {
            var userName = user.Key;
            var heads = user.Value[0];
            var tails = user.Value[1];
            var total = heads + tails;
            var headsPercentage = Math.Round((double)heads / total * 100, 2);
            var tailsPercentage = 100 - headsPercentage;

            Console.WriteLine($"User: {userName}\nHeads: {headsPercentage}%\nTails: {tailsPercentage}%");
            Console.WriteLine(new string('-', 5));
        }
    }
}