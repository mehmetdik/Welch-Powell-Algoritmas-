using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253021
{
    class Node<T> where T : IComparable
    {
        private T value;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private Node<T> next;

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        public Node(T val)
        {
            this.value = val;
            next = null;
        }
        public override string ToString()
        {
            return value.ToString();
        }

    }
}
