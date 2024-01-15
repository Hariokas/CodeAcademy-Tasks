#region Description

/**************************************************************
 * The project is designed to warm up your skills for your final thesis. It will help you to understand what it feels like to develop a larger programme where both you and your teacher will have the opportunity to see where your strengths lie and where your skills could be improved (2-3 lessons)​
 * Create an application that allows you to log in using your first and last name. Once logged in, we would be able to solve quiz problems on a variety of topics. The app should allow users to see the results.
 **************************************************************/

/**************************************************************
 * Functionality:​
 *
 * Log in to​
 * Logout​
 * Representation of the game rules​
 * Review of game results and participants​
 * Participation (Start game)​
 * Exit the game​
 **************************************************************/

/**************************************************************
 * Windows:
 *
 * Window 1(Login): when you start the app, the app should greet you and ask you to log in. The first window should only ask for a first and last name. Nothing else is displayed.
 * Window 2(Menu): after logging in, the application should greet you when you log in and display the menu items (See list of functionality)
 * Window 3(Option): when one of the menu items is selected, the application should display what belongs to that menu option on the screen accordingly (See detailed requirements for menu items). The "q" input should bring us back to the menu.
 **************************************************************/

/**************************************************************
 * Log in:
 *
 * In the login window, you should be able to enter your name. After entering the name, our user should be registered as a new record. Recommendation to use Dictionary when storing users (We assume that there will not be a second identical first and last name). If we enter the name of an existing user, the program should warn us that we are currently using the account of an existing user. If it is a new account, the application should congratulate us on logging in and creating a new account.
 * When you have successfully logged in, it should bring up the menu items on the screen. During the application, remember to keep the currently connected user somewhere so that you know who is playing at the moment. For the active user you can create a new variable "CurrentUser" which will help your application to identify it during functions. At the top of the console, in all but the login window, we should see which user we are currently logged in with. When styling, you can use the Console.Clear() method to clear the window after the options and re-render
 **************************************************************/

/**************************************************************
 * Disconnection:
 *
 * The application should display that a logout has been performed and ask the user to enter their name to log back in.
 **************************************************************/

/**************************************************************
 * Representation of the game rules:
 *
 * The software should display the rules of the game. For example, you can take "Congratulations on joining the X Challenge app. This challenge allows you to choose from X categories of questions. Once you have selected a category, you will start the game and you will have to choose which is the correct answer to your question from 4 possible options."​
 * The program should ask the user to enter the letter "q" if they want to go back to the menu options​
 **************************************************************/

/**************************************************************
 * Review of game results and participants:
 *
 * Selecting this menu item should display an additional menu. Inside this menu we would have the option to choose whether we want to view participants or results. If we select participants then all current participants should be displayed. If we choose to view the results it should bring up all users in descending order of the number of points scored. The TOP10 should have the number of positions and the TOP3 should have an asterisk "*" at the end of their name depending on their position, e.g.: 1st place 1 star etc. Use the .Sort method.
 * Recommendation for additional conditions: if you are working with multiple question categories and decide to keep separate Highscores for multiple question categories you can use Dictionary<string, Dictionary<string, int>>. In this case, your list will hold the points for each name in each category. AccountDictionary<FirstName, CategoryDictionary<CategoryName, Tasks>>
 **************************************************************/

/**************************************************************
 * Participation (Start game):
 *
 * Depending on whether you are working with multiple categories, the software should output the category options. If you are working with a single category, the game should start and the first question should be output to the user. How many questions there should be per session is up to you. At the top of the console it should say how many questions there are at the moment e.g. 1/10. The user should know the result of the question as soon as they confirm their answer by writing their answer choice e.g. "1. Answer 1". The application should write how many points the user currently has. The application should ask the user questions until it reaches the number of questions you set for the session. When all the questions have been answered, it should display the user's results on the screen: which questions have been answered correctly, which have not. It should also display the final points scored and the position of this session among the highest scorers. The letter "q" should send the user back to the menu. As a guideline for questions you can use List<T> or Dictionary<T,K>.
 **************************************************************/

/**************************************************************
 * Exit the game:
 *
 * The app should close.
 **************************************************************/

/**************************************************************
 * Additional (Only do this if you have already done the basic functionality of the challenge)​
 *
 * Make the questions randomly selected from the possible questions​
 * Add multi-category options
 * Insert a hall help which should help you with the Random class to "tentatively" determine which answer is correct (This can be done by typing "s" and pressing "enter")
 * Insert help to rule out 2 incorrect options (This can be done by typing "d" and pressing "enter")
 * Make different questions worth different amounts of points depending on their complexity
 **************************************************************/

/**************************************************************
 * Additional (Only do this if you have already done the basic functionality of the challenge)​
 *
 * Extend the app so that when the app chooses what questions to ask the user, it chooses based on how often the question is answered correctly. For example, if you have question 5 which is answered by 100% of users and you have question 18 which is answered by only 10% of users, the program should give priority to question 18.
 * Insert an administrator login that has access to the additional menu option "Configurations". In this window you can select how many questions users should receive per session. Consider how the scoring weighting should be arranged when such a change is made, because if there were 10 questions before and now there are 15, then a person answering 10/10 would be counted as having answered less than 14/15.
 * Add a timer and create time limits for questions (Google helps)
 **************************************************************/

#endregion

namespace CodeAcademyNET8;

internal class Project
{
    private readonly Dictionary<string, Dictionary<string, int>> _accountDictionary = new();

    private readonly List<(string Category, string Question, List<string> Options, int CorrectAnswerIndex, int Points)>
        _questions = new()
        {
            //Geography
            ("Gaming", "In which game do players compete on the island of Erangel?",
                new List<string>
                    { "Fortnite", "PlayerUnknown's Battlegrounds", "Apex Legends", "Call of Duty: Warzone" }, 1, 10),
            ("Gaming", "What is the default player name in 'The Legend of Zelda'?",
                new List<string> { "Zelda", "Link", "Ganon", "Epona" }, 1, 10),
            ("Gaming", "Which video game character is known for saying 'It’s-a me, Mario'?",
                new List<string> { "Luigi", "Wario", "Mario", "Peach" }, 2, 5),
            ("Gaming", "What is the name of the city in the game 'Grand Theft Auto V'?",
                new List<string> { "Liberty City", "Vice City", "Los Santos", "San Andreas" }, 2, 10),
            ("Gaming", "Which company developed the game 'Halo'?",
                new List<string> { "Activision", "EA Sports", "Bungie", "Ubisoft" }, 2, 10),
            ("Gaming", "What year was the first 'Super Mario Bros.' game released?",
                new List<string> { "1983", "1985", "1987", "1989" }, 1, 10),
            ("Gaming", "Which game features a battle royale mode called 'Warzone'?",
                new List<string> { "Call of Duty: Modern Warfare", "Battlefield", "Fortnite", "PUBG" }, 0, 10),
            ("Gaming", "In 'Minecraft', which material is needed to make a torch?",
                new List<string> { "Flint", "Coal", "Stone", "Iron" }, 1, 5),
            ("Gaming", "What is the highest-selling video game of all time?",
                new List<string> { "Tetris", "Minecraft", "Grand Theft Auto V", "Super Mario Bros." }, 1, 10),
            ("Gaming", "Which character is known as the 'Pink Puffball' in gaming?",
                new List<string> { "Jigglypuff", "Kirby", "Peach", "Pikachu" }, 1, 10),

            // History questions
            ("History", "Who was the first President of the United States?",
                new List<string> { "Abraham Lincoln", "John Adams", "George Washington", "Thomas Jefferson" }, 2, 10),
            ("History", "In which year did the Titanic sink?", new List<string> { "1912", "1910", "1915", "1905" }, 0,
                10),
            ("History", "Which civilization built the Pyramids of Giza?",
                new List<string> { "Incan", "Mayan", "Aztec", "Egyptian" }, 3, 15),
            ("History", "What was the main language of the Roman Empire?",
                new List<string> { "Greek", "Latin", "Italian", "Aramaic" }, 1, 10),
            ("History", "Who wrote the Declaration of Independence?",
                new List<string> { "Benjamin Franklin", "George Washington", "John Adams", "Thomas Jefferson" }, 3, 15),
            ("History", "In which year did World War II end?", new List<string> { "1944", "1945", "1946", "1947" }, 1,
                10),
            ("History", "Who was the first woman to fly solo across the Atlantic Ocean?",
                new List<string> { "Amelia Earhart", "Valentina Tereshkova", "Sally Ride", "Harriet Quimby" }, 0, 10),
            ("History", "What was the longest dynasty in Chinese history?",
                new List<string> { "Han Dynasty", "Ming Dynasty", "Qing Dynasty", "Tang Dynasty" }, 2, 15),
            ("History", "Which empire was known as the 'Land of the Rising Sun'?",
                new List<string> { "Mongol Empire", "Ottoman Empire", "Roman Empire", "Japanese Empire" }, 3, 10),
            ("History", "During which period did the Renaissance primarily occur?",
                new List<string>
                    { "14th to 17th century", "12th to 15th century", "16th to 19th century", "10th to 13th century" },
                0, 15),

            // Technology questions
            ("Technology", "What does 'HTTP' stand for?",
                new List<string>
                {
                    "HyperTool Transfer Protocol", "HyperText Transfer Protocol", "HighText Transfer Protocol",
                    "HyperText Transmission Protocol"
                }, 1, 10),
            ("Technology", "Who is known as the father of computer science?",
                new List<string> { "Alan Turing", "Charles Babbage", "Ada Lovelace", "John von Neumann" }, 0, 15),
            ("Technology", "In which year was the World Wide Web invented?",
                new List<string> { "1983", "1989", "1991", "1995" }, 1, 10),
            ("Technology", "What is the name of the first electronic general-purpose computer?",
                new List<string> { "ENIAC", "IBM PC", "Apple I", "UNIVAC" }, 0, 15),
            ("Technology", "Which company developed the Java programming language?",
                new List<string> { "Microsoft", "Sun Microsystems", "Apple", "IBM" }, 1, 10),
            ("Technology", "What does 'CPU' stand for in computing?",
                new List<string>
                {
                    "Central Processing Unit", "Computer Processing Unit", "Central Performance Unit",
                    "Centralized Program Unit"
                }, 0, 10),
            ("Technology", "Which operating system is open source?",
                new List<string> { "Windows", "iOS", "Android", "macOS" }, 2, 10),
            ("Technology", "What is the main function of a computer's RAM?",
                new List<string>
                    { "Store data permanently", "Process data", "Store data temporarily", "Improve graphics" }, 2, 10),
            ("Technology", "Who is the co-founder of Microsoft alongside Bill Gates?",
                new List<string> { "Steve Jobs", "Paul Allen", "Steve Wozniak", "Mark Zuckerberg" }, 1, 10),
            ("Technology", "Which technology is used to record cryptocurrency transactions?",
                new List<string> { "Blockchain", "SQL Database", "Cloud Storage", "Data Mining" }, 0, 15),

            // Science questions
            ("Science", "What is the chemical symbol for water?", new List<string> { "H2O", "HO2", "H2", "OH" }, 0, 5),
            ("Science", "What force keeps us on the ground?",
                new List<string> { "Friction", "Inertia", "Gravity", "Magnetism" }, 2, 10),
            ("Science", "Which planet is known as the Red Planet?",
                new List<string> { "Venus", "Mars", "Jupiter", "Mercury" }, 1, 10),
            ("Science", "What is the process by which plants make their food?",
                new List<string> { "Osmosis", "Respiration", "Photosynthesis", "Fermentation" }, 2, 10),
            ("Science", "What is the largest organ in the human body?",
                new List<string> { "Heart", "Skin", "Liver", "Brain" }, 1, 10),
            ("Science", "Which element has the atomic number 1?",
                new List<string> { "Oxygen", "Hydrogen", "Helium", "Nitrogen" }, 1, 5),
            ("Science", "What type of animal is a Komodo dragon?",
                new List<string> { "Lizard", "Bird", "Mammal", "Fish" }, 0, 10),
            ("Science", "What is the boiling point of water in Celsius?",
                new List<string> { "90°C", "100°C", "80°C", "110°C" }, 1, 5),
            ("Science", "How many bones are in the adult human body?", new List<string> { "206", "205", "208", "210" },
                0, 10),
            ("Science", "Which gas is most abundant in the Earth’s atmosphere?",
                new List<string> { "Oxygen", "Carbon Dioxide", "Nitrogen", "Hydrogen" }, 2, 10),

            // Sports questions
            ("Sports", "Which country won the 2018 FIFA World Cup?",
                new List<string> { "Germany", "Brazil", "France", "Argentina" }, 2, 10),
            ("Sports", "What is the highest score in a single round of golf called?",
                new List<string> { "Eagle", "Birdie", "Albatross", "Bogey" }, 2, 15),
            ("Sports", "In tennis, what is a zero score called?", new List<string> { "Love", "Null", "Zero", "Ace" }, 0,
                10),
            ("Sports", "Which sport is known as 'the sport of kings'?",
                new List<string> { "Polo", "Horse Racing", "Fencing", "Archery" }, 1, 10),
            ("Sports", "In which sport would you perform the Fosbury Flop?",
                new List<string> { "Diving", "Pole Vault", "High Jump", "Gymnastics" }, 2, 15),
            ("Sports", "Who holds the record for the most Grand Slam tennis titles?",
                new List<string> { "Serena Williams", "Roger Federer", "Rafael Nadal", "Margaret Court" }, 3, 10),
            ("Sports", "In basketball, how many points is a shot made from outside of the three-point line worth?",
                new List<string> { "Two Points", "Four Points", "Three Points", "Five Points" }, 2, 5),
            ("Sports", "Where were the first modern Olympic Games held?",
                new List<string> { "Athens", "Paris", "London", "Rome" }, 0, 10),
            ("Sports", "What is the term for when a bowler makes three consecutive strikes in bowling?",
                new List<string> { "Turkey", "Eagle", "Hawk", "Sparrow" }, 0, 10),
            ("Sports", "Which sport is played on the largest field in terms of area?",
                new List<string> { "Rugby", "Football", "Polo", "Cricket" }, 2, 15),

            //Cars questions
            ("Cars", "Which company manufactures the 'Mustang'?",
                new List<string> { "Chevrolet", "Ford", "Dodge", "Tesla" }, 1, 10),
            ("Cars", "In which country was the car brand 'Volvo' founded?",
                new List<string> { "Germany", "Sweden", "USA", "Japan" }, 1, 10),
            ("Cars", "What does 'BMW' stand for in English?",
                new List<string>
                    { "Bavarian Motor Works", "Berlin Motor Works", "British Motor Works", "Baltic Motor Works" }, 0,
                10),
            ("Cars", "Which car is often referred to as the first muscle car?",
                new List<string> { "Chevrolet Camaro", "Pontiac GTO", "Ford Mustang", "Dodge Charger" }, 1, 15),
            ("Cars", "What type of engine does a 'Tesla Model S' use?",
                new List<string> { "Hybrid", "Gasoline", "Diesel", "Electric" }, 3, 10),
            ("Cars", "Which car company created the 'Civic'?",
                new List<string> { "Toyota", "Honda", "Hyundai", "Nissan" }, 1, 10),
            ("Cars", "What does the acronym 'ABS' stand for in car features?",
                new List<string>
                {
                    "Automatic Braking System", "Advanced Braking System", "Anti-lock Braking System",
                    "Automated Brake Support"
                }, 2, 10),
            ("Cars", "Which of these cars is a famous model by Ferrari?",
                new List<string> { "Enzo", "Diablo", "Veyron", "Aventador" }, 0, 15),
            ("Cars", "What is the primary function of a car's radiator?",
                new List<string>
                    { "Cooling the engine", "Heating the interior", "Filtering the oil", "Charging the battery" }, 0,
                10),
            ("Cars", "Which company is known for producing the '911' model?",
                new List<string> { "BMW", "Audi", "Porsche", "Mercedes-Benz" }, 2, 10),

            // C# questions
            ("C#", "Which of these keywords is used to declare a constant in C#?",
                new List<string> { "const", "static", "readonly", "var" }, 0, 10),
            ("C#", "What is the correct way to declare an integer variable 'x' in C#?",
                new List<string> { "int x;", "integer x;", "var x = int;", "x = int();" }, 0, 5),
            ("C#", "Which of the following is a value type in C#?",
                new List<string> { "String", "Int32", "Object", "Class" }, 1, 10),
            ("C#", "What does 'LINQ' stand for?",
                new List<string>
                {
                    "Language Integrated Query", "Language Interface Query", "Linked Integrated Query",
                    "Linked Interface Query"
                }, 0, 15),
            ("C#", "Which method is used to convert a string to an integer in C#?",
                new List<string> { "ToInt32()", "Convert.ToInt32()", "ParseInt()", "Cast.ToInt()" }, 1, 10),
            ("C#", "What is the entry point of a C# console application?",
                new List<string> { "Main()", "Start()", "Run()", "Init()" }, 0, 5),
            ("C#", "Which of these is NOT a valid access modifier in C#?",
                new List<string> { "protected", "private", "readonly", "public" }, 2, 10),
            ("C#", "What keyword is used to handle exceptions in C#?",
                new List<string> { "try", "throw", "catch", "finally" }, 2, 10),
            ("C#", "Which of these data types is used to store a true/false value in C#?",
                new List<string> { "int", "bool", "string", "char" }, 1, 5),
            ("C#", "In C#, 'string' is an alias for which .NET type?",
                new List<string> { "System.String", "System.Text", "System.Str", "System.CharArray" }, 0, 10)
        };

    private Dictionary<string, int> _categoriesAndPoints = new();

    private string _currentUser = "";

    public static void InitializeGame()
    {
        var project = new Project();
        project.StartLoop();
    }

    private void StartLoop()
    {
        _categoriesAndPoints = CalculateMaxPointsPerCategory(_questions);
        PrintBanner();
        PrintGreeting();
        Login();

        while (true)
        {
            ShowMenu();
            var input = Console.ReadLine();
            SelectMenuOption(input);
        }
    }

    private void ShowMenu()
    {
        PrintInGreen("Please select one of the following options:");
        PrintInBlue("1. Game rules");
        PrintInBlue("2. Review of game results and participants");
        PrintInBlue("3. Participation (Start game)");
        PrintInBlue("4. Logout");
        PrintInBlue("5. Exit the game");
    }

    private void SelectMenuOption(string input)
    {
        switch (input)
        {
            case "1":
                ShowGameRules();
                break;
            case "2":
                ShowResults();
                break;
            case "3":
                StartGame();
                break;
            case "4":
                Login();
                break;
            case "5":
                ExitGame();
                break;
            default:
                PrintInRed("Invalid input. Please try again.");
                Console.WriteLine();
                break;
        }
    }

    private void ShowGameRules()
    {
        Console.WriteLine();
        PrintInGreen("Game rules:");
        PrintInBlue("* Log in with your name to start.");
        PrintInBlue("* Choose a category and answer questions with four options.");
        PrintInBlue("* Earn points for correct answers; harder questions give more points.");
        PrintInBlue("* See your score and question progress during the game.");
        PrintInBlue("* Get instant feedback after each answer.");
        PrintInBlue("* View total score and correct answers at the end.");
        PrintInBlue("* Use lifelines like '50/50' for help.");
        PrintInBlue("* Questions are randomly selected for variety.");
        PrintInBlue("* Press 'q' to return to the main menu anytime.");
        PrintInBlue("* Log out or exit from the main menu.");
        PrintInBlue("* Enjoy and aim for a high score!");
        Console.WriteLine();
    }

    private void ShowResults()
    {
        Console.WriteLine();
        PrintInGreen("Review of game results and participants");
        foreach (var user in _accountDictionary)
        {
            PrintInGreen(user.Key);

            foreach (var category in user.Value)
                PrintInBlue($"{category.Key}: {category.Value}/{_categoriesAndPoints[category.Key]}");

            Console.WriteLine();
        }
    }

    private void StartGame()
    {
        Console.WriteLine();
        PrintInGreen("Participation (Start game)");

        var inQuestionnaire = true;

        while (inQuestionnaire)
        {
            PrintInGreen("Please select one of the following categories:");
            PrintInBlue("1. Gaming");
            PrintInBlue("2. History");
            PrintInBlue("3. Technology");
            PrintInBlue("4. Science");
            PrintInBlue("5. Sports");
            PrintInBlue("6. Cars");
            PrintInBlue("7. C#");
            PrintInBlue("8. Random questions");
            PrintInRed("Type 'q' to return to main menu");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StartQuestionnaire("Gaming");
                    break;
                case "2":
                    StartQuestionnaire("History");
                    break;
                case "3":
                    StartQuestionnaire("Technology");
                    break;
                case "4":
                    StartQuestionnaire("Science");
                    break;
                case "5":
                    StartQuestionnaire("Sports");
                    break;
                case "6":
                    StartQuestionnaire("Cars");
                    break;
                case "7":
                    StartQuestionnaire("C#");
                    break;
                case "8":
                    StartQuestionnaire("Random");
                    break;
                case "q":
                    inQuestionnaire = false;
                    break;
                default:
                    PrintInRed("Invalid input. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    private void StartQuestionnaire(string topic)
    {
        List<(string Category, string Question, List<string> Options, int CorrectAnswerIndex, int Points)> questions =
            GetQuestions(topic);

        var canHaveHallHelp = true;
        var canHaveFiftyFiftyHelp = true;

        foreach (var question in questions)
        {
            PrintBanner();
            PrintInGreen(question.Question);
            Console.WriteLine();

            for (var i = 0; i < question.Options.Count; i++) Console.WriteLine($"{i + 1}. {question.Options[i]}");

            Console.WriteLine();
            string input;

            do
            {
                PrintInGreen("Please select your answer ('q' to return back): ");

                if (canHaveFiftyFiftyHelp)
                    PrintInGreen("Press 'd' to use 50/50 help");

                if (canHaveHallHelp)
                    PrintInGreen("Press 's' to use hall help");

                input = Console.ReadLine();

                if (input.Equals("q"))
                {
                    PrintInRed("Are you sure you want to quit? (y/n)");
                    var quit = Console.ReadLine();
                    if (quit.Equals("y"))
                        break;
                }

                switch (input)
                {
                    case "d" when canHaveFiftyFiftyHelp:
                        GetFiftyFiftyHelp(question);
                        canHaveFiftyFiftyHelp = false;
                        continue;
                    case "s" when canHaveHallHelp:
                        GetHallHelp(question);
                        canHaveHallHelp = false;
                        continue;
                }

                if (!int.TryParse(input, out var number)) continue;

                if (number > 0 && number <= question.Options.Count)
                    break;
            } while (true);

            if (input.Equals("q"))
                break;

            var answer = int.Parse(input) - 1;

            if (IsAnswerCorrect(answer, question.CorrectAnswerIndex))
            {
                PrintInGreen("Correct answer! 🎉");
                Console.WriteLine();
                AddPointsToUser(question.Points, question.Category);
            }
            else
            {
                PrintInRed("Wrong answer! 😢");
                Console.WriteLine($"Correct answer was: {question.Options[question.CorrectAnswerIndex]}");
                Console.WriteLine();
            }

            Console.Write("Press any key to continue!");
            Console.ReadKey();
        }
    }

    private List<(string, string, List<string>, int, int)> GetQuestions(string topic)
    {
        List<(string Category, string Question, List<string> Options, int CorrectAnswerIndex, int Points)> questions =
            new();

        if (!topic.Equals("Random"))
            return _questions.Where(q => q.Category.Equals(topic)).ToList();

        for (var i = 0; i < 10; i++)
        {
            var random = new Random();
            var index = random.Next(0, _questions.Count);

            if (!questions.Contains(_questions[index]))
                questions.Add(_questions[index]);
        }

        questions.Sort();
        return questions;
    }

    private void ExitGame()
    {
        PrintBanner();

        PrintInGreen($"Thank you for playing the Test-Your-Wisdom Challenge {_currentUser}! ❤️");
        PrintInRed("Press any key to exit the game.");

        Console.ReadKey();
        Environment.Exit(0);
    }

    private void PrintGreeting()
    {
        PrintInGreen("Welcome to the Test-Your-Wisdom Challenge.");
        Console.WriteLine("This challenge allows you to choose from 7 categories of questions.");
        Console.WriteLine(
            "Once you have selected a category, you will start the game and you will have to choose which is the correct answer to your question from 4 possible options.");
        Console.WriteLine();
    }

    private void Login()
    {
        PrintInGreen("Please enter your first name: ");
        var firstName = Console.ReadLine();
        firstName = string.IsNullOrWhiteSpace(firstName) ? "Anonymous" : firstName;

        PrintInGreen("Please enter your last name: ");
        var lastName = Console.ReadLine() ?? "User";
        lastName = string.IsNullOrWhiteSpace(lastName) ? "User" : lastName;

        Console.WriteLine($"Congratulations on joining the Test-Your-Wisdom Challenge app {firstName}!");
        _currentUser = firstName + " " + lastName;

        if (!_accountDictionary.TryAdd(_currentUser, new Dictionary<string, int>()))
            Console.WriteLine("You are currently using the account of an existing user.");

        Console.WriteLine();
    }

    private bool IsAnswerCorrect(int answer, int correctAnswerIndex)
    {
        return answer == correctAnswerIndex;
    }

    private void AddPointsToUser(int points, string questionCategory)
    {
        if (!_accountDictionary[_currentUser].TryAdd(questionCategory, points))
            _accountDictionary[_currentUser][questionCategory] += points;
    }

    private void GetHallHelp(
        (string Category, string Question, List<string> Options, int CorrectAnswerIndex, int Points) question)
    {
        var random = new Random();
        var totalPercentage = 100;
        var percentages = new int[question.Options.Count];

        percentages[question.CorrectAnswerIndex] = random.Next(40, 61);
        totalPercentage -= percentages[question.CorrectAnswerIndex];

        // Distribute the remaining percentages randomly among other options
        for (var i = 0; i < question.Options.Count; i++)
            if (i != question.CorrectAnswerIndex)
            {
                var assignedPercentage = random.Next(0, totalPercentage);
                percentages[i] = assignedPercentage;
                totalPercentage -= assignedPercentage;
            }

        // If there's any leftover percentage, add it to one of the incorrect options
        if (totalPercentage > 0)
            for (var i = 0; i < question.Options.Count; i++)
                if (i != question.CorrectAnswerIndex)
                {
                    percentages[i] += totalPercentage;
                    break;
                }

        Console.WriteLine();
        PrintInBlue("Hall help:");
        for (var i = 0; i < question.Options.Count; i++)
            Console.WriteLine($"{i + 1}. {question.Options[i]} - {percentages[i]}% audience support");
    }

    private void GetFiftyFiftyHelp(
        (string Category, string Question, List<string> Options, int CorrectAnswerIndex, int Points) question)
    {
        var random = new Random();
        var incorrectOptions = new List<int>();

        for (var i = 0; i < question.Options.Count; i++)
            if (i != question.CorrectAnswerIndex)
                incorrectOptions.Add(i);

        while (incorrectOptions.Count > 1)
            incorrectOptions.RemoveAt(random.Next(incorrectOptions.Count));

        Console.WriteLine();
        PrintInBlue("50/50 help:");
        for (var i = 0; i < question.Options.Count; i++)
            if (i == question.CorrectAnswerIndex || incorrectOptions.Contains(i))
                Console.WriteLine($"50% -> {question.Options[i]}");
    }

    private Dictionary<string, int> CalculateMaxPointsPerCategory(
        List<(string Category, string Question, List<string> Options, int CorrectAnswerIndex, int Points)> questions)
    {
        var categoriesAndPoints = new Dictionary<string, int>();

        foreach (var question in questions)
            if (!categoriesAndPoints.TryAdd(question.Category, 0))
                categoriesAndPoints[question.Category] += question.Points;

        return categoriesAndPoints;
    }

    private void PrintBanner()
    {
        const string banner = """
                              
                               ______    ___  _____ ______      __ __   ___   __ __  ____       __    __  ____ _____ ___     ___   ___ ___
                              |      |  /  _]/ ___/|      |    |  |  | /   \ |  |  ||    \     |  |__|  ||    / ___/|   \   /   \ |   |   |
                              |      | /  [_(   \_ |      |    |  |  ||     ||  |  ||  D  )    |  |  |  | |  (   \_ |    \ |     || _   _ |
                              |_|  |_||    _]\__  ||_|  |_|    |  ~  ||  O  ||  |  ||    /     |  |  |  | |  |\__  ||  D  ||  O  ||  \_/  |
                                |  |  |   [_ /  \ |  |  |      |___, ||     ||  :  ||    \     |  `  '  | |  |/  \ ||     ||     ||   |   |
                                |  |  |     |\    |  |  |      |     ||     ||     ||  .  \     \      /  |  |\    ||     ||     ||   |   |
                                |__|  |_____| \___|  |__|      |____/  \___/  \__,_||__|\_|      \_/\_/  |____|\___||_____| \___/ |___|___|
                                                                                                                                           
                              
                              """;
        Console.Clear();
        foreach (var line in banner.Split("\n"))
        {
            PrintInGreen(line);
            Thread.Sleep(100);
        }
    }

    private void PrintInGreen(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void PrintInRed(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void PrintInBlue(string text)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }
}