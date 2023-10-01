using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    internal class Product
    {
        private string   Name;
        private int      Id;
        private int      Volume;
        private int      Price;

        public Product(string name, int id, int volume, int price)
        {
            Name = name;
            Id = id;
            Volume = volume;
            Price = price;
        }
    }
}
