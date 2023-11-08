using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ConsoleApp1.Helpers;

namespace ConsoleApp1
{
    public static class Lecture5
    {
        public static void RunTasks()
        {
            Task_1_1("sMALL");
            Task_1_2("This is some text");
            Task_1_3("wowza", 11);
            Task_2_1("This text should get updated");
            Task_2_2("Pay attention to the saline seawater,\r\nthe saline seawater is the most desalinated h2o of all.\r\nShallow, saturated, saline seawater.\r\nDoes the saline seawater make you shiver?\r\ndoes it?", "saline seawater", "lulz");
            Task_2_3(27);
            Task_3_1("lowercase");
            Task_3_2("tractor");
            Task_3_3("Greetings!");
            //Task_4();
            //Task_5();
            Task_6("Matas", "Greta");
        }

        public static void Task_1_1(string wordToReplaceFirstLetter)
        {
            wordToReplaceFirstLetter = char.ToUpper(wordToReplaceFirstLetter[0]) + wordToReplaceFirstLetter.Substring(1);
            Console.WriteLine(wordToReplaceFirstLetter);
            Separator();
        }

        public static void Task_1_2(string textToManipulate)
        {
            if (string.IsNullOrEmpty(textToManipulate) || textToManipulate.Length < 10)
                return;

            char[] characters = textToManipulate.ToCharArray();

            characters[1] = 'g';
            characters[3] = 'b';
            characters[5] = 'v';
            characters[7] = 'x';
            characters[9] = 'w';

            string output = new string(characters);
            Console.WriteLine($"Modified text: {output}");
            Separator();
        }

        public static void Task_1_3(string textToManipulate, int encodeNumber)
        {
            if (textToManipulate.Length == 5)
            {
                string encodedMessage = "";

                foreach (char c in textToManipulate)
                {
                    string encodedCharValue = c.ToString() + encodeNumber;
                    encodedMessage += encodedCharValue;
                }
                Console.WriteLine($"Encoded message: {encodedMessage}");
            }
            else
            {
                Console.WriteLine("The text you entered is not 5 characters long.");
            }
            Separator();
        }

        public static void Task_2_1(string textToManipulate)
        {
            string updatedSentence = textToManipulate.Replace("a", "uo").Replace("i", "e");
            Console.WriteLine(updatedSentence);
            Separator();
        }

        public static void Task_2_2(string textToManipulate, string wordToReplace, string replacementWord)
        {
            string updatedText = textToManipulate.Replace(wordToReplace, replacementWord);
            Console.WriteLine(updatedText);
            Separator();
        }

        public static void Task_2_3(int age)
        {
            int ageDifference = 90 - age;

            if (ageDifference > 0)
            {
                int daysLeft = ageDifference * 365;
                int weeksLeft = ageDifference * 52;
                int monthsLeft = ageDifference * 12;

                Console.WriteLine($"You have {daysLeft} days, or {weeksLeft} weeks, or {monthsLeft} months, or {ageDifference} years left before you turn 90.");
            }
            else
            {
                Console.WriteLine("You're already 90 years old or more!");
            }
            Separator();
        }

        public static void Task_3_1(string input)
        {
            if (char.IsUpper(input[0]))
            {
                Console.WriteLine(input.ToUpper());
            }
            else
            {
                string capitalizedWord = char.ToUpper(input[0]) + input.Substring(1);
                Console.WriteLine(capitalizedWord);
            }
            Separator();
        }

        public static void Task_3_2(string input)
        {
            int indexOfA = input.IndexOf('a');

            if (indexOfA != -1)
            {
                Console.WriteLine($"The word '{input}' contains 'a' at index {indexOfA}.");
            }
            else
            {
                Console.WriteLine("Character 'a' not found.");
            }
            Separator();
        }

        public static void Task_3_3(string greeting)
        {
            if (greeting.ToLower().Equals("hello"))
            {
                Console.WriteLine("You entered 'hello'.");
            }
            else
            {
                string reversedWord = new string(greeting.Reverse().ToArray());
                Console.WriteLine($"The reversed word is: {reversedWord}");
            }
            Separator();
        }

        public static void Task_4()
        {
            var ingredients = new Dictionary<string, double>
            {
                {"bread", 1.00},
                {"salami", 0.50},
                {"feta cheese", 0.75},
                {"beans", 0.30},
                {"sauce", 0.25},
                {"tomato", 0.25},
                {"cucumber", 0.20},
                {"bacon", 0.75},
                {"chili peppers", 0.50},
                {"butter", 0.20},
                {"peas", 0.30},
                {"mozzarella", 0.60},
                {"parmesan", 0.80},
                {"rocket", 0.40}
            };

            var selectedIngredients = new List<string>();
            double totalPrice = 0.0;
            bool cheeseAdded = false;

            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"Would you like to add {ingredient.Key} for an extra ${ingredient.Value}? (yes/no)");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "yes")
                {
                    if (ingredient.Key.Contains("cheese") || ingredient.Key.Contains("mozzarella") || ingredient.Key.Contains("parmesan"))
                    {
                        if (!cheeseAdded)
                        {
                            selectedIngredients.Add(ingredient.Key);
                            totalPrice += ingredient.Value;
                            cheeseAdded = true;
                        }
                        else
                        {
                            Console.WriteLine("You can only add one type of cheese.");
                        }
                    }
                    else
                    {
                        selectedIngredients.Add(ingredient.Key);
                        totalPrice += ingredient.Value;
                    }
                }
            }

            Console.WriteLine("\nYour sandwich will contain:");
            foreach (var item in selectedIngredients)
            {
                Console.WriteLine($"\t- {item}");
            }
            Console.WriteLine($"The total price of the sandwich is: {totalPrice} EUR");
            Separator();
        }

        public static void Task_5()
        {
            var countryCodes = new Dictionary<string, string>
            {
                {"LT", "Lithuania"},
                {"EE", "Estonia"},
                {"LV", "Latvia"},
                {"DK", "Denmark"},
                {"UK", "United Kingdom"},
                {"GB", "United Kingdom"},
                {"NO", "Norway"},
                {"FI", "Finland"},
                {"SE", "Sweden"},
                {"AL", "Albania"},
                {"MD", "Moldova"},
                {"USA", "United States of America"}
            };

            var callRates = new Dictionary<string, double>
            {
                {"LT", 0.23},
                {"EE", 0.23},
                {"LV", 0.23},
                {"DK", 0.23},
                {"UK", 1.19},
                {"GB", 1.19},
                {"NO", 0.23},
                {"FI", 0.23},
                {"SE", 0.23},
                {"AL", 1.19},
                {"MD", 1.19},
                {"USA", 1.79}
            };

            Console.WriteLine("Enter the phone number to be called (start with country code):");
            string phoneNumber = Console.ReadLine().Trim().ToUpper();
            string countryCode = phoneNumber.Substring(0, 2);

            if (phoneNumber.StartsWith("USA"))
            {
                countryCode = "USA";
            }

            if (!countryCodes.TryGetValue(countryCode, out string countryName))
            {
                Console.WriteLine("Country code not recognized.");
                return;
            }

            Console.WriteLine($"The number is from {countryName}.");

            Console.WriteLine("How many minutes will the call be?");
            if (!int.TryParse(Console.ReadLine(), out int duration))
            {
                Console.WriteLine("Invalid input for call duration.");
                return;
            }

            double pricePerMinute = callRates[countryCode]; // 5 cents per minute for the sake of example
            double finalPrice = duration * pricePerMinute;

            Console.WriteLine($"Operator: Bite From Wish");
            Console.WriteLine($"Call to number: {phoneNumber}");
            Console.WriteLine($"Call time: {duration} min");
            Console.WriteLine($"Call price per minute: {pricePerMinute} EUR/min");
            Console.WriteLine($"Final call price: {finalPrice:0.00} EUR");
            Separator();
        }

        public static void Task_6(string firstName, string secondName)
        {
            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Second name: {secondName}");

            int loveScore1 = 0;
            int loveScore2 = 0;

            foreach (char c in "tikroji meile")
            {
                if (firstName.Contains(c)) loveScore1++;
                if (secondName.Contains(c)) loveScore2++;
            }

            int loveScore = int.Parse(string.Concat(loveScore1, loveScore2));

            Console.WriteLine($"Total -> {firstName}+{secondName} = {loveScore}");

            if (loveScore > 90 || (loveScore >= 30 && loveScore < 50))
            {
                Console.WriteLine("You are perfect for each other.");
            }
            else if (loveScore >= 50 && loveScore <= 70)
            {
                Console.WriteLine("You are right for each other.");
            }
            else
            {
                Console.WriteLine("The system can't tell if you're right for each other.");
            }
            Separator();
        }

    }
}
