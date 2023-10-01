using System;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;

namespace Lab_02
{
    public partial class Car
    {
        // поля
        private string idCar;
        private string modelCar;
        private string colorCar;
        private int priceCar;
        private static int countOfCars;
        public  readonly string numberRegisterCar;
        private const int maxCar = 10;
        private int yearsHappyCar;
        private int mileage = 0;
        public double statusCar;
    }
    class Program
    {
        static void Main()
        {
            Car[] CarColection = new Car[3];

            CarColection[0] = new Car();
            CarColection[0].CreateBetMobil(ref CarColection[0]);
            CarColection[1] = new Car("001MS", "Mercedes-Benz", 2017, "Black", 150_000);
            CarColection[2] = new Car("001ME", "Mercedes-Benz", 2018, "Black", 70_000);

            CarColection[2].DriveDistance100();
            CarColection[2].SubDriveDistance100();

            Console.WriteLine($"\n1 тачка -  {CarColection[0].ToString()}");
            Console.WriteLine($"2 тачка -  {CarColection[1].ToString()}");
            Console.WriteLine($"3 тачка -  {CarColection[2].ToString()}\n");
            Console.WriteLine($"Сравним 2 мылшку с 3 малышкой -  {CarColection[1].Equals(CarColection[2])}");
            Console.WriteLine($"Сравним 1 мылшку с 2 малышкой -  {CarColection[0].Equals(CarColection[1])}\n");

            CarColection[0].StatusCar = 0.2;
            CarColection[1].StatusCar = 7;

            Car.InformationClass();
            Console.WriteLine();
            
            Console.Write("Введите марку автомобиля: ");
            string parmModel = Console.ReadLine();
            CarColection[1].WriteCar(parmModel, CarColection);

            Console.Write("\nВведите марку автомобиля: ");
            string parmModel2 = Console.ReadLine();
            Console.Write("Введите срок эксплуатации: ");
            int iNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n- - - - Мы подискали такие варианты - - - -\n");
            CarColection[1].WriteCar(iNum,parmModel2, CarColection);

            Console.WriteLine("- - - - - - ANONIMUS - - - - - - ");
            var CarType = new { idCar = 12, modelCar = "Mercedes-Benz", colorCar = "Black" };
            Console.WriteLine($"Тест анонимного типа - {CarType.GetType()}");
            Console.WriteLine($"ID Car: {CarType.idCar} # Model Car: {CarType.modelCar} # Color: {CarType.colorCar}");
        }
    }
    

}