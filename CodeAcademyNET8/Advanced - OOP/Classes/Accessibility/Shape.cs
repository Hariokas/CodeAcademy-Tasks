using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility
{
    internal class Shape
    {
        public virtual double CalculateArea()
        {
            throw new NotImplementedException("This method must be implemented in the derived class.");
        }
    }
}
