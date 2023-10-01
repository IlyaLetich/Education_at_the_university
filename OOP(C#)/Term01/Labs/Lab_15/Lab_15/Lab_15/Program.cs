using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_15
{
    static class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            // - - - - - - Task_01 - - - - - -

            Console.WriteLine("- - - - - - Task_01 - - - - - -\n");

            Task<uint> simpleNumbers = new Task<uint>(() => CountQuantityOfSimpleNumbers(1000));

            uint CountQuantityOfSimpleNumbers(uint enumerationBorder)
            {
                var numbers = new List<uint>();
                for (var i = 2u; i < enumerationBorder; i++) numbers.Add(i);

                for (var i = 0; i < numbers.Count; i++)
                    for (var j = 2u; j < enumerationBorder; j++)
                        numbers.Remove(numbers[i] * j);

                return (uint)numbers.Count;
            }

            stopwatch.Restart();
            Console.WriteLine($"Task #{simpleNumbers.Id} status - {simpleNumbers.Status}");
            simpleNumbers.Start();
            Console.WriteLine($"Task #{simpleNumbers.Id} status - {simpleNumbers.Status}");
            simpleNumbers.Wait();
            stopwatch.Stop();
            Console.WriteLine($"Task #{simpleNumbers.Id} status - {simpleNumbers.Status}");

            Console.WriteLine($"Time for Task simple numbers = {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            uint countSimpleNumbers = CountQuantityOfSimpleNumbers(1000);
            stopwatch.Stop();

            Console.WriteLine($"Time for simple numbers = {stopwatch.ElapsedMilliseconds}");
            Console.WriteLine($"Count simple numbers = {countSimpleNumbers}");

            // - - - - - - Task_02 - - - - - -

            Console.WriteLine("\n- - - - - - Task_02- - - - - -\n");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Task<uint> simpleNumbers_02 = new Task<uint>(CountQuantityOfSimpleNumbersWithCancellingToken,cancellationTokenSource.Token, cancellationTokenSource.Token);

            simpleNumbers_02.Start();

            cancellationTokenSource.Cancel();

            try
            {
                cancellationTokenSource.Cancel();
                simpleNumbers_02.Wait();
            }
            catch (AggregateException e)
            {
                if (simpleNumbers_02.IsCanceled)
                    Console.WriteLine($"{simpleNumbers_02.Id} task is canceled");
            }

            uint CountQuantityOfSimpleNumbersWithCancellingToken(object obj)
            {
                var numbers = new List<uint>();
                var token = (CancellationToken)obj;
                for (var i = 2u; i < 1000; i++) numbers.Add(i);

                for (var i = 0; i < numbers.Count; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Cancellation Request");
                        token.ThrowIfCancellationRequested();
                        return 0;
                    }

                    for (var j = 2u; j < 1000; j++) numbers.Remove(numbers[i] * j);
                }

                return (uint)numbers.Count;
            }

            // - - - - - - Task_03 - - - - - -

            Console.WriteLine("\n- - - - - - Task_03 - - - - - -\n");

            double x = 3;
            double y = 4;

            Task<double> calculateHypotenuse = new Task<double>(() => Math.Sqrt(x * x + y * y));
            Task<double> calculatePlace = new Task<double>(() => (x*y)/2);
            Task<string> getConsoleLine = new Task<string>(() => Console.ReadLine());

            calculatePlace.Start();
            calculatePlace.Wait();

            Console.WriteLine($"{calculatePlace.Result}");

            getConsoleLine.Start();
            getConsoleLine.Wait();
            Console.WriteLine($"{getConsoleLine.Result}");

            // - - - - - - Task_04 - - - - - -

            Console.WriteLine("\n- - - - - - Task_04 - - - - - -\n");

            Task<double> calculatePerimetr = calculateHypotenuse.ContinueWith(r => x + y + calculateHypotenuse.Result);
            calculateHypotenuse.Start();
            calculatePerimetr.Wait();
            Console.WriteLine(calculatePerimetr.Result);

            Task<double> calculateHypotenuse_02 = new Task<double>(() => Math.Sqrt(x * x + y * y));

            TaskAwaiter<double> awaiter = calculateHypotenuse_02.GetAwaiter();
            awaiter.OnCompleted(() => {
                double res = -1;
                if (!calculateHypotenuse_02.IsFaulted) res = awaiter.GetResult();
                Console.WriteLine(res);
            });

            calculateHypotenuse_02.Start();


            // - - - - - - Task_05 - - - - - -

            Console.WriteLine("\n- - - - - - Task_05 - - - - - -\n");

            int[] numbers_01 = new int[1000000];
            int[] numbers_02 = new int[1000000];
            int[] numbers_03 = new int[1000000];

            stopwatch.Restart();
            Parallel.For(0, 1000000, (x) =>
            {
                numbers_01[x] = x;
                numbers_02[x] = x;
                numbers_03[x] = x;
            });
            stopwatch.Stop();

            Console.WriteLine($"Test Parallel.For = {stopwatch.ElapsedMilliseconds}");
            
            stopwatch.Restart();
            for(int i = 0; i < 1000000; i++)
            {
                numbers_01[i] = i;
                numbers_02[i] = i;
                numbers_03[i] = i;
            }
            stopwatch.Stop();

            Console.WriteLine($"Test for = {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            Parallel.ForEach(numbers_01, (x) => numbers_01[x] = x * 100 / 200);
            stopwatch.Stop();
            Console.WriteLine($"Test Parallel.Foreach = {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            foreach (var item in numbers_02)
            {
                numbers_02[item] = item * 100 / 200;
            }
            stopwatch.Stop();
            Console.WriteLine($"Test foreach = {stopwatch.ElapsedMilliseconds}");

            // - - - - - - Task_06 - - - - - -

            Console.WriteLine("\n- - - - - - Task_06 - - - - - -\n");

            Parallel.Invoke
            (
                () =>
                {
                    for (var i = 0; i < numbers_01.Length; i++)
                    {
                        numbers_01[i] = i;
                    }
                },
                () =>
                {
                    for (var i = 0; i < numbers_02.Length; i++)
                    {
                        numbers_02[i] = i;
                    }
                },
                () =>
                {
                    for (var i = 0; i < numbers_03.Length; i++)
                    {
                        numbers_03[i] = i;
                    }
                }
            );

            // - - - - - - Task_07 - - - - - -

            Console.WriteLine("\n- - - - - - Task_07 - - - - - -\n");

            BlockingCollection<string> bc = new BlockingCollection<string>(5);
            
            Task[] sellers = new Task[10]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("table");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("chair");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("teapot");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("computer");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("mercedes-benz");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("bmw");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("bed");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("porsche");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("audi");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("ya ne znau sto tut napisat");
                    }
                })
            };

            Task[] consumers = new Task[5]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(300);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(400);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(250);
                        bc.Take();
                    }
                })
            };

            foreach (var i in sellers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            foreach (var i in consumers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            int count = 1;
            while (true)
            {
                if (bc.Count != 0)
                {
                    
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("- - - S t o r e - - -");

                    foreach (var i in bc)
                        Console.WriteLine(i);
                }
            }

            

            // - - - - - - Task_08 - - - - - -

            Console.WriteLine("\n- - - - - - Task_08 - - - - - -\n");
            
            void Factorial()
            {
                int result = 1;
                for (int i = 1; i <= 6; i++)
                    result *= i;
                Thread.Sleep(1000);
                Console.WriteLine($"6! = {result}");
            }

            async void FactorialAsync()
            {
                Console.WriteLine("FA start");
                await Task.Run(() => Factorial());
                Console.WriteLine("FA ends");
            }

            FactorialAsync();
            Console.ReadKey();
            
        }
    }
}