using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
{
    public partial class List<T> : IList<T>
    {
        public static List<T> operator +(List<T> List_01, List<T> List_02)
        {
            if (List_01.head == null)
            {
                List_01.head = List_02.head;
            }
            else
            {
                Node<T> current = List_01.head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = List_02.head;
            }
            return List_01;
        }

        public static List<T> operator --(List<T> List_01)
        {
            Node<T> current = List_01.head;
            List_01.Remove(current.Data);
            return List_01;
        }

        public static bool operator ==(List<T> List_01, List<T> List_02)
        {
            Node<T> current_01 = List_01.head;
            Node<T> current_02 = List_02.head;
            int i = 0;
            while (current_01 != null || current_02 != null)
            {
                if (current_01 != null && current_02 != null)
                {
                    i++;
                    current_01 = current_01.Next;
                    current_02 = current_02.Next;
                }
                else return false;

            }
            return true;
        }

        public static bool operator !=(List<T> List_01, List<T> List_02)
        {
            Node<T> current_01 = List_01.head;
            Node<T> current_02 = List_02.head;
            int i = 0;
            while (current_01 != null || current_02 != null)
            {
                if (current_01 != null && current_02 != null)
                {
                    i++;
                    current_01 = current_01.Next;
                    current_02 = current_02.Next;
                }
                else return true;

            }
            return false;
        }

        public static bool operator true(List<T> List_01)
        {
            Node<T> current_01 = List_01.head;
            if (current_01 == null) return true;
            else return false;
        }
        public static bool operator false(List<T> List_01)
        {
            Node<T> current_01 = List_01.head;
            if (List_01.head == null) return false;
            else return true;
        }
    }
}
