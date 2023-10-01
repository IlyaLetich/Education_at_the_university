using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    interface IMove
    {
        void Move()
        {
            Console.WriteLine("Поехалииии");
        }
    }

    [Serializable]
    public abstract class Vehicle : IMove
    {


        public string TypeVehicle { get; set; }

        public Vehicle(string _typeVehicle)
        {
            TypeVehicle = _typeVehicle;
        }

        public abstract void Move();

    }

    [DataContract]
    [Serializable]
    public class Car : Vehicle, IMove
    {
        [DataMember]
        public int Color { get; set; }
        [DataMember]
        public int SizePerson { get; set; }

        public Car() : base("Автомобиль")
        {
            Color = -1;
            SizePerson = -1;
        }

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

    [Serializable]
    class Engine : IMove
    {
        int Volume;

        [NonSerialized]
        int Power;

        public Engine()
        {
            Volume = 0;
            Power = -1;
        }
        public Engine(int V)
        {
            Volume = V;
            Power = V * V;
        }
        public void getEngine()
        {
            Console.WriteLine("Двигатель получен");
        }

        void IMove.Move()
        {
            Console.WriteLine("Двигатель закрутился");
        }

        public override string ToString()
        {
            return "Volume = " + Volume + " ; Power = " + Power;
        }


        [OnDeserialized]
        void CalculatePower(StreamingContext context)
        {
            Power = Volume * Volume;
        }
    }

    [DataContract]
    class Train : Vehicle
    {
        [DataMember]
        public int SizeRailCar { get; set; }
        [DataMember]
        public int YearsTrain { get; set; }

        public Train():base("Поезд")
        {
            YearsTrain = 0;
            SizeRailCar = 0;
        }

        public Train(int _sizeRailCar, int _yearsTrain) : base("Поезд")
        {
            SizeRailCar = _sizeRailCar;
            YearsTrain = _yearsTrain;
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