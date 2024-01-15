using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility
{
    internal class Student(string name, int age, string studentId) : PersonAccessibility(name, age)
    {

        private string _studentId = studentId;

        protected string StudentId
        {
            get => _studentId;
            private set => _studentId = value;
        }

        public string GetStudentId()
        {
            return _studentId;
        }

    }
}
