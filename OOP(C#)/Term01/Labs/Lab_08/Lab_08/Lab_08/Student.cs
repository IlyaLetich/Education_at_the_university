using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08
{
    internal class Student
    {
        int Salary;
        int Wallet;

        public Student(int salar)
        {
            Salary = salar;
            Wallet = 0;
        }

        public void Work()
        {
            Console.WriteLine("Работаю!");
            Wallet += 1_000;

        }
        public void OnDownSalary()
        {
            Console.WriteLine("Зарплата студента понижена");
            if (Salary >= 100) Salary -= 100;
            else Salary = 0;
        }

        public override string ToString()
        {
            return $"Студент: Зарплата = {Salary}, Кошелёк = {Wallet}, Зарплата = {Salary}";
        }
    }
}
