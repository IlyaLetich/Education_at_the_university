using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08
{
    public delegate void LevelUp();
    public delegate void SalaryDown();
    internal class Boss
    {
        public event LevelUp UpLevel;
        public event SalaryDown DownSalary;

        public void CommandDownSalary()
        {
            if (DownSalary != null)
            {
                Console.WriteLine(" !!! Зарплата понижена !!! ");
                DownSalary();
            }
        }
        public void CommandUpLevel()
        {
            if (UpLevel != null)
            {
                Console.WriteLine(" !!! Уровень повышен !!! ");
                UpLevel();
            }
        }
    }
}
