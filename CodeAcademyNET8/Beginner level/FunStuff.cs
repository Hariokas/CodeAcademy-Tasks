using System.Diagnostics;
using System.Text;

namespace CodeAcademyNET8;

internal static class FunStuff
{
    public static void CompareStringBuildingTimes()
    {
        var sw = new Stopwatch();
        var iterations = 300000;

        var text = new string[iterations];
        var output = string.Empty;

        sw.Start();
        for (var i = 0; i < iterations; i++) text[i] = "A";
        output = string.Join(string.Empty, text);
        sw.Stop();

        Console.WriteLine($"Array\t\tof length {output.Length}\ttook {sw.Elapsed}");

        output = string.Empty;

        sw.Reset();
        var sb = new StringBuilder();

        sw.Start();
        for (var i = 0; i < iterations; i++) sb.Append("A");
        output = sb.ToString();
        sw.Stop();

        Console.WriteLine($"Stringbuilder\tof length {output.Length}\ttook {sw.Elapsed}");

        output = string.Empty;
        sw.Reset();

        sw.Start();
        for (var i = 0; i < iterations; i++) output += "A";
        sw.Stop();

        Console.WriteLine($"String append\tof length {output.Length}\ttook {sw.Elapsed}");
        Console.ReadLine();
    }
}