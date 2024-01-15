using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual.Vehicle_Rental
{
    internal class RentalSystem
    {
        public VehicleR ReserveVehicle(string model)
        {
            return new CarR(model);
        }
    }
}
