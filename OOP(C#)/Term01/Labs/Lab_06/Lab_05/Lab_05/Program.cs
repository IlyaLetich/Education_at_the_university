using Lab_06;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

namespace Lab_05
{
    class Program
    {
        static void Main()
        {
            try
            {
                // - - - - - - - - - - - - - - - - - - - - - - - - - - лаба 4 - - - - - - - - - - - - - - - - - - - - - - - - - -
                /*
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
                Vehicle[] vehiclesCollection = { car_01, train_01, railCar_01, express_01 };

                printer_01.IAmPrinting(vehiclesCollection);

                Console.WriteLine("\n\n- - - - - - Тест преобразований - - - - - -");

                Engine engine_01 = new Engine(8);
                Console.WriteLine($"{railCar_01 is Train}");
                Train train_02 = railCar_01 as Train;
                if (train_02 != null) Console.WriteLine("Преобразование успешно");
                train_02.Move();

                Console.WriteLine("\n\n- - - - - - Тест интерфейсов - - - - - -");

                IMove imove_01 = train_01;
                imove_01.Move();
                ((IMove)engine_01).Move();
                ((IMove)car_01).Move();
                */

                // - - - - - - - - - - - - - - - - - - - - - - - - - - лаба 5 - - - - - - - - - - - - - - - - - - - - - - - - - -

                int yTryTest = 0;
                Logger logger = new Logger();
                logger.FileLoggerWriteLine("Log-файл успесно создан");
                try
                {

                    Component component_01 = new Component(0.12, 0.5, 100, "Boock");
                    Component component_02 = new Component(0.10, 0.4, 1_000_000, "MacBook");
                    Component component_03 = new Component(0.05, 0.2, 500_000, "iPhone");

                    ContainerGift componentGift_01 = new ContainerGift();

                    componentGift_01.Add(component_01);
                    componentGift_01.Add(component_02);
                    componentGift_01.Add(component_03);
                    Console.WriteLine("\n\n- - - - - - Список подарков до удаления - - - - - -");
                    componentGift_01.WriteGift();

                    componentGift_01.Remove(component_01);
                    Console.WriteLine("\n\n- - - - - Список подарков после удаления - - - - -");
                    componentGift_01.WriteGift();
                    Console.WriteLine();

                    Console.WriteLine("\n\n- - - - - - - - Минимальный элемент - - - - - - - -");
                    СontrollerGift.FindMinimalMassa(componentGift_01.AllComponent);

                    Console.WriteLine("\n\n- - - - - - - - - - Сумма подарка - - - - - - - - -");
                    СontrollerGift.calculatePrice(componentGift_01.AllComponent);

                    Console.WriteLine("\n\n- - - - - - - - Тест сортировки - - - - - - - - - -");
                    Component component_04 = new Component(1000, 10, 10_000_000, "MercedesBenz");
                    Component component_05 = new Component(5, 1, 5_000, "Saxar");
                    componentGift_01.Add(component_04);
                    componentGift_01.Add(component_05);

                    Array.Sort(componentGift_01.AllComponent, new ContainerGift.SumComponent { });

                    foreach (Component component in componentGift_01.AllComponent)
                    {
                        Console.WriteLine(component);
                    }

                    Console.WriteLine("\n\n- - - - - - - - Тест чтения файла - - - - - - - -");
                    ContainerGift containerGift_02 = new ContainerGift();
                    СontrollerGift.ReadFile(containerGift_02, @"C:\Users\Илья\Desktop\Пацей\ООП\Labs\Lab_05\Text.txt");
                    containerGift_02.WriteGift();

                    Console.WriteLine("\n\n- - - - - - Тест чтения файла(json) - - - - - - -");
                    ContainerGift containerGift_03 = new ContainerGift();
                    СontrollerGift.ReadFileJson(containerGift_03, @"C:\Users\Илья\Desktop\Пацей\ООП\Labs\Lab_05\JSON.json");
                    containerGift_03.WriteGift();
                    Console.WriteLine();

                    ContainerGift componentGiftTry = new ContainerGift();

                    Console.WriteLine("\n\n- - - - - - Тест исключений - - - - - - - - - - -");

                    //componentGiftTry.WriteGift();
                    //componentGiftTry.AllComponent[12].ToString();
                    //componentGiftTry.Remove(component_01);
                    /*
                    for(int i = 0; i < 12; i++)
                    {
                        componentGiftTry.Add(component_05);
                    }
                    */

                    int xTryTest = 0;
                    Debug.Assert((xTryTest != 0),"Шо за дела? Мы так не договаривались");
                    Debugger.Launch();
                }

                catch(TestNullClass exception)
                {
                    
                    Console.WriteLine("Не дели пажалуйста на 0!!!");
                }
                catch(NullReferenceException exception) when (yTryTest == 0)
                {
                    logger.FileLoggerWriteError("Error NullReferenceException", exception.Message, exception.StackTrace);
                    logger.ConsoleLoggerError("Error NullReferenceException", exception.Message, exception.StackTrace);
                }
                catch (NullReferenceException exception)
                {
                    Console.WriteLine($"ПРОИЗОШЛА ОШИБКА: {exception.Message}");
                }
                catch (MaxCollection exception)
                {
                    Console.WriteLine($"ПРОИЗОШЛА ОШИБКА: {exception.Message}");
                }
                catch (DeleteNullObject exception)
                {
                    Console.WriteLine($"ПРОИЗОШЛА ОШИБКА: {exception.Message}");
                }
                catch
                {
                    Console.WriteLine("Нет обработчика события передаю дальше!");
                    throw;

                }
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Вы пытались обратитьс к элементу \nкоторого не существует, и как такое понимать?");
            }
            catch
            {
                Console.WriteLine("К сожалению и тут не нашлось :(");
            }
            finally
            {
                Console.WriteLine("!-!-! Проверка исключений завершена !-!-!");
            }
        }
    }
}