using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    public partial class Car
    {
        // конструкторы
        static Car()
        {
            countOfCars = 0;
        }

        public Car(string idCar, string modelCar, int yearsHappyCar, string colocCar, int priceCar)
        {
            this.idCar = idCar;
            this.modelCar = modelCar;
            this.yearsHappyCar = yearsHappyCar;
            this.colorCar = colocCar;
            this.priceCar = priceCar;
            this.numberRegisterCar = modelCar + "#" + idCar;
            Car.countOfCars++;
        }

        public Car()
        {
            idCar = "Undefined";
            modelCar = "Undefined";
            yearsHappyCar = 0;
            colorCar = "Undefined";
            priceCar = 0;
            numberRegisterCar = "Undefined";
            Car.countOfCars++;
        }

        private Car(string secretKey)
        {
            this.idCar = "777";
            this.modelCar = "BetMobil";
            this.yearsHappyCar = 0;
            this.colorCar = "Black";
            this.priceCar = 777_777_777;
            this.numberRegisterCar = numberRegisterCar = modelCar + "#" + idCar + "#" + secretKey;
        }
    }
}
