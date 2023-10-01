using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
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

    public partial class List<T> : IList<T>
    {
        public Node<T> head;
        public Node<T> tail;
        int count;
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
