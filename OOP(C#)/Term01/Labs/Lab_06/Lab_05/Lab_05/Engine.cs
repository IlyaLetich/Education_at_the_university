using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    class Engine : IMove
    {
        int Volume;
        public Engine(int V)
        {
            Volume = V;
        }
        public void getEngine()
        {
            Console.WriteLine("Двигатель получен");
        }

        void IMove.Move()
        {
            Console.WriteLine("Двигатель закрутился");
        }
    }
}
