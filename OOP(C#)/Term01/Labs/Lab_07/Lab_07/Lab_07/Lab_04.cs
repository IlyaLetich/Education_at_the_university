using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
{
    class Printer
    {
        public void IAmPrinting(Vehicle[] collection)
        {
            foreach (Vehicle obj in collection)
            {
                iIAmPrinting(obj);
            }
        }
        public void iIAmPrinting(Vehicle obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }
    }

    interface IMove
    {
        void Move()
        {
            Console.WriteLine("Поехалииии");
        }
    }

    abstract class Vehicle : IMove
    {


        public string TypeVehicle { get; set; }

        public Vehicle(string _typeVehicle)
        {
            TypeVehicle = _typeVehicle;
        }

        public abstract void Move();

    }

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

    class Engine : IMove
    {
        int Volume;
        public Engine(int V)
        {
            Volume = V;
        }
        public void getEngine()
        {
            Console.WriteLine("Двигатель получен");
        }

        void IMove.Move()
        {
            Console.WriteLine("Двигатель закрутился");
        }
    }

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
