using System;

namespace Lab_07
{
    public class Program
    {
        static void Main()
        {
            try
            {
                List<string> linkedList_01 = new List<string>();
                linkedList_01.Add("Привет, ");

                List<string> linkedList_02 = new List<string>();
                linkedList_02.Add("Бил Гейтс");
                linkedList_02.Add("Илон Маск");
                --linkedList_02;

                // результат сложения списков
                linkedList_01 = linkedList_01 + linkedList_02;

                Console.WriteLine("- - - - - Результат сложения списков, будет список - - - - -");

                linkedList_01.WriteList();

                Console.WriteLine($"Результат сравнения списков ==: {linkedList_01 == linkedList_02}");
                Console.WriteLine($"Результат сравнения списков !=: {linkedList_01 != linkedList_02}");

                Console.WriteLine($"\nРезультат сложения списков с помощью статической функции: {StatisticOperation.SumElement<String>(linkedList_01)}");
                Console.WriteLine($"\nКоличество элементов в списке: {StatisticOperation.LengthElement(linkedList_01)}");

                linkedList_01.Add("Тим Кук выпустил новый айфон");
                Console.WriteLine($"\nЭлементов элементов(Максимального и минимального): {StatisticOperation.MinMax(linkedList_01)}");

                string strTest = "dfgj324sdfs3123ksdfkj57sdf";
                Console.WriteLine($"\nПоследнее число в строке: {strTest.FindLetterNumber()}");

                List<Vehicle> listVehicle = new List<Vehicle>();
                Car car_01 = new Car(000, 4);
                Train train_01 = new Train(12);
                RailCar railCar_01 = new RailCar(7);
                listVehicle.Add(car_01);
                listVehicle.Add(train_01);
                listVehicle.Add(railCar_01);
                listVehicle.WriteList();

                linkedList_02.Add("Бил Гейтс");
                linkedList_02.Add("Биг беби тейп");
                linkedList_02.Add("Смелов");
                StatisticOperation.WriteListFile(linkedList_02, "textWriteCollection.txt");

                List<String> testRead = new List<string>();
                Console.WriteLine("- - - - - Тест чтения - - - - -");
                StatisticOperation.ReadListFile<String>(ref testRead, linkedList_02, "textWriteCollection.txt");
                testRead.WriteList();

            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Произошла ошибка");
            }
            finally
            {
                Console.WriteLine("Данные очищены");
            }
        }
    }
}