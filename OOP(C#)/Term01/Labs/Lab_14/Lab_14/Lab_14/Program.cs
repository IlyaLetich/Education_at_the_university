using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Lab_14
{
    class Program
    {
        static void Main()
        {
            try
            {
                // 1
                // Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет
                // время запуска, текущее состояние, сколько всего времени использовал процессор и т.д

                foreach (var process in Process.GetProcesses())
                {
                    try
                    {
                        Console.WriteLine(
                            $"ID: {process.Id}\n" +
                            $"Имя процесса: {process.ProcessName}\n" +
                            $"Приоритет: {process.BasePriority}\n" +
                            $"Виртуальная память: {process.VirtualMemorySize64}\n" +
                            $"Время запуска: {process.StartTime}\n" +
                            $"Cколько всего времени использовал процессор: {process.TotalProcessorTime}\n");
                    }
                    catch
                    {
                    }
                }

                // 2
                // Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
                // загруженные в домен.Создайте новый домен.Загрузите туда сборку.Выгрузите домен

                AppDomain appDomain = AppDomain.CurrentDomain;
                Console.WriteLine($"Имя домена: {appDomain.FriendlyName}");
                Console.WriteLine($"Детали конфигурации: {appDomain.SetupInformation}");
                Console.WriteLine("Сборки загруженные в домен:");
                foreach (var assembly in appDomain.GetAssemblies()) Console.WriteLine(assembly.FullName);

                try
                {
                    AppDomain newD = AppDomain.CreateDomain("Новый домен");
                    newD.Load(@"C:\Users\Илья\Desktop\Пацей\ООП\Labs\Lab_13\Lab_13\Lab_13\bin\Debug\net6.0\Lab_13.dll");
                    AppDomain.Unload(newD);
                }
                catch
                {
                };
                Console.WriteLine();

                // 3
                // Создайте в отдельном потоке следующую задачу расчета(можно сделать sleep для
                // задержки) и записи в файл и на консоль простых чисел от 1 до n(задает пользователь).
                // Вызовите методы управления потоком(запуск, приостановка, возобновление и т.д.) Во
                // время выполнения выведите информацию о статусе потока, имени, приоритете, числовой
                // идентификатор и т.д.

                Thread thread = new Thread(ShowSimpleNumbers);

                Console.WriteLine($"Имя потока: {thread.Name}");
                Console.WriteLine($"Id: {thread.ManagedThreadId}");
                Console.WriteLine($"Приоритет: {thread.Priority}");
                Console.WriteLine($"Статус: {thread.ThreadState}");

                thread.Start(int.Parse(Console.ReadLine()));

                void ShowSimpleNumbers(object obj)
                {
                    int numberUser = (int)obj;

                    Thread th = Thread.CurrentThread;

                    Console.WriteLine($"Имя потока: {th.Name}");
                    Console.WriteLine($"Id: {th.ManagedThreadId}");
                    Console.WriteLine($"Приоритет: {th.Priority}");
                    Console.WriteLine($"Статус: {th.ThreadState}");

                    using (StreamWriter sw = new StreamWriter("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_14\\Lab_14\\Lab_14\\SimpleNumbers.txt", false))
                    {
                        for (var i = 1; i <= numberUser; i++)
                        {
                            var isSimple = true;
                            for (var j = 2; j <= i / 2; j++)
                                if (i % j == 0)
                                {
                                    isSimple = false;
                                    break;
                                }

                            if (isSimple)
                            {
                                Console.Write($"{i} ; ");
                                sw.Write($"{i} ; ");
                                Thread.Sleep(100);
                            }
                        }
                    }
                }
                Thread.Sleep(5000);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


                // 4
                // Создайте два потока. Первый выводит четные числа, второй нечетные до n и
                // записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.
                // a. Поменяйте приоритет одного из потоков. 
                // b. Используя средства синхронизации организуйте работу потоков, таким образом, чтобы
                //      i. выводились сначала четные, потом нечетные числа
                //      ii.последовательно выводились одно четное, другое нечетное.


                Thread th1 = new Thread(WriteOddNumbers)
                {
                    //Priority = ThreadPriority.Highest
                };
                Thread th2 = new Thread(WriteEvenNumbers);

                th1.Start(100);
                th2.Start(100);

                
                void WriteEvenNumbers(object obj)
                {
                    try
                    {
                        int numberUser = (int)obj;

                        for (int i = 0; i < numberUser; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write($"{i} ; ");
                            }
                        }
                    }
                    catch { }
                }
                void WriteOddNumbers(object obj)
                {
                    try
                    {
                        int numberUser = (int)obj;

                        for (int i = 0; i < numberUser; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Console.Write($"{i} ; ");
                            }
                        }
                    }
                    catch { }
                }

                //      i. выводились сначала четные, потом нечетные числа

                Thread.Sleep(5000);
                Console.WriteLine("\ni. выводились сначала четные, потом нечетные числа");
                Thread th3 = new Thread(WriteEvenNumbersLock);
                Thread th4 = new Thread(WriteOddNumbersLock);

                th3.Start(100);
                th4.Start(100);

                void WriteOddNumbersLock(object obj)
                {
                    string objlocker = "null";

                    lock (objlocker)
                    {
                        try
                        {
                            int numberUser = (int)obj;

                            for (int i = 0; i < numberUser; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    Console.Write($"{i} ; ");
                                }
                            }
                        }
                        catch { }
                    }
                }

                void WriteEvenNumbersLock(object obj)
                {
                    string objlocker = "null";

                    lock (objlocker)
                    {
                        try
                        {
                            int numberUser = (int)obj;

                            for (int i = 0; i < numberUser; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    Console.Write($"{i} ; ");
                                }
                            }
                        }
                        catch { }
                    }
                }

                //      ii.последовательно выводились одно четное, другое нечетное.

                Thread.Sleep(5000);
                Console.WriteLine("\nii.последовательно выводились одно четное, другое нечетное");

                var mutex = new Mutex();

                var a = new AutoResetEvent(false);

                Thread th5 = new Thread(WriteEvenNumbersOne);
                Thread th6 = new Thread(WriteOddNumbersOne);

                th5.Start(100);
                th6.Start(100);
                


                void WriteOddNumbersOne(object obj)
                {
                    try
                    {
                        int numberUser = (int)obj;

                        for (int i = 0; i < numberUser; i++)
                        {
                            a.WaitOne();
                            if (i % 2 == 0)
                            {
                                Console.Write($"{i} ; ");
                            }
                            a.Set();
                        }
                    }
                    catch { }
                }

                void WriteEvenNumbersOne(object obj)
                {
                    try
                    {
                        int numberUser = (int)obj;

                        for (int i = 0; i < numberUser; i++)
                        {
                            
                            if (i % 2 != 0)
                            {
                                Console.Write($"{i} ; ");
                            }
                            a.Set();
                            a.WaitOne();
                            
                        }
                    }
                    catch { }
                }

                // 5. Придумайте и реализуйте повторяющуюся задачу на основе класса Timer
                Console.WriteLine();
                int counter = 1;
                TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);
                var timer = new Timer(timerCallback, null, 0, 1000);
                Thread.Sleep(5000);

                void WhatTimeIsIt(object obj)
                {
                    Console.WriteLine(counter);
                    counter++;
                }

                Process.GetCurrentProcess().Kill();
            }
            catch
            {

            }
        }
    }
}