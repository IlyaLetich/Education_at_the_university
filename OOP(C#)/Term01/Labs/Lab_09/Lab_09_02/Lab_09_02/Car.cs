using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09_02
{
    internal class Car
    {

        public int id;
        public string mark;
        public string model;
        public string color;
        public int price;
        public readonly string numberRegister;
        public int years;
        public static int countOfCars;

        static Car()
        {
            countOfCars = 0;
        }

        public Car(int id, string mark, string model, int years, string color, int price)
        {
            this.id = id;
            this.mark = mark;
            this.model = model;
            this.years = years;
            this.color = color;
            this.price = price;
            this.numberRegister = mark + "#" + model + "#" + id;
            Car.countOfCars++;
        }

        public Car()
        {
            id = 0;
            mark = "Undefined";
            model = "Undefined";
            years = 0;
            color = "Undefined";
            price = 0;
            numberRegister = "Undefined";
            Car.countOfCars++;
        }

        public static void InformationClass()
        {
            Console.WriteLine($" - - - - - Information of Class - - - - - - - ");
            Console.WriteLine($"Count car: {Car.countOfCars}");

        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            {
                Car car = (Car)obj;
                return (model == car.model) && (color == car.color) && (mark == car.mark);
            }
        }

        public override int GetHashCode()
        {
            return numberRegister.Length * 777 * GetHashCode();
        }

        public override string ToString()
        {
            return "Mark: " + mark + "Model: " + model + ", Color: " + color + ", Number: " + numberRegister;
        }

        public void WriteCar(string modelCar, Car[] CarColection)
        {
            for (int i = 0; i < CarColection.Length; i++)
            {
                if (CarColection[i].model == modelCar)
                {
                    Console.WriteLine($"{i + 1} car: {CarColection[i].ToString()}");
                }
            }
        }

        public void WriteCar(int temp, string model, Car[] CarColection)
        {
            for (int i = 0; i < CarColection.Length; i++)
            {
                if (CarColection[i].model == model)
                {
                    if (CarColection[i].GetAge() > temp)
                    {
                        Console.WriteLine($"{i + 1} car: {CarColection[i].ToString()}");
                        Console.WriteLine($"Term of operation: {CarColection[i].GetAge()}");
                    }
                }
            }
        }

        public int GetAge()
        {
            return 2022 - this.years;
        }
    }
}
