using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab_09_02
{
    static class Programm
    {
        static void Main()
        {
            // +-+-+-+-+-+-+-+-+-+-+-+-+ Task_01 +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
            Console.WriteLine(" +++++++++++++++++ Task_01 ++++++++++++++++\n");

            CollectionCar collectionCar = new CollectionCar();
            collectionCar.Add(new Car(1, "Mercedes-Benz", "w223", 2021, "Black", 100_000));
            collectionCar.Add(new Car(2, "Mercedes-Benz", "w140", 1990, "Black", 10_000));
            collectionCar.Add(new Car(3, "Mercedes-Benz", "E63", 2004, "White", 30_000));
            collectionCar.Add(new Car(4, "Mercedes-Benz", "g63", 2018, "Black", 200_000));
            collectionCar.Add(new Car(5, "Porsche", "Taycan", 2017, "Orange", 130_000));
            collectionCar.Add(new Car(6, "Mercedes-Benz", "S500", 2017, "Black", 170_000));

            collectionCar.Add(new Car(7, "BMW", "M8", 2022, "SpaceGray", 150_000));

            collectionCar.Remove(new Car(3, "Mercedes-Benz", "E63", 2004, "White", 30_000));

            foreach (var car in collectionCar)
                Console.WriteLine(car.ToString());

            Console.WriteLine($"this Car: {collectionCar[0]}");
            Console.WriteLine($"Contains Car: {collectionCar.Contains(new Car(7, "BMW", "M8", 2022, "SpaceGray", 150_000))}");
            Console.WriteLine($"IndexOf Car: {collectionCar.IndexOf(new Car(7, "BMW", "M8", 2022, "SpaceGray", 150_000))}");

            collectionCar.Clear();
            foreach (var car in collectionCar)
                Console.WriteLine(car.ToString());

            // +-+-+-+-+-+-+-+-+-+-+-+-+ Task_02 +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
            Console.WriteLine("\n +++++++++++++++++ Task_02 ++++++++++++++++\n");

            Dictionary<int,string> dictionary = new Dictionary<int, string>();

            dictionary.Add(5, "Number 5");
            dictionary.Add(1, "Number 1");
            dictionary.Add(3, "Number 3");
            dictionary.Add(2, "Number 2");
            dictionary.Add(4, "Number 4");

            Console.WriteLine("\n- - - Test dictionary - - - \n");
            foreach (var elem in dictionary)
            {
                Console.WriteLine(elem.Key.ToString());
                Console.WriteLine(elem.Value);
            }

            SortedList<int, string> sortedList = new SortedList<int, string>();
            sortedList.Add(5, "Number 5");
            sortedList.Add(1, "Number 1");
            sortedList.Add(3, "Number 3");
            sortedList.Add(2, "Number 2");
            sortedList.Add(4, "Number 4");

            Console.WriteLine("\n- - - Test sortedList - - - \n");
            foreach (var elem in sortedList)
            {
                Console.WriteLine(elem.Key.ToString());
                Console.WriteLine(elem.Value);
            }

            Console.WriteLine($"\nIndexOf Car: {sortedList.Values.IndexOf("Number 3")}");

            // +-+-+-+-+-+-+-+-+-+-+-+-+ Task_03 +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
            Console.WriteLine("\n +++++++++++++++++ Task_03 ++++++++++++++++\n");

            ObservableCollection<Car> carsObsetvable = new ObservableCollection<Car>();

            carsObsetvable.CollectionChanged += Car_CollectionChanged;

            carsObsetvable.Add(new Car(1, "Mercedes-Benz", "w223", 2021, "Black", 100_000));
            carsObsetvable.Add(new Car(2, "Mercedes-Benz", "w140", 1990, "Black", 10_000));
            carsObsetvable.Add(new Car(3, "Mercedes-Benz", "E63", 2004, "White", 30_000));
            carsObsetvable.Add(new Car(5, "Porsche", "Taycan", 2017, "Orange", 130_000));

            carsObsetvable.Remove(new Car(3, "Mercedes-Benz", "E63", 2004, "White", 30_000));

            foreach (var car in carsObsetvable)
                Console.WriteLine(car);

            void Car_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        if (e.NewItems?[0] is Car newCar)
                            Console.WriteLine($" - Add new Car: {newCar}");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        if (e.OldItems?[0] is Car oldCar)
                            Console.WriteLine($" - Remove old Car: {oldCar}");
                        break;
                }
            }
        }
    }
}