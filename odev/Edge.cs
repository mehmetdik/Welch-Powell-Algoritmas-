using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253021
{
    class Edge: IComparable
    {
        string startId;

        public string StartId
        {
            get { return startId; }
            set { startId = value; }
        }
        string vertexId;

        public string VertexId
        {
            get { return vertexId; }
            set { vertexId = value; }
        }
       
        Edge next;

        internal Edge Next
        {
            get { return next; }
            set { next = value; }
        }
        public Edge(string startid, string id)
        {
            this.startId = startid;
            vertexId = id;
        }
        public override string ToString()
        {
            return vertexId;
        }

        public int CompareTo(object obj)
        {
            
            /*Edge otherOgr = (Edge)obj;
            if (weight.CompareTo(otherOgr.weight) == -1)
                return -1;
            else if (weight.CompareTo(otherOgr.weight) == 0)
                return 0;
            else*/
                return 1;
        }
    }
}
