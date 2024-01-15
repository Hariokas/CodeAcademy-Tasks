namespace CodeAcademyNET8;

public static class Lecture2
{
    public static void RunTasks()
    {
        FirstTask2("Hello there :)", 5);
        ThirdTask2();
    }

    private static void FirstTask2(string input, int charIndex)
    {
        Console.WriteLine(
            $"Input: [{input}]; [{charIndex}] letter is: [{input[charIndex]}]; Total length: [{input.Length}]");
    }

    private static void ThirdTask2()
    {
        var badString = "  A_v-eRy_*LonG_*sTr*INg     thAt_*Sho*-u-LD_-*Be_S*pl-It   ";
        Console.WriteLine($"badString: [{badString}]");

        var stringWithoutSymbols = badString.Replace("-", string.Empty).Replace("*", string.Empty);
        Console.WriteLine($"stringWithoutSymbols: [{stringWithoutSymbols}]");

        var lowerString = stringWithoutSymbols.ToLower();
        Console.WriteLine($"lowerString: [{lowerString}]");

        var firstPartOfString =
            lowerString.Substring(0, lowerString.IndexOf("that", StringComparison.CurrentCultureIgnoreCase));
        Console.WriteLine($"firstPartOfString: [{firstPartOfString}]");

        var secondPartOfString =
            lowerString.Substring(lowerString.IndexOf("that", StringComparison.CurrentCultureIgnoreCase),
                lowerString.Length - lowerString.IndexOf("that", StringComparison.CurrentCultureIgnoreCase));
        Console.WriteLine($"secondPartOfString: [{secondPartOfString}]");

        var firstPartOfTrimmedString = firstPartOfString.Trim().Replace("_", " ");
        Console.WriteLine($"firstPartOfTrimmedString: [{firstPartOfTrimmedString}]");
        var secondPartOfTrimmedString = secondPartOfString.Trim().Replace("_", " ");
        Console.WriteLine($"secondPartOfTrimmedString: [{secondPartOfTrimmedString}]");

        var wholeString = $"{firstPartOfTrimmedString} {secondPartOfTrimmedString}";
        Console.WriteLine($"wholeString: [{wholeString}]");
    }
}