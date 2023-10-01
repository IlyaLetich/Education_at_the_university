using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lab_01
{
    class Lab_01
    {
        [STAThread]
        static void Main(string[] args)
        {
            //----------------------------------------------------------------------------------------------------------------------------------

            //ЗАДАНИЕ 1 ( ТИПЫ )

            Console.WriteLine("-------------------------Задание 1-------------------------------");

            //Определение и инициализация
            bool bool_01 = true;
            byte byte_01 = 1;
            sbyte sbyte_01 = -1;
            char char_01 = 'A';
            decimal decimal_01 = 7777777;
            double double_01 = 7.77;
            short short_01 = 100;
            int int_01 = 12;
            long long_01 = 20000;
            float float_01 = 12.12f;
            uint uint_01 = 12;
            nint nint_01 = 11;
            nuint nuint_01 = 777;
            ulong ulong_01 = 1717171717;
            ushort ushort_01 = 255;

            //Вывод в консоль
            Console.WriteLine("bool = {0}", bool_01);
            Console.WriteLine("byte = {0}", byte_01);
            Console.WriteLine("sbyte = {0}", sbyte_01);
            Console.WriteLine("char = {0}", char_01);
            Console.WriteLine("decimal = {0}", decimal_01);
            Console.WriteLine("double = {0}", double_01);
            Console.WriteLine("short = {0}", short_01);
            Console.WriteLine("long = {0}", long_01);
            Console.WriteLine("float = {0}", float_01);
            Console.WriteLine("uint = {0}", uint_01);
            Console.WriteLine("nint = {0}", nint_01);
            Console.WriteLine("nuint = {0}", nuint_01);
            Console.WriteLine("ulong = {0}", ulong_01);
            Console.WriteLine("ushort = {0}", ushort_01);
            Console.WriteLine("int = {0}", int_01);

            //Явное преобразование
            float a = 7.77f;
            int b = (int)a;
            Console.WriteLine("\nЯвное преобразование 7.77(float) в int : " + b);
            char a1 = 'A';
            int b1 = (int)a1;
            Console.WriteLine("Явное преобразование 'A'(char) в int : " + b1);
            long a2 = 777L;
            double b2 = (long)a2;
            Console.WriteLine("Явное преобразование 777(long) в double : " + b2);
            float a3 = 7.7777f;
            double b3 = (float)a3;
            Console.WriteLine("Явное преобразование 7.777(float) в double : " + b3);
            int a4 = 49;
            char b4 = (char)a4;
            Console.WriteLine("Явное преобразование 49(int) в char : " + b4);

            //Неявное преобразование
            short an = 7;
            int bn = an;
            Console.WriteLine("Неявное преобразование 7(short) в int : " + bn);
            long an1 = 777L;
            double bn1 = an1;
            Console.WriteLine("Неявное преобразование 777(long) в double : " + bn1);
            float an2 = 7.777f;
            double bn2 = an2;
            Console.WriteLine("Неявное преобразование 7.777(float) в double : " + bn2);
            char an3 = 'A';
            int bn3 = an3;
            Console.WriteLine("Неявное преобразование 'A'(char) в int : " + bn3);
            byte an4 = 1;
            int bn4 = an4;
            Console.WriteLine("Невное преобразование 1(byte) в int : " + bn4);

            //Класс Convert
            double con_01 = 12.08;

            bool conres_01 = System.Convert.ToBoolean(con_01);
            string conres_02 = System.Convert.ToString(con_01);
            Console.WriteLine("\nИспользование класса Convers" +
                "\nРезудьтат 1(Из 12.08 (double) в bool) = {0}" +
                "\nРезудьтат 2(Из 12.08 (double) в string) = {1}", conres_01, conres_02);

            //Упаковка значимых типов
            string dataHappy = "12.08.2004";
            Object data_01 = dataHappy;
            //Распаковка значимых типов
            string dataInfo = (string)data_01;
            Console.WriteLine("\nРаспакованная dataHappy = {0}", dataInfo);

            //Работа с неявно типизированной переменной
            var i_num = 1;
            var i_str = "Hello";
            i_num = i_num + 2;
            i_str += " World";
            Console.WriteLine("\nПеременная(var(num)) = {0}", i_num);
            Console.WriteLine("Переменная(var(str)) = {0}", i_str);

            //Nullable переменные
            Nullable<int> i = null;
            i = 10;
            if (i.HasValue)
                //Console.WriteLine(i.Value);
                Console.WriteLine("\nNullable int i = {0}", i);
            else
                Console.WriteLine("\nNullable int i = Null(Пусто)");

            //Var
            var a_var = 12;
            //a_var = "Hello";


            //----------------------------------------------------------------------------------------------------------------------------------

            //ЗАДАНИЕ 2 ( СТРОКИ )

            Console.WriteLine("\n-------------------------Задание 2-------------------------------");

            //Строковые литераллы и их сравнение
            string strTest_01 = "Hello";
            string strTest_02 = "Alex";
            int result_str = string.Compare(strTest_01, strTest_02);
            if (result_str < 0)
            {
                Console.WriteLine("\nСтрока {0} по алфавиту выше, чем {1}", strTest_01, strTest_02);
            }
            else if (result_str > 0)
            {
                Console.WriteLine("\nСтрока {0} по алфавиту выше, чем {1}", strTest_02, strTest_01);
            }
            else if (String.Equals(strTest_01, strTest_02))
            {
                Console.WriteLine("\nСтроки одинаковые!");
            }
            else
            {
                Console.WriteLine("\nЧто-то пошло не так :(");
            }

            //сцепление,копирование, выделение подстроки, разделение строки на слова,
            //вставки подстроки в заданную позицию, удаление заданной подстроки
            string str_01 = "Hello";
            string str_02 = "World";
            string str_03 = "!!!";
            //сцепление
            Console.WriteLine("\nstr_01 + str_02 + str_03 = {0}", str_01 + str_02 + str_03);
            Console.WriteLine("String.Concat(str_01,str_02,str_03) = {0}", String.Concat(str_01, str_02, str_03));
            Console.WriteLine("String.Join( # ,str_01,str_02,str_03) = {0}", String.Join(" # ", str_01, str_02, str_03));
            //копирование
            string strCopy_01 = String.Copy(str_01);
            Console.WriteLine("String.Copy(str_01) = {0}", strCopy_01);
            //выделение подстроки
            Console.WriteLine($"Выделенная подстрока:{str_01.Substring(1, 2)}");
            //разделение строки на слова
            Console.WriteLine("Слова из строки Hello World", strCopy_01);
            string strText = "Hello World !!!";
            string[] words = strText.Split(' ');
            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            //вставка подстроки в заданную позицию
            string strInsert = str_01.Insert(3, str_03);
            Console.WriteLine("Вставка подстроки: {0}", strInsert);
            //удаление заданной подстроки
            strInsert = String.Concat(str_01, str_02, str_03);
            Console.WriteLine("Строка до удаления: {0}", strInsert);
            string strRemove = strInsert.Remove(5, 5);
            Console.WriteLine("Строка после удаления: {0}", strRemove);
            //интерполяция строк
            Console.WriteLine($"Интерполированная строка {DateTime.Now}");
            //использование метода string.IsNullOrEmpty
            string strNull = null;
            string strEmpty = "";
            if (String.IsNullOrEmpty(strNull))
            {
                Console.WriteLine($"Строка strNull пустая или null");
            }
            else Console.WriteLine($"Строка strNull не пустая");
            if (String.IsNullOrEmpty(strEmpty))
            {
                Console.WriteLine($"Строка strEmpty пустая или null");
            }
            else Console.WriteLine($"Строка strEmpty не пустая");
            //StringBuilder
            StringBuilder sb_01 = new StringBuilder("Hello World!!!");
            Console.WriteLine($"StringBuilder = {sb_01.ToString()}");
            sb_01.Append(" # мир!!!");
            sb_01.Insert(0, "Привет # ");
            Console.WriteLine($"Изменённый StringBuilder = {sb_01.ToString()}");

            //----------------------------------------------------------------------------------------------------------------------------------

            //ЗАДАНИЕ 3 ( МАССИВЫ )

            Console.WriteLine("\n-------------------------Задание 3-------------------------------");

            //матрица
            Console.WriteLine("А какие у нас размеры матрицы?");
            Console.Write("Введите количество строк: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            int m = int.Parse(Console.ReadLine());
            int[,] arrM_01 = new int[n, m];
            Random rand = new Random();
            //Заполнение случайными числами и вывод
            Console.WriteLine();
            for (int i_01 = 0; i_01 < n; i_01++)
            {
                for (int j = 0; j < m; j++)
                {
                    arrM_01[i_01, j] = rand.Next(1, 10);
                    Console.Write($"    {arrM_01[i_01, j]}\t");
                }
                Console.WriteLine();
            }

            //одномерный массив строк
            string[] mass_01 = new string[7] { "Artem", "Lexa", "Sanya", "Roma", "Wasya", "Egor", "Yuri" };
            Console.WriteLine($"\n{mass_01[0]}, {mass_01[1]}, {mass_01[2]}, {mass_01[3]}, {mass_01[4]}, {mass_01[5]}, {mass_01[6]}");
            Console.Write("Введите номер элемента, который Вы хотите заменить: ");
            int NumMass = int.Parse(Console.ReadLine());
            Console.Write("Введите значение элемента, которое Вы хотите увидеть: ");
            mass_01[NumMass] = Console.ReadLine();
            Console.WriteLine($"\n{mass_01[0]}, {mass_01[1]}, {mass_01[2]}, {mass_01[3]}, {mass_01[4]}, {mass_01[5]}, {mass_01[6]}");

            //ступечатый (не выровненный) массив вещественных чисел с  3 - мя 
            //строками, в каждой из которых 2, 3 и 4 столбцов соответственно
            int[][] massInt_01 = new int[3][];
            massInt_01[0] = new int[2];
            massInt_01[1] = new int[3];
            massInt_01[2] = new int[4];
            //вывод и заполнение
            for (int i_01 = 0; i_01 < 3; i_01++)
            {
                for (int j = 0; j < massInt_01[i_01].Length; j++)
                {
                    massInt_01[i_01][j] = rand.Next(1, 10);
                    Console.Write($"    {massInt_01[i_01][j]}\t");
                }
                Console.WriteLine();
            }

            //неявно типизированные массив
            var massA = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var massB = new[] { "wasya", "smelov", "jilyak" };
            var massC = new[] { 1.11, 2.22, 3.33, 4.44, 5.55, 6.66, 7.77 };

            //----------------------------------------------------------------------------------------------------------------------------------

            //ЗАДАНИЕ 4 ( КОРТЕЖИ )

            Console.WriteLine("\n-------------------------Задание незасчитано-------------------------------");

            //объявление и инициализация
            (int date, string strKor, char charka, string strTus, ulong lety) kor_01 = (12, "obwaga", 'r', "tusa", 777);
            Console.WriteLine("Вывод целиком");
            Console.WriteLine(kor_01);
            Console.WriteLine("Вывод частично");
            Console.WriteLine(kor_01.date + " " + kor_01.strTus + " " + kor_01.charka);
            //распаковка
            var ras_01 = kor_01.Item1;
            var ras_02 = kor_01.charka;
            //демонстрация переменной (_)
            var _ = 12;
            _ = _ + 12;
            Console.WriteLine("Демонстрация переменной _ = {0}", _);
            //сравнение кортежей
            var k_01 = (777, 12);
            (int, long) k_02 = (777, 12);
            (short, byte) k_03 = (777, 12);
            //(string, byte) k_04 = ("777", 12);
            Console.WriteLine("k_01==k_02? {0}", k_01 == k_02);
            Console.WriteLine("k_01==k_03? {0}", k_01 == k_03);
            Console.WriteLine("k_02==k_03? {0}", k_02 == k_03);
            //Console.WriteLine("k_04==k_03? {0}", k_04 == k_03);

            //----------------------------------------------------------------------------------------------------------------------------------

            //ЗАДАНИЕ 5 ( ЛОКАЛЬНАЯ ФУНКЦИЯ )
            Console.WriteLine("\n-------------------------Задание 5-------------------------------");

            int[] arrInt = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string localString = "TestLocalFunction";

            //локальная функция
            (int, int, string) korFunc(int[] arrInt, string strFunc)
            {
                int maxEl = arrInt[0];
                int minEl = arrInt[0];
                string chSym;

                for (int i = 1; i < arrInt.Length; i++)
                {
                    if (maxEl < arrInt[i])
                    {
                        maxEl = arrInt[i];
                    }
                    if (minEl > arrInt[i])
                    {
                        minEl = arrInt[i];
                    }
                }
                chSym = strFunc.Substring(0, 1);

                return (maxEl, minEl, chSym);
            }

            (int, int, string) korResult;
            korResult = korFunc(arrInt, localString);

            Console.WriteLine($"\nРезультат работы функции -  {korResult}");


            //----------------------------------------------------------------------------------------------------------------------------------

            //ЗАДАНИЕ 6 ( Работа с checked/unchecked )

            Console.WriteLine("\n-------------------------Задание 6-------------------------------");


            void workChecked(int xNumber)
            {
                checked
                {
                    int numCh = xNumber + 1;
                    Console.WriteLine($"\nРезультат = {numCh}");
                }
            };

            void workUnchecked(int xNumber)
            {
                unchecked
                {
                    int numUn = xNumber + 1;
                    Console.WriteLine($"\nРезультат = {numUn}");
                }
            };

            //workChecked(int.MaxValue);
            workUnchecked(int.MaxValue);

            //----------------------------------------------------------------------------------------------------------------------------------

        }
    }
}