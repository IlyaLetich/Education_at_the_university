using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    public partial class Car
    {
        // методы
        public Car CreateBetMobil(ref Car car)
        {
            car = new Car("1111");
            Console.WriteLine("Секретный конструктор, тсссс!!!");
            Console.WriteLine("Бетмобиль успешно создан!");
            Console.WriteLine("В бой мой дорогой бетмен, бандиты не спят!!!\n");
            return car;
        }

        public static void InformationClass()
        {
            Console.WriteLine($" - - - - - - - Информация о классе - - - - - - - ");
            Console.WriteLine($"Количество созданных автомобилей: {Car.countOfCars}");

        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            {
                Car CarTest = (Car)obj;
                return (modelCar == CarTest.modelCar) && (colorCar == CarTest.colorCar);
            }
        }

        public override int GetHashCode()
        {
            return numberRegisterCar.Length * 777 * GetHashCode();
        }

        public override string ToString()
        {
            return "Model: " + modelCar + ", Color: " + colorCar + ", Number: " + numberRegisterCar + "#" + mileage;
        }

        public void DriveDistance100()
        {
            Console.WriteLine("Завожу машину...");
            Console.WriteLine("Завёл!");
            Console.WriteLine($"Текущий пробег до езды: {mileage}");
            mileage += 100;
            Console.WriteLine($"Текущий пробег после езды: {mileage}");
        }
        public void SubDriveDistance100()
        {
            Console.WriteLine("\nХехе, сейчас отматем пробег, лайфаки перекупа!!!");
            Mileage -= 100;
            Console.WriteLine($"Текущий пробег после отмотки: {Mileage}\n");
        }

        public void WriteCar(string modelCar, Car[] CarColection)
        {
            for (int i = 0; i < CarColection.Length; i++)
            {
                if (CarColection[i].modelCar == modelCar)
                {
                    Console.WriteLine($"{i+1} автомоюиль: {CarColection[i].numberRegisterCar}");
                }
            }
        }

        public void WriteCar(int srok,string modelCar, Car[] CarColection)
        {
            for (int i = 0; i < CarColection.Length; i++)
            {
                if (CarColection[i].modelCar == modelCar)
                {
                    if (CarColection[i].GetAge() > srok)
                    {
                        Console.WriteLine($"{i + 1} автомоюиль: {CarColection[i].numberRegisterCar}");
                        Console.WriteLine($"Срок эксплуатации: {CarColection[i].GetAge()}");
                    }
                }
            }
        }

        public int GetAge()
        {
            return 2022 - this.yearsHappyCar;
        }
    }
}