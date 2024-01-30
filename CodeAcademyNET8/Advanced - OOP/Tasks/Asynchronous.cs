using static CodeAcademyNET8.Helpers;
using CodeAcademyNET8.Advanced___OOP.Classes.Asynchronous;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal class Asynchronous
{
    public static void Run()
    {
        Task1();
        Task2();
    }

    private static void Task1()
    {
        var asyncAwait = new AsyncAwait();
        asyncAwait.StartProgress().Wait();
        Separator();
    }

    private static void Task2()
    {
        PrintFiles(5).Wait();
        Separator();
    }

    private static async Task PrintFiles(int repeatCount)
    {
        if (repeatCount < 0)
            throw new ArgumentException("Repeat count cannot be negative", nameof(repeatCount));

        while (repeatCount > 0)
        {
            var files = GetDesktopFiles().Result;

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine();
            repeatCount--;
            await Task.Delay(5000);
        }
    }

    private static async Task<string[]> GetDesktopFiles()
    {
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var files = await Task.Run(() => Directory.GetFiles(desktopPath));
        var fileNames = files.Select(file => Path.GetFileName(file)).ToArray();
        return fileNames;
    }

}