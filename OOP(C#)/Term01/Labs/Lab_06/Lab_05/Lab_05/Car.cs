using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    class Car : Vehicle, IMove
    {
        public int Color { get; set; }
        public int SizePerson { get; set; }

        public Car(int _color, int _sizePerson) : base("Автомобиль")
        {
            Color = _color;
            SizePerson = _sizePerson;
        }

        void IMove.Move()
        {
            Console.WriteLine("Поехалиииииии");
        }

        public override void Move()
        {
            Console.WriteLine("Автомобиль поехал");
        }

        public override string ToString()
        {
            string CarToString = "Тип транспорта: " + TypeVehicle + " # Цвет автомобиля: " + Color + " # Количество мест: " + SizePerson;

            return CarToString;
        }
    }
}
