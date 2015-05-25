using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253021
{
    class Queue<T> where T : IComparable
    {
        int rear;
        int front;
        T[] items;

        public Queue(int size)
        {
            items = new T[size];
            front = rear = -1;
        }

        public int size()
        {
            return items.Length;
        }

        public bool isEmpty()
        {
            return front == rear;
        }

        public bool isFull()
        {
            return rear == size() - 1;
        }

        public void enQueue(T val)
        {
            if (isFull())
            {
                throw new Exception("Queue is full");
            }
            else
            {
                items[++rear] = val;
            }
        }

        public T deQueue()
        {
            if (isEmpty())
            {
                throw new Exception("Queue is empty");
            }
            else
            {
                front++;
                return items[front];
            }
        }

        public void display()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack boş");
            }
            else
            {
                int temp = front + 1;
                while (temp <= rear)
                {
                    Console.WriteLine(items[temp++].ToString());
                }
            }
        }

        public void priotyQueue(T val)
        {
            if (isFull())
            {
                throw new Exception("Queue is full");
            }
            else
            {
                int currentIndex = rear;
                int preIndex = rear++;

                while (items[currentIndex].CompareTo(val) == -1 && currentIndex != front)
                {
                    items[preIndex] = items[currentIndex];
                    preIndex = currentIndex;
                    currentIndex--;
                }
                items[preIndex] = val;
            }
        }

    }
}
