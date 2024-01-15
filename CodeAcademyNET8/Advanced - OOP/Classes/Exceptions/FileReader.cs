using System.Security;

namespace CodeAcademyNET8.Advanced___OOP.Classes.Exceptions;

internal class FileReader
{
    public static string ReadFile(string pathToTheFile)
    {
        try
        {
            var content = File.ReadAllText(pathToTheFile);
            Console.WriteLine(content);
            return content;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
            return "";
        }
        catch (PathTooLongException e)
        {
            Console.WriteLine(e.Message);
            return "";
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
            return "";
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
            return "";
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
            return "";
        }
        //catch (FileNotFoundException e) // FileNotFoundException is derived from IOException, this one is redundant
        //{
        //    Console.WriteLine(e.Message);
        //}
        catch (NotSupportedException e)
        {
            Console.WriteLine(e.Message);
            return "";
        }
        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
            return "";
        }
    }
}