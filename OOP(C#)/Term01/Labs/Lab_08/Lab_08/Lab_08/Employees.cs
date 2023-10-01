using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08
{
    internal class Employees
    {
        int Salary;
        int Level;
        int Wallet;

        public Employees(int salar, int level, int wallet)
        {
            Salary = salar;
            Level = level;
            Wallet = wallet;
        }

        public void Work()
        {
            Console.WriteLine("Работаю!");
            Wallet += 10_000;
        }
        public void OnDownSalary()
        {
            Console.WriteLine("Зарплата работника понижена");
            if (Salary >= 100) Salary -= 100;
            else Salary = 0;
        }
        public void OnUpLevel()
        {
            Console.WriteLine("Нас повысили!!!Ураааааа");
            Level++;
        }
        public override string ToString()
        {
            return $"Работник: Зарплата = {Salary}, Кошелёк = {Wallet}, Зарплата = {Salary}, Уровень = {Level}";
        }
    }
}
