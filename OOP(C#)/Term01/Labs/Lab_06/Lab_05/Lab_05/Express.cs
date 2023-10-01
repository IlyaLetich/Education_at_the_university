using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    class Express : Vehicle
    {

        public int SizePlace { get; set; }

        public Express(int _sizePlace) : base("Экспресс")
        {
            SizePlace = _sizePlace;
        }

        public override void Move()
        {
            Console.WriteLine("Экспресс поехал");
        }

        public override string ToString()
        {
            string ExpressToString = "Тип транспорта: " + TypeVehicle + " # Количество мест: " + SizePlace;

            return ExpressToString;
        }
    }
}
