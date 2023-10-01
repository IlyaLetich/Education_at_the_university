using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
{
    interface IList<T>
    {
        void Add(T data);
        void AppendFirst(T data);
        void AddWithoutTail(T data);
        bool Remove(T data);
        bool Contains(T data);
        void WriteList();
    }
}