using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility
{
    internal class Circle(double radius) : Shape
    {
        private double _radius = radius;

        public double Radius
        {
            get => _radius;
            private set => _radius = value;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
