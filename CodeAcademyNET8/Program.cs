using System.Text;
using CodeAcademyNET8.Projects.ATM_Project;

namespace CodeAcademyNET8;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        #region Beginner level

        //Lecture1.RunTasks();
        //Lecture2.RunTasks();
        //Lecture3.RunTasks();
        //Lecture4.RunTasks();
        //Lecture5.RunTasks();
        //Lecture6.RunTasks();
        //Lecture7.RunTasks();
        //Lecture8.RunTasks();
        //Lecture9.RunTasks();
        //Lecture10.RunTasks();
        //Lecture11.RunTasks();
        //Lecture12.RunTasks();
        //ForeachAndMultidimensionalArrays.RunTasks();
        //TicTacToe.InitializeGame();
        //RandomClassAndTwoDArrays.RunTasks();
        //Dictionaries.RunTasks();
        //Project.InitializeGame();

        #endregion

        #region Advanced - OOP

        //OOP1.RunTasks();
        //ClassMethods.RunTasks();
        //InheritanceAndVirtual.RunTasks();
        //Accessibility.RunTasks();
        //Streams.RunTasks();
        //Generics.RunTasks();
        //Generics2.RunTasks();
        //Generics3.RunTasks();
        //Exceptions.RunTasks();
        //ExtensionMethods.RunTasks();
        //Delegates.Run();
        //LinqAndLambda.Run();
        //InterfacesAndIComparer.Run();
        //Interfaces2.Run();

        // PROJECT!
        var atm = new ATMMain();
        atm.Run();

        #endregion
    }
}