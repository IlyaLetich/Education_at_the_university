using System;

namespace Lab_03
{
    partial class List<T>
    {
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }

        public Node<T> head;
        public Node<T> tail;
        int count;

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        // добавление элемента в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }

        // добавление элемента в конец
        public void AddWithoutTail(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }
        }

        // удаление узла
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {

                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        // проверка на наличие элемента в списке
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void WriteList()
        {
            Console.WriteLine("\n- - - - - - - - вывод списка - - - - - - - - -");
            Node<T> current = head;
            int i = 0;
            while (current != null)
            {
                Console.WriteLine($"\n- - {i} элемент списка - -");
                Console.WriteLine($"Содержание: {current.Data}");
                i++;
                current = current.Next;
            }

            Console.WriteLine("\n- - - - - - - - конец списка - - - - - - - - -");
        }

        private class Production
        {
            private int IDProduction = 001;
            private string Name = "DEAD TOY";

            private class Developer
            {
                private string Name = "Ilya";
                private int ID = 777;
                private string Department = "AGENT";
            }
        }
    }
}