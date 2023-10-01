using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09_02
{
    internal class CollectionCar : IList<Car>
    {

        Dictionary<int, Car> cars = new Dictionary<int, Car>();

        public int Count { get => cars.Count; }
        public bool IsReadOnly => false;

        public void Add(Car car)
        {
            cars.Add(car.id, car);
        }

        public void Clear()
        {
            cars.Clear();
        }

        public bool Remove(Car car)
        {
            cars.Remove(car.id);
            return !cars.ContainsKey(car.id);
        }

        public Car this[int i]
        {
            get
            {
                int counter = 0;
                foreach(var car in cars)
                {
                    if (counter == i) return car.Value;
                    counter++;
                }
                return null;
            }
            set
            {
                Car[] carsArray = new Car[cars.Count];
                int counter = 0;
                foreach (var car in cars)
                {
                    carsArray[counter] = car.Value;
                    counter++;
                }
                carsArray[i] = value;
                cars.Clear();
                for (int countFor = 0; countFor < carsArray.Length; countFor++)
                    cars.Add(carsArray[countFor].id, carsArray[countFor]);
            }
        }

        public void RemoveAt(int i)
        {
            cars.Remove(cars[i].id);
        }

        public void CopyTo(Car[] car, int counter)
        {
            int i = 0;
            car = new Car[counter];
            foreach(KeyValuePair<int,Car> elemCar in cars)
            {
                if (i == counter) return;
                car[i] = elemCar.Value;
                i++;
            }
        }

        public bool Contains(Car car)
        {
            return cars.TryGetValue(car.id, out Car carUser);
        }

        public int IndexOf(Car car)
        {
            Car[] carsArray = new Car[cars.Count];
            int counter = 0;
            foreach (var carCol in cars)
            {
                carsArray[counter] = carCol.Value;
                counter++;
            }

            for (int i = 0; i < carsArray.Length; i++)
                if (carsArray[i].id == car.id) return i;
            return -1;

        }

        public void Insert(int n, Car car)
        {
            Car[] carsArray = new Car[cars.Count];
            int counter = 0;
            foreach (var carCol in cars)
            {
                carsArray[counter] = carCol.Value;
                counter++;
            }

            carsArray[n] = car;

            cars.Clear();
            for (int countFor = 0; countFor < carsArray.Length; countFor++)
                cars.Add(carsArray[countFor].id, carsArray[countFor]);
        }

        public IEnumerator<Car> GetEnumerator()
        {
            int counter = 0;
            Car[] carsArray = new Car[cars.Count];
            foreach (var carCol in cars)
            {
                carsArray[counter] = carCol.Value;
                counter++;
            }
            for (var i = 0; i < carsArray.Length; i++)
                yield return carsArray[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
