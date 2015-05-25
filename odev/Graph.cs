using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253021
{
    class Graph : IComparable
    {
        Vertex head;

        public Vertex createVertex(string id)
        {
            return new Vertex(id);
        }

        public Edge createEdge(string startid, string id)
        {
            return new Edge(startid, id);
        }

        public Vertex findVertex(string id)
        {
            Vertex iterator = head;
            while (iterator != null)
            {
                if (iterator.Id == id)
                    return iterator;
                iterator = iterator.Next;
            }
            return null;
        }

        public bool searchVertex(string id)
        {
            Vertex iterator = head;
            while (iterator != null)
            {
                if (iterator.Id == id)
                    return true;
                iterator = iterator.Next;
            }
            return false;
        }

        public bool searchEdge(string id, Vertex current)
        {
            Vertex iterator = current;
            Edge edgeiterator = iterator.EdgeLink;
            while (edgeiterator != null)
            {
                if (edgeiterator.VertexId == id)
                    return true;
                edgeiterator = edgeiterator.Next;
            }
            return false;
        }


        public void display()
        {
            Vertex iterator = head;
            while (iterator != null)
            {
                Console.Write(iterator.ToString() + " --> ");
                Edge iteratorEdge = iterator.EdgeLink;
                while (iteratorEdge != null)
                {
                    Console.Write(iteratorEdge.ToString() + " ");
                    iteratorEdge = iteratorEdge.Next;
                }
                Console.WriteLine();
                iterator = iterator.Next;
            }
            Console.WriteLine();
        }
        public int vertexCount()
        {
            int counter = 0;
            Vertex iterator = head;
            while (iterator != null)
            {
                counter++;
                iterator = iterator.Next;
            }
            return counter;
        }

        public void vertexEdgesCount()
        {
            
            Vertex iterator = head;
            while (iterator != null)
            {
                int counter = 0;
                Edge iteratorEdge = iterator.EdgeLink;
                while (iteratorEdge != null)
                {
                    counter++;
                    iteratorEdge = iteratorEdge.Next;
                }
                iterator.EdgeSayisi = counter;
                iterator = iterator.Next;
            }
            
        }
        public int edgeCount()
        {
            int counter = 0;

            Vertex iterator = head;
            while (iterator != null)
            {
               
                Edge iteratorEdge = iterator.EdgeLink;
                while (iteratorEdge != null)
                {
                    counter++;
                    iteratorEdge = iteratorEdge.Next;
                }
               
                iterator = iterator.Next;
            }
            return counter;
        }

        public Queue<Edge> findAllEdges() //Graph içerisindeki tüm edgeleri bulur.
        {
            int count = 0;
            Edge[] edgeArray = new Edge[edgeCount()];
            Queue<Edge> edgeQueue = new Queue<Edge>(edgeCount());
            Vertex iterator = head;
            while (iterator != null)
            {
                Edge iteratorEdge = iterator.EdgeLink;
                while (iteratorEdge != null)
                {
                    edgeArray[count] = iteratorEdge;
                    iteratorEdge = iteratorEdge.Next;
                    count++;
                }
                iterator = iterator.Next;
            }
            bubbleSort(edgeArray);// sıralama yapılır ardında queue ya atılır
            for (int i = 0; i < edgeArray.Length; i++)
            {
                edgeQueue.enQueue(edgeArray[i]);
            }
            return edgeQueue;
        }

        public void bubbleSort(Edge[] array)
        {/*
            Edge temp = null;
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].Weight > array[j + 1].Weight)//Önce gelen elaman bir sonrakinden büyükse ikisi yer değiştiriyor
                    {
                        temp = array[j];       //
                        array[j] = array[j + 1];// SWAP
                        array[j + 1] = temp;     //
                    }
                }
            }*/
        }



        public void addVertex(string id)
        {
            Vertex iterator = head;
            if (head == null)
            {
                head = createVertex(id);
            }
            else
            {
                if (!searchVertex(id))
                {
                    while (iterator.Next != null)
                    {
                        iterator = iterator.Next;
                    }
                    iterator.Next = createVertex(id);
                }
            }
        }

        public void addEdge(string startId, string endId)
        {
            if (searchVertex(startId) && searchVertex(endId))
            {
                Vertex myVertex = findVertex(startId);
                Edge edgeIterator = myVertex.EdgeLink;
                if (edgeIterator == null)
                {
                    myVertex.EdgeLink = createEdge(startId, endId);
                }
                else
                {
                    if (!searchEdge(endId, myVertex))
                    {
                        while (edgeIterator.Next != null)
                        {
                            edgeIterator = edgeIterator.Next;
                        }
                        edgeIterator.Next = createEdge(startId, endId);
                    }
                }
            }
        }

        public Graph copyGraph()
        {
            Graph newGraph = new Graph();
           /* Vertex iterator = head;
            while (iterator != null)
            {
                newGraph.addVertex(iterator.Id);
                iterator = iterator.Next;
            }
            iterator = head;
            while (iterator != null)
            {
                Edge edgeIterator = iterator.EdgeLink;
                while (edgeIterator != null)
                {
                    newGraph.addEdge(iterator.Id, edgeIterator.VertexId, edgeIterator.Weight);
                    edgeIterator = edgeIterator.Next;
                }
                iterator = iterator.Next;
            }
            */
            return newGraph;
        }

        public Graph kruskal(Queue<Edge> allEdges) //Kruskal Algorithm
        {
            Graph kruskalGraph = new Graph();
            /*
           
            LinkedList<string> vertexids = new LinkedList<string>();
            Vertex iterator = head;
            while (iterator != null) // tüm vertexleri kruskal graphına ekliyoruz.
            {
                kruskalGraph.addVertex(iterator.Id);
                iterator = iterator.Next;
            }
            for (int i = 0; i < allEdges.size(); i++)
            {
                if (vertexids.Length() == 0) //ilk durum için
                {
                    Edge firstEdge = allEdges.deQueue();
                    kruskalGraph.addEdge(firstEdge.StartId, firstEdge.VertexId, firstEdge.Weight);
                    //ziyaret edildiğini tutmak adına listeye idyi ekliyoruz
                    vertexids.addToEnd(firstEdge.StartId);
                    vertexids.addToEnd(firstEdge.VertexId);
                }
                else
                {
                    QueueOperation qopt = new QueueOperation();
                    Edge edge = allEdges.deQueue();
                    //Eğer edge in iki ucuda listede varsa devam eder.1 veya daha az ucun listede bulunması 
                    //durumunda listede bulunmayan ucu listeye kaydeder ve edge i grapha ekler
                    if (vertexids.search(edge.StartId) && vertexids.search(edge.VertexId))
                    {
                        continue;
                    }
                    else
                    {
                        if (!vertexids.search(edge.StartId))
                        {
                            vertexids.addToEnd(edge.StartId);
                        }
                        if (!vertexids.search(edge.VertexId))
                        {
                            vertexids.addToEnd(edge.VertexId);
                        }
                        kruskalGraph.addEdge(edge.StartId, edge.VertexId, edge.Weight);
                    }
                }
            }*/
            return kruskalGraph;
        }

        public Graph primAlgorithm()
        {
            Graph primGraph = new Graph();
           /* Vertex[] visitedvertexs = new Vertex[vertexCount()];
            Edge[] minEdges = new Edge[edgeCount()];
            Vertex iterator = head;
            int count = 1;
            visitedvertexs[0] = head;//Başlangıç noktası olarak head i seçiyorum.                    
            while (iterator != null)
            {
                primGraph.addVertex(iterator.Id);
                iterator = iterator.Next;
            }
            for (int i = 0; i < vertexCount(); i++)
            {
                Queue<Edge> allEdges = findAllEdgeForPrim(visitedvertexs);//vertexlerin tüm edgelerini bul.
                Queue<Edge> deletedMinEdgeAllEdge = deleteMinEdge(minEdges, allEdges);//ziyaret edilmiş edgeleri listeden 
                //siliyoruz. Tekrar minEdge olarak alınmaması için
                Edge minEdge = findMinEdge(deletedMinEdgeAllEdge, minEdges, visitedvertexs);// min edge i bul
                minEdges[i] = minEdge;
                primGraph.addEdge(minEdge.StartId, minEdge.VertexId, minEdge.Weight);
                Vertex myVertex = findVertex(minEdge.VertexId);
                if (count < vertexCount())
                {
                    visitedvertexs[count] = myVertex;
                    count++;
                }

            }*/
            return primGraph;
        }


        public Queue<Edge> findAllEdgeForPrim(Vertex[] visitedvertex) // prim içi vertexlere ait edgeleri bulur
        {
            Queue<Edge> edgeQueue = new Queue<Edge>(edgeCount());
            for (int i = 0; i < visitedvertex.Length; i++)
            {
                if (visitedvertex[i] != null)
                {
                    Edge iteratorEdge = visitedvertex[i].EdgeLink;
                    while (iteratorEdge != null)
                    {
                        edgeQueue.enQueue(iteratorEdge);
                        iteratorEdge = iteratorEdge.Next;
                    }
                }
            }
            return edgeQueue;
        }

        public bool isMinEdge(Edge[] minEdges, Edge edge) // daha önce min edge olarak kullanılmışmı kontrolü
        {
            for (int i = 0; i < minEdges.Length; i++)
            {
                if (minEdges[i] != null)
                {
                    if (minEdges[i] == edge)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Queue<Edge> deleteMinEdge(Edge[] minEdges, Queue<Edge> allEdge)//daha önce min edge olmuşsa listeden siler
        {
            Queue<Edge> tempQueue = new Queue<Edge>(edgeCount());
            while (!allEdge.isEmpty())
            {
                Edge edge = allEdge.deQueue();
                if (!isMinEdge(minEdges, edge))
                {
                    tempQueue.enQueue(edge);
                }
            }
            return tempQueue;
        }
        
        public Edge findMinEdge(Queue<Edge> allEdge, Edge[] minEdges, Vertex[] visited)
        {
            
            Edge minEdge = allEdge.deQueue();
           /*
            int minWeight = minEdge.Weight;
            LinkedList<string> vertexId = new LinkedList<string>();
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] != null)
                {
                    vertexId.addToEnd(visited[i].Id);
                }                
            }
            if (isMinEdge(minEdges, minEdge) || (vertexId.search(minEdge.StartId) 
                && vertexId.search(minEdge.VertexId)))
            {
                minEdge = allEdge.deQueue();
                minWeight = minEdge.Weight;

            }
            while (!allEdge.isEmpty())
            {
                Edge edge = allEdge.deQueue();
                if (edge.Weight.CompareTo(minWeight) == -1 && !isMinEdge(minEdges, edge)
                    && !(vertexId.search(edge.StartId) && vertexId.search(edge.VertexId)))
                {
                    minWeight = edge.Weight;
                    minEdge = edge;
                }
            }*/
            return minEdge;
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
