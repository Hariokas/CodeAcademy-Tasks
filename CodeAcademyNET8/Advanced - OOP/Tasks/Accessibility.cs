using CodeAcademyNET8.Advanced___OOP.Classes.Accessibility;
using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal static class Accessibility
{
    public static void RunTasks()
    {

    }

    private static void Task1()
    {
        var student = new Student("Pesho", 20, "123456");
        var teacher = new Teacher("Gosho", 30, "Math");

        student.PrintInfo();
        Console.WriteLine($"Student's ID: {student.GetStudentId()}");

        teacher.PrintInfo();
        Console.WriteLine($"Teacher's subject: {teacher.GetSubject()}");

        Separator();

    }

}