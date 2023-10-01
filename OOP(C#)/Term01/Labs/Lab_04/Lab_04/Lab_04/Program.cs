using System;
using System.Drawing;

namespace Lab_04
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

    class Program
    {
        static void Main()
        {
            Car car_01 = new Car(000, 4);
            Train train_01 = new Train(12);
            Console.WriteLine("\n\n- - - - - - - тест полиморфизма - - - - - - -");
            Console.WriteLine("train_01 до присвоения ссылки на базовый класс:");
            train_01.Move();
            RailCar railCar_01 = new RailCar(7);
            train_01 = railCar_01;
            Console.WriteLine("train_01 после присвоения ссылки на базовый класс:");
            train_01.Move();

            Console.WriteLine("\n\n- - - - - - Тест принтера - - - - - -");
            Printer printer_01 = new Printer();
            Express express_01 = new Express(16);
            Vehicle[] vehiclesCollection = { car_01, train_01, railCar_01, express_01};

            printer_01.IAmPrinting(vehiclesCollection);

            Console.WriteLine("\n\n- - - - - - Тест преобразований - - - - - -");

            Engine engine_01 = new Engine(8);

            Console.WriteLine($"{railCar_01 is Train}");

            Console.WriteLine("\n\n- - - - - - Тест интерфейсов - - - - - -");

            IMove imove_01 = train_01;
            imove_01.Move();
            ((IMove)engine_01).Move();
        }
    }
}