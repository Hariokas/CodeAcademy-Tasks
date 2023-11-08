using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Helpers;

namespace ConsoleApp1
{
    public static class Lecture4
    {
        public static void RunTasks()
        {
            Task_1_1(5);
            Task_1_2(25);
            Task_1_3(7);
            Task_2_1();
            Task_2_2();
            Task_2_3("cs", 7.5, 82.4);
            Task_3_1(4);
            Task_3_2("root", 17, 24);
            Task_3_3("EUR", 100);
        }

        private static void Task_1_1(int dayNumber)
        {
            Console.WriteLine($"{dayNumber} --> {((DayOfWeek)(dayNumber % 7)).ToString()}");
            Separator();
        }

        private static void Task_1_2(int age)
        {
            Console.WriteLine(age);
            switch (age)
            {
                case >= 7 and <= 18:
                    Console.WriteLine("Student");
                    break;
                case >= 19 and <= 25:
                    Console.WriteLine("Student");
                    break;
                case >= 26 and <= 65:
                    Console.WriteLine("Employee");
                    break;
                case > 66:
                    Console.WriteLine("Retired");
                    break;
            }
            Separator();
        }

        private static void Task_1_3(int monthNumber)
        {
            string monthName = new DateTime(DateTime.Now.Year, monthNumber, DateTime.Now.Day).ToString("MMMM", CultureInfo.InvariantCulture);
            Console.WriteLine($"{monthNumber} --> {monthName}");
            Separator();
        }

        private static void Task_2_1()
        {
            Console.WriteLine("Select a shape: square / circle / triangle / rectangle");
            var shapeName = Console.ReadLine().Trim();
            Console.WriteLine($"Selected shape: {shapeName}");

            switch (shapeName.ToLower().Trim())
            {
                case "square":
                    Console.WriteLine("What's the length of the border?:");
                    double borderLength = double.Parse(Console.ReadLine());
                    double squareArea = borderLength * borderLength;
                    Console.WriteLine($"Area of a square: {squareArea}");
                    break;

                case "circle":
                    Console.WriteLine("What's the radius?:");
                    double radius = double.Parse(Console.ReadLine());
                    double circleArea = Math.PI * Math.Pow(radius, 2);
                    Console.WriteLine($"Area of the circle: {circleArea}");
                    break;

                case "triangle":
                    Console.WriteLine("What's the height of triangle?:");
                    double triangleHeight = double.Parse(Console.ReadLine());
                    Console.WriteLine("What's the length of the border?:");
                    double triangleBorder = double.Parse(Console.ReadLine());
                    double triangleArea = 0.5 * triangleHeight * triangleBorder;
                    Console.WriteLine($"Area of the triangle: {triangleArea}");
                    break;

                case "rectangle":
                    Console.WriteLine("What's the length of the short border?:");
                    double shortBorder = double.Parse(Console.ReadLine());
                    Console.WriteLine("What's the length of the long border?:");
                    double longBorder = double.Parse(Console.ReadLine());
                    double rectangleArea = shortBorder * longBorder;
                    Console.WriteLine($"Area of the rectangle: {rectangleArea}");
                    break;

                default:
                    Console.WriteLine("Unknown shape.");
                    break;
            }

            Separator();
        }

        private static void Task_2_2()
        {
            Console.WriteLine("Please select one of the elements: Fire / Water / Air / Earth / Ether");
            string element = Console.ReadLine().Trim();

            switch (element.ToLower())
            {
                case "fire":
                    Console.WriteLine("It's really hot, trust me");
                    break;

                case "water":
                    Console.WriteLine("The thing that can be in 3 states - frozen, liquid, gas");
                    break;

                case "air":
                    Console.WriteLine("Manual breathing mode - go!");
                    break;

                case "earth":
                    Console.WriteLine("Hello, earth???");
                    break;

                case "ether":
                    Console.WriteLine("Is this a crypto?");
                    break;

                default:
                    Console.WriteLine("Sorry, there's no selection for avatar :(");
                    break;
            }
            Separator();
        }

        private static void Task_2_3(string major, double averageGrade, double attendanceRate)
        {
            Console.WriteLine("Choose the major: maths / CS / biology / chemistry");
            Console.WriteLine($"Your major: {major}");

            double userChance = 0;
            switch (major.ToLower())
            {
                case "math":
                    userChance = ((averageGrade / 7.5) * 100) + ((attendanceRate / 83) * 100) / 2;
                    Console.WriteLine($"Your chance of getting a math admission: {userChance}%");
                    break;

                case "cs":
                    userChance = ((averageGrade / 7.3) * 100) + ((attendanceRate / 90) * 100) / 2;
                    Console.WriteLine($"Your chance of getting a computer science admission: {userChance}%");
                    break;

                case "biology":
                    userChance = ((averageGrade / 8) * 100) + ((attendanceRate / 81) * 100) / 2;
                    Console.WriteLine($"Your chance of getting a biology admission: {userChance}%");
                    break;

                case "chemistry":
                    userChance = ((averageGrade / 9.2) * 100) + ((attendanceRate / 84) * 100) / 2;
                    Console.WriteLine($"Your chance of getting a chemistry admission: {userChance}%");
                    break;

                default:
                    Console.WriteLine("Unknown major");
                    break;
            }
            Separator();
        }

        private static void Task_3_1(int monthNumber)
        {
            Console.WriteLine($"Month number: {monthNumber}");
            switch (monthNumber)
            {
                case 2:
                case 3:
                case 4:
                    Console.WriteLine("Spring");
                    break;

                case 5:
                case 6:
                case 7:
                    Console.WriteLine("Summer");
                    break;

                case 8:
                case 9:
                case 10:
                    Console.WriteLine("Autumn");
                    break;

                case 1:
                case 11:
                case 12:
                    Console.WriteLine("Winter");
                    break;
            }
            Separator();
        }

        private static void Task_3_2(string mathOperation, double num1, double num2)
        {
            Console.Write($"Selected operation: {mathOperation} for numbers {num1} and {num2}\nResult: ");
            switch (mathOperation.ToLower().Trim())
            {
                case "addition":
                    Console.WriteLine(num1 + num2);
                    break;

                case "subtraction":
                    Console.WriteLine(num1 - num2);
                    break;

                case "multiplication":
                    Console.WriteLine(num1 * num2);
                    break;

                case "division":
                    Console.WriteLine(num1 / num2);
                    break;

                case "squaring":
                    Console.WriteLine(Math.Pow(num1, num2));
                    break;

                case "root":
                    Console.WriteLine(Math.Pow(num1, 1.0 / num2));
                    break;

                default:
                    Console.WriteLine("Unknown operation");
                    break;
            }
            Separator();
        }

        private static void Task_3_3(string fromCurrency, decimal amount)
        {
            const decimal EURtoUSD = 1.1m;
            const decimal EURtoJPY = 130m;
            const decimal EURtoGBP = 0.85m;

            const decimal USDtoEUR = 1 / EURtoUSD;
            const decimal USDtoJPY = 118m;
            const decimal USDtoGBP = 0.77m;

            const decimal JPYtoEUR = 1 / EURtoJPY;
            const decimal JPYtoUSD = 1 / USDtoJPY;
            const decimal JPYtoGBP = 0.0065m;

            const decimal GBPtoEUR = 1 / EURtoGBP;
            const decimal GBPtoUSD = 1 / USDtoGBP;
            const decimal GBPtoJPY = 1 / JPYtoGBP;

            decimal toEUR, toUSD, toJPY, toGBP;

            switch (fromCurrency)
            {
                case "EUR":
                    toUSD = amount * EURtoUSD;
                    toJPY = amount * EURtoJPY;
                    toGBP = amount * EURtoGBP;
                    Console.WriteLine($"{amount} EUR is {toUSD} USD");
                    Console.WriteLine($"{amount} EUR is {toJPY} JPY");
                    Console.WriteLine($"{amount} EUR is {toGBP} GBP");
                    break;

                case "USD":
                    toEUR = amount * USDtoEUR;
                    toJPY = amount * USDtoJPY;
                    toGBP = amount * USDtoGBP;
                    Console.WriteLine($"{amount} USD is {toEUR} EUR");
                    Console.WriteLine($"{amount} USD is {toJPY} JPY");
                    Console.WriteLine($"{amount} USD is {toGBP} GBP");
                    break;

                case "JPY":
                    toEUR = amount * JPYtoEUR;
                    toUSD = amount * JPYtoUSD;
                    toGBP = amount * JPYtoGBP;
                    Console.WriteLine($"{amount} JPY is {toEUR} EUR");
                    Console.WriteLine($"{amount} JPY is {toUSD} USD");
                    Console.WriteLine($"{amount} JPY is {toGBP} GBP");
                    break;

                case "GBP":
                    toEUR = amount * GBPtoEUR;
                    toUSD = amount * GBPtoUSD;
                    toJPY = amount * GBPtoJPY;
                    Console.WriteLine($"{amount} GBP is {toEUR} EUR");
                    Console.WriteLine($"{amount} GBP is {toUSD} USD");
                    Console.WriteLine($"{amount} GBP is {toJPY} JPY");
                    break;

                default:
                    Console.WriteLine("Unknown currency.");
                    break;
            }
            Separator();
        }

    }
}
