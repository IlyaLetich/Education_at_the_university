using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    public partial class Car
    {
        // свойства
        public int Mileage
        {
            get { return mileage; }
            private set
            {
                if (value < mileage)
                {
                    Console.WriteLine("Вы спалились, за Вами выехали!!!\n");
                }
                else mileage = value;
            }
        }

        public double StatusCar
        {
            set
            {
                if (value > 1 || value < 0)
                {
                    statusCar = value;
                }
                else
                {
                    Console.WriteLine("Состояние автомобля введено не верно!\n");
                }
            }
            get { return statusCar; }
        }
    }
}