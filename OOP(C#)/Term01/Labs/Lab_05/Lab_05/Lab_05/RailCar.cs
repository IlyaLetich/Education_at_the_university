using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    sealed class RailCar : Train
    {
        public int NumberRailCar { get; set; }

        public RailCar(int _numberRailCar) : base(1)
        {
            TypeVehicle = "Вагон";
            NumberRailCar = _numberRailCar;
        }

        public override void Move()
        {
            Console.WriteLine("Вагон не моет ехать сам, у него нема двигателя");
        }
        public override string ToString()
        {
            string RailCarToString = "Тип транспорта: " + TypeVehicle + " # Количество вагонов: " + SizeRailCar + " # Номер вагона: " + NumberRailCar;

            return RailCarToString;
        }
        
    }
}
