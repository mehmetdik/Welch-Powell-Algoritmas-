using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253021
{
    class LinkedList<T> where T : IComparable
    {
        Node<T> head;

        public Node<T> createNode(T val)
        {
            return new Node<T>(val);
        }

        public bool search(T val)
        {
            Node<T> iterator = head;
            while (iterator != null)
            {
                if (iterator.Value.CompareTo(val) == 0)
                    return true;
                iterator = iterator.Next;
            }
            return false;

        }
        public void addToEnd(T val)
        {
            if (head == null)
                head = createNode(val);//new Node<T>(val);
            else
            {
                Node<T> iterator = head;
                while (iterator.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Next = createNode(val);
            }
        }
        public void addToFront(T val)
        {
            Node<T> newNode = new Node<T>(val);
            newNode.Next = head;
            head = newNode;
        }
        public void display()
        {
            Node<T> iterator = head;

            while (iterator != null)
            {

                Console.WriteLine(iterator.ToString());
                iterator = iterator.Next;
            }
        }


        public int Length()
        {
            Node<T> iterator = head;
            int counter = 0;
            while (iterator != null)
            {
                counter++;
                iterator = iterator.Next;
            }
            return counter;
        }

        public T[] allReturnItem()
        {
            int count = 0;
            T[] allItem = new T[Length()];
            Node<T> iterator = head;
            while (iterator != null)
            {
                allItem[count] = head.Value;
                count++;
                iterator = iterator.Next;
            }
            return allItem;
        }

        public T findSmallest()
        {
            if (head == null)
                throw new Exception("list is empty");

            T min = head.Value;
            Node<T> iterator = head.Next;
            while (iterator != null)
            {
                if (iterator.Value.CompareTo(min) == -1)
                    min = iterator.Value;
                iterator = iterator.Next;
            }
            return min;
        }

        public Queue<Edge> findAllEdges(Edge minEdge, int edgecount)
        {
            Queue<Edge> edgeQueue = new Queue<Edge>(edgecount);
            /*
            Graph optGraph = new Graph();
            
            Node<T> iterator = head;
            while (iterator != null)
            {
                Vertex vertex = optGraph.findVertex(iterator.Value.ToString());
                Edge iteratorEdge = vertex.EdgeLink;
                while (iteratorEdge != null)
                {
                    if (minEdge != null)
                    {
                        if (iteratorEdge.StartId != minEdge.StartId
                        && iteratorEdge.VertexId != minEdge.VertexId &&
                        iteratorEdge.Weight != minEdge.Weight)
                        {
                            edgeQueue.enQueue(iteratorEdge);
                        }
                    }
                    else
                    {
                        edgeQueue.enQueue(iteratorEdge);
                    }
                    iteratorEdge = iteratorEdge.Next;
                }
                iterator = iterator.Next;
            }*/
            return edgeQueue;
        }


        /*  public void bubbleSort()
          {

              Node<T> iterator = head;
              while (iterator != null)
              {
                  while (iterator != null)
                  {
                      if (array[j].Weight > array[j + 1].Weight)//Önce gelen elaman bir sonrakinden büyükse ikisi yer değiştiriyor
                      {
                          temp = array[j];       //
                          array[j] = array[j + 1];// SWAP
                          array[j + 1] = temp;     //
                      }
                  }
                  iterator = iterator.Next;
              }

          }*/

        public LinkedList<T> sortForLinkedList()
        {
            if (head != null)
            {
                Node<T> iterator = head;
                Node<T> minNode;

                while (iterator.Next != null)
                {
                    minNode = findMin(iterator);
                    T temp = iterator.Value;
                    iterator.Value = minNode.Value;
                   
                    minNode.Value = temp;

                    iterator = iterator.Next;
                }
            }
            return this;
        }

        public Node<T> findMin(Node<T> node)//verilen node dan itibaren en küçük elemanı bulur 
        {
            if (node != null)
            {
                Node<T> iterator = node;
                Node<T> minNode = node;
                while (iterator != null)
                {
                    if (minNode.Value.CompareTo(iterator.Value) == 1)
                    {
                        minNode = iterator;
                    }
                    iterator = iterator.Next;
                }
                return minNode;
            }
            return null;
        }

        public LinkedList<T> ListReverseReturn()
        {
            LinkedList<T> list = new LinkedList<T>();

            Node<T> iterator = head;

            while (iterator != null)
            {
                list.addToFront(iterator.Value);
                iterator = iterator.Next;
            }
            return list;
        }

        public Node<T> ReturnNodefromLinklist(int x) {
            int a = 0;
            Node<T> iterator = head;

            while (iterator != null)
            {

                if (a==x)
                {
                    return iterator;   
                }

                a++;
                iterator = iterator.Next;
            }


            return null;   
        
        }

        public void delete(T val)
        {
            //Silinecek eleman listede yoksa çöker
            if (head != null)//hiç eleman yoksa
            {
                while (head!=null && head.Value.Equals(val))//İlk eleman silinecekse
                {
                    head = head.Next;
                }
                if (head != null)
                {

                    Node<T> iterator = head.Next;
                    Node<T> prev = head;
                    while (iterator != null)
                    {

                        if (iterator.Value.Equals(val))
                        {
                            prev.Next = iterator.Next;
                            //break;
                        }
                        prev = iterator;
                        iterator = iterator.Next;
                    }
                }

            }

        }
      

    }
}


