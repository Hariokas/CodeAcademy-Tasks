using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility
{
    internal class PersonAccessibility(string name, int age)
    {
        private string _name = name;
        private int _age = age;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public int Age
        {
            get => _age;
            private set => _age = value;
        }

        protected internal void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}; Age: {Age}");
        }
    }
}
