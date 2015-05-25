using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace _12253021
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList color = new ArrayList();//Renkleri tutmak için Arraylist oluşturduk.
            color.Add("Red");
            color.Add("Yellow");
            color.Add("Blue");
            color.Add("Black");
            color.Add("Purple");
            color.Add("Brown");
            color.Add("Green");
            color.Add("Pink");
            color.Add("Grey");
            color.Add("White");
            color.Add("Silver");

            Graph myGraph = new Graph();//Yeni bir graph oluşturduk

            StreamReader objReader = new StreamReader("O2Turkiye.txt");//Dosya'da bulunan şehirleri Vertex olarak Grapha'a ekliyeceğiz
            string sLine = "";

            while (sLine != null)
            {

                sLine = objReader.ReadLine();//Txt'dek ilk satırı sLine atadık.
                string[] temp = null;
                if (sLine != null)
                {
                    temp = sLine.Split(' ');//sLine'da bulunan yazıyı boşluklara kadar olan yerleri diziye atadık sırasıyla.

                    if (temp[0] != null)
                        myGraph.addVertex(temp[0]);//graph'a vertex ekledik.

                }


            }



            StreamReader objReader2 = new StreamReader("O2Turkiye.txt");//Dosya'da bulunan şehirlerin Edege'lerini graph'a ekliyeceğiz.
            sLine = "";
            while (sLine != null)
            {
                sLine = objReader2.ReadLine();
                string[] temp2 = null;
                if (sLine != null)
                {
                    temp2 = sLine.Split(' ');


                    for (int i = 1; i < temp2.Length; i++)
                    {
                        myGraph.addEdge(temp2[0], temp2[i]);
                    }

                }
            }

            StreamReader objReader3 = new StreamReader("O2Turkiye.txt");//ArrayList'e ekleme yapıcağız.
            sLine = "";
            LinkedList<Vertex> list = new LinkedList<Vertex>();
            // ArrayList arrText = new ArrayList();

            while (sLine != null)
            {

                sLine = objReader3.ReadLine();
                string[] temp = null;
                if (sLine != null)
                {
                    temp = sLine.Split(' ');

                    if (temp[0] != null)
                        list.addToFront(myGraph.findVertex(temp[0]));//Vertexi graph'da arattık ve liste ekledik


                }


            }
            objReader.Close();

            // myGraph.display();

            myGraph.vertexEdgesCount();//Graph'daki bütün edge sayısını hesaplar


            list = list.sortForLinkedList();//List'deki şehirlerin Edgelerine göre sıralama yapar 
            list = list.ListReverseReturn();//Listeyi ters döndürür.
            Console.WriteLine("----------Komşusu enfazla olandan enaza şehir sıralanışı----------");
            list.display();


            int colorcount = 0;
            for (int i = 0; i < list.Length(); i++)
            {
                ArrayList arrayList = new ArrayList();
                arrayList.Add(list.ReturnNodefromLinklist(i).Value);
                list.ReturnNodefromLinklist(i).Value.color = color[colorcount].ToString();
                Console.WriteLine("\n--------------------THE COLOR OF THE CİTY-----------------\n");
                Console.WriteLine("The color of " + list.ReturnNodefromLinklist(i).Value.ToString() + " city --> " + list.ReturnNodefromLinklist(i).Value.color);
                for (int j = i + 1; j < list.Length(); j++)
                {
                    int temp = 0;
                    int temp2 = 0;
                    Edge x = list.ReturnNodefromLinklist(j).Value.EdgeLink;
                    while (x != null)
                    {
                        for (int z = 0; z < arrayList.Count; z++)
                        {
                            if (arrayList[z].ToString().Equals(x.ToString()))
                            {
                                temp++;
                                temp2++;
                                break;

                            }

                        }

                        if (temp2 != 0)
                        {
                            break;
                        }
                        x = x.Next;
                    }
                    if (temp == 0)
                    {
                        list.ReturnNodefromLinklist(j).Value.color = color[colorcount].ToString();//Şehire renk atadık
                        Console.WriteLine("The color of " + list.ReturnNodefromLinklist(j).Value.ToString() + " city --> " + list.ReturnNodefromLinklist(j).Value.color);//Şehrin rengini yazdırdık
                        arrayList.Add(list.ReturnNodefromLinklist(j).Value);
                        list.delete(list.ReturnNodefromLinklist(j).Value);
                        j--;
                    }
                }

                list.delete(list.ReturnNodefromLinklist(i).Value);//Şehri sildik.
                i = -1;

                colorcount++;
            }
            Console.WriteLine("\n\n-------------------------------\n");
            Console.WriteLine("5 farklı renk kullanılmıştır.");

            Console.ReadLine();

            

        }
    }
}
