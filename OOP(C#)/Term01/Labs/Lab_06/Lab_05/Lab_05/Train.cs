using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    class Train : Vehicle
    {
        public int SizeRailCar { get; set; }

        public Train(int _sizeRailCar) : base("Поезд")
        {
            SizeRailCar = _sizeRailCar;
        }

        public override void Move()
        {
            Console.WriteLine("Поезд поехал");
        }

        public override string ToString()
        {
            string TrainToString = "Тип транспорта: " + TypeVehicle + " # Количество вагонов: " + SizeRailCar;

            return TrainToString;
        }
    }
}
