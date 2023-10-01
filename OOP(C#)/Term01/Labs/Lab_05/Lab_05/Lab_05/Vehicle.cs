using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    abstract class Vehicle : IMove
    {


        public string TypeVehicle { get; set; }

        public Vehicle(string _typeVehicle)
        {
            TypeVehicle = _typeVehicle;
        }

        public abstract void Move();

    }
}
