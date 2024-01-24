using System.Diagnostics;
using System.Text;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class Streams
{
    private const string FileWithTextPath =
        @"C:\Dev\CodeAcademyNET8\CodeAcademyNET8\Advanced - OOP\Classes\Streams\FileWithText.txt";

    private const string BigFileWithTextPath =
        @"C:\Dev\CodeAcademyNET8\CodeAcademyNET8\Advanced - OOP\Classes\Streams\BigFileWithText.txt";

    private static readonly char[] Chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

    public static void RunTasks()
    {
        //Task1_1();
        //Task1_2();
        //Task1_3();
        //Task2_1();
        //Task2_2();
        //Task2_3();
        Task3_1();
    }

    private static void Task1_1()
    {
        var lines = File.ReadAllLines(FileWithTextPath);

        foreach (var line in lines)
            Console.WriteLine(line);

        Separator();
    }

    private static void Task1_2()
    {
        var text = new List<string>
        {
            "I'd tell you a chemistry joke, but I know I wouldn't get a reaction.",
            "Why don't some couples go to the gym? Because some relationships don't work out!",
            "I'm reading a book on anti-gravity. It's impossible to put down.",
            "Did you hear about the mathematician who’s afraid of negative numbers? He’ll stop at nothing to avoid them.",
            "I would tell you a joke about an elevator, but it's an uplifting experience I don't want to spoil."
        };

        var newFilePath = Path.Combine(Directory.GetParent(FileWithTextPath)!.FullName,
            "ListOfStrings.txt");

        Console.WriteLine($"Writing List<string> to a file at: [{newFilePath}]");
        File.WriteAllLines(newFilePath, text);

        Separator();
    }

    private static void Task1_3()
    {
        var destinationPath = Path.Combine("C:\\temp", Path.GetFileName(FileWithTextPath));
        Console.WriteLine($"Copying [{FileWithTextPath}] to [{destinationPath}]");
        File.Copy(FileWithTextPath, destinationPath, true);

        Separator();
    }

    private static void Task2_1()
    {
        var charCount = File.ReadLines(BigFileWithTextPath).Sum(line => line.Length);

        Console.WriteLine($"Number of characters in [{Path.GetFileName(BigFileWithTextPath)}]: [{charCount}]");

        Separator();
    }

    private static void Task2_2()
    {
        var linesCount = Random.Shared.Next(1, 51);

        var bigFileWithRandomTextPath =
            Path.Combine(Directory.GetParent(FileWithTextPath)!.FullName, "BigFileWithRandomText.txt");

        using (var sw = new StreamWriter(bigFileWithRandomTextPath))
        {
            for (var i = 0; i < linesCount; i++)
            {
                var stringChars = new char[Random.Shared.Next(Chars.Length)];

                for (var j = 0; j < stringChars.Length; j++)
                    stringChars[j] = Chars[Random.Shared.Next(Chars.Length)];

                var line = new string(stringChars);
                sw.WriteLine(line);
                Console.WriteLine($"Writing [{line.Length}] characters");
            }
        }

        Console.WriteLine($"Created file with [{linesCount}] lines at: [{bigFileWithRandomTextPath}]");

        Separator();
    }

    private static void Task2_3()
    {
        var bufferSize = 1024;
        var buffer = new byte[bufferSize];
        var binaryOutputFile = Path.Combine(Directory.GetParent(BigFileWithTextPath)!.FullName,
            "BinaryOutputFile.txt");

        if (File.Exists(binaryOutputFile)) File.Delete(binaryOutputFile);

        using (var fs = new FileStream(BigFileWithTextPath, FileMode.Open, FileAccess.Read))
        using (var br = new BinaryReader(fs))
        using (var bw = new BinaryWriter(new FileStream(binaryOutputFile, FileMode.Create)))
        {
            var bytesRead = 0;
            var totalBytesRead = 0;

            while ((bytesRead = br.Read(buffer, 0, bufferSize)) > 0)
            {
                bw.Write(buffer, 0, bytesRead);
                totalBytesRead += bytesRead;
                Console.WriteLine($"Bytes read: [{bytesRead}]");
            }

            Console.WriteLine($"Total bytes read: [{totalBytesRead}]");
        }

        Separator();
    }

    private static void Task3_1()
    {
        var filePath = "C:\\temp\\FileWithText.txt";
        var stopwatch = new Stopwatch();
        long bufferSize = 1024 * 1024; // 1MB

        stopwatch.Start();
        using (var fileStream = new FileStream(filePath, FileMode.Open))
        {
            var buffer = new byte[bufferSize];
            while (fileStream.Read(buffer, 0, buffer.Length) > 0)
            {
                // Make coffee
            }
        }

        stopwatch.Stop();
        Console.WriteLine($"FileStream: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Reset();

        stopwatch.Start();
        using (var reader = new StreamReader(filePath, Encoding.UTF8))
        {
            var buffer = new char[bufferSize];
            while (reader.Read(buffer, 0, buffer.Length) > 0)
            {
                // Sip coffee
            }
        }

        stopwatch.Stop();
        Console.WriteLine($"StreamReader (chunk reading): {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Reset();

        //stopwatch.Start();
        //File.ReadAllText(filePath);
        //stopwatch.Stop();
        //Console.WriteLine("File.ReadAllText: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}