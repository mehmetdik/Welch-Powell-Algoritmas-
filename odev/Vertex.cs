using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253021
{
    class Vertex: IComparable
    {
        string id;
        int edgeSayisi;
        public string color;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public int EdgeSayisi
        {
            get { return edgeSayisi; }
            set { edgeSayisi = value; }
        }
        Vertex next;

        internal Vertex Next
        {
            get { return next; }
            set { next = value; }
        }
        Edge edgeLink;

        internal Edge EdgeLink
        {
            get { return edgeLink; }
            set { edgeLink = value; }
        }
        public Vertex(string id)
        {
            this.id = id;
        }
        public override string ToString()
        {
            return id;
        }

        public int CompareTo(object obj)
        {
            Vertex otherOgr = (Vertex)obj;
            if (edgeSayisi.CompareTo(otherOgr.edgeSayisi) == -1)
                return -1;
            else if (edgeSayisi.CompareTo(otherOgr.edgeSayisi) == 0)
                return 0;
            else
                return 1;
        }
    }
}
