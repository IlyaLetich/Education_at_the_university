using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    internal class CollectionProduct : IOrderedDictionary
    {
        ConcurrentBag<Product> products = new ConcurrentBag<Product>();

        public int Count
        { 
            get => products.Count;
        }

        public object this[int counter]
        {
            get
            {
                Product[] array = products.ToArray();
                return array[counter];
            }
            set
            {
                Product[] array = products.ToArray();
                array[counter] = value;
                products.Clear();

                for (int i = 0; i < array.Length; i++)
                {
                    products.Add(array[i]);
                }
            }
        }

        public void Clear()
        {
            products.Clear();
        }

        public void RemoveAt(int counter)
        {
            Product[] array = products.ToArray();
            products.Clear();

            for (int i = 0; i < array.Length; i++)
            {
                if (i == counter) break;
                products.Add(array[i]);
            }
        }

        public void CopyTo(Array arrayUser, int counter)
        {
            Product[] arrayHelp = products.ToArray();
            arrayUser.CopyTo(arrayHelp, counter);
        }


    }
}
