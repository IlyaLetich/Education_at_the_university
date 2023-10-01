using System;

namespace Lab_10
{
    static class Program
    {
        static void Main()
        {

            // +-+-+-+-+-+-+-+-+-+-+-+-+ Task_01 +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
            Console.WriteLine(" +++++++++++++++++ Task_01 ++++++++++++++++\n");

            string[] Months = { "January", "February", "March", "April", "May",
                                "June", "July", "August", "September", "October",
                                "November", "December" };

            Console.WriteLine("- - - Test Month.Length == n - - - \n");

            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            var monthsLengthN = Months.Where(month => month.Length == n);

            foreach (var month in monthsLengthN)
                Console.WriteLine(month);

            Console.WriteLine("\n- - - Test Winter and SummerMonth - - - \n");

            var monthsWinterAndSummer = Months.Take(2).Concat(Months.Skip(5).Take(3)).Concat(Months.Skip(11));

            foreach (var month in monthsWinterAndSummer)
                Console.WriteLine(month);

            Console.WriteLine("\n- - - Test Ordery  - - - \n");

            var monthsOrdary = from s in Months
                               orderby s
                               select s;

            foreach (var month in monthsOrdary)
                Console.WriteLine(month);

            Console.WriteLine(" - - - Test months.Length >=4 && months.Contains(u)  - - - \n");

            var monthsLength4AndContainsU = Months.Where(month => month.Length >= 4).Where(month => month.Contains('u'));

            foreach (var month in monthsLength4AndContainsU)
                Console.WriteLine(month);

            // +-+-+-+-+-+-+-+-+-+-+-+-+ Task_02-05 +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
            Console.WriteLine("\n +++++++++++++++++ Task_02 ++++++++++++++++\n");

            List<Car> cars = new List<Car>();

            cars.Add(new Car("001", "Mercedes-Benz", "w223", 2021, "Black", 100_000));
            cars.Add(new Car("002", "Mercedes-Benz", "w140", 1990, "Black", 10_000));
            cars.Add(new Car("003", "Mercedes-Benz", "E63", 2004, "White", 30_000));
            cars.Add(new Car("004", "Mercedes-Benz", "g63", 2018, "Black", 200_000));
            cars.Add(new Car("005", "Porsche", "Taycan", 2017, "Orange", 130_000));
            cars.Add(new Car("006", "Mercedes-Benz", "S500", 2017, "Black", 170_000));
            cars.Add(new Car("007", "BMW", "M8", 2022, "SpaceGray", 150_000));


            Console.WriteLine("Enter mark: ");
            string mark = Console.ReadLine();
            Console.WriteLine("Enter years: ");
            int years = int.Parse(Console.ReadLine());

            IEnumerable<Car> carMark = cars.Where(car => car.mark == mark);
            IEnumerable<Car> carMarkAndYears = cars.Where(car => car.mark == mark && car.GetAge() > years);

            Console.WriteLine(" - - - Test cars of mark  - - - \n");

            foreach (var car in carMark)
                Console.WriteLine(car);

            Console.WriteLine(" - - - Test cars of mark and years  - - - \n");
            foreach (var car in carMarkAndYears)
                Console.WriteLine(car);

            Console.WriteLine("Enter color: ");
            string color = Console.ReadLine();
            Console.WriteLine("Enter range price: ");

            string[] stringRangePrice = Console.ReadLine().Split();
            int price_01 = int.Parse(stringRangePrice[0]);
            int price_02 = int.Parse(stringRangePrice[2]);

            var carColorAndPrice = cars.Where(car => car.color == color && car.price >= price_01 && car.price <= price_02);
            Console.WriteLine("\n - - - Test cars of color and price  - - - \n");
            Console.WriteLine($"Count = {carColorAndPrice.Count()}");
            foreach (var car in carColorAndPrice)
                Console.WriteLine(car);

            var carMaxYears = cars.OrderBy(car => car.price).Take(1);

            var carMinYears = cars.OrderBy(car => car.price).Skip(cars.Count() - 5);

            var carPrice = cars.OrderByDescending(car => car.price).ToArray();

            Console.WriteLine("\n - - - Test car max years  - - - \n");
            Console.WriteLine($"\nMax years: {carMaxYears.Max()}\n");

            Console.WriteLine("\n - - - Test top 5 min years - - - \n");
            foreach (var car in carMinYears)
                Console.WriteLine(car);

            Console.WriteLine("\n - - - Test array car price - - - \n");
            for (int i = 0; i < carPrice.Length; i++)
                Console.WriteLine(carPrice[i]);

            var carOprator5 = cars.Where(car => car.GetAge() < 10).Skip(0).Take(7).OrderBy(car => car.price).GroupBy(car => car.mark);

            Console.WriteLine("\n - - - Test cars 5 operator - - - \n");
            foreach (var item in carOprator5)
            {
                Console.WriteLine(item.Key);
                foreach (var element in item)
                    Console.WriteLine(element);
            }

            Console.WriteLine("\n - - - Test car top price - - - \n");

            int[] TopPrice = { 1, 2, 3 };
            var carTop = carPrice
                .Take(3)
                .Join(
                 TopPrice,
                 w =>
                 {
                     int i = 0;
                     foreach (var car in carPrice)
                     {
                         if (w == car) return i + 1;
                         i++;
                     }
                     return 0;
                 }
                 ,
                 q => q,
                 (w, q) => new { Place = q, Name = w }
                ); ;

            foreach (var car in carTop)
                Console.WriteLine(car);
        }
    }
}