namespace Lab_08
{
    static class Programm
    {
        public delegate string StingProc(ref string str);

        static void Main()
        {
            
            Boss boss = new Boss();
            Student student_01 = new Student(400);
            Employees employees_01 = new Employees(1000, 10, 450);

            boss.UpLevel += new LevelUp(employees_01.OnUpLevel);
            boss.DownSalary += new SalaryDown(student_01.OnDownSalary);
            boss.DownSalary += new SalaryDown(employees_01.OnDownSalary);

            Console.WriteLine(" - - - Тест до событий - - - - -");
            Console.WriteLine();
            Console.WriteLine(student_01.ToString());
            Console.WriteLine(employees_01.ToString());

            Console.WriteLine();
            Console.WriteLine(" - - - Происходят события - - - - ");
            boss.CommandUpLevel();
            boss.CommandDownSalary();
            Console.WriteLine();

            Console.WriteLine(" - - - Тест после событий - - - -");
            Console.WriteLine();
            Console.WriteLine(student_01.ToString());
            Console.WriteLine(employees_01.ToString());
            Console.WriteLine();

            Console.WriteLine(" - - Результат обработки строки - -");
            Console.WriteLine();
            
            StingProc processingString = ProcessingString.WriteString;
            processingString += ProcessingString.ToUpperCASE;
            processingString += ProcessingString.WriteString;
            processingString += ProcessingString.ReplaceChar;
            processingString += ProcessingString.WriteString;
            processingString += ProcessingString.FindChar;

            string strBei = "Привет,друг!Как,твои,дела";
            processingString(ref strBei);
        }
    }
}