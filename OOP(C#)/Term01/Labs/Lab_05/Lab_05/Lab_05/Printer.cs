using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    class Printer
    {
        public void IAmPrinting(Vehicle[] collection)
        {
            foreach (Vehicle obj in collection)
            {
                iIAmPrinting(obj);
            }
        }
        public void iIAmPrinting(Vehicle obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }
    }
}
