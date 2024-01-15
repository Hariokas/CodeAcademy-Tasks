using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility
{
    internal class Teacher(string name, int age, string subject) : PersonAccessibility(name, age)
    {

        private string _subject = subject;

        public string Subject
        {
            get => _subject;
            private set => _subject = value;
        }

        public string GetSubject()
        {
            return Subject;
        }

    }
}
