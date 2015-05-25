using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253021
{
    class QueueOperation
    {
        public bool search(Queue<string> edgeQueue, string id)
        {
            bool flag = false;
            if (edgeQueue.isEmpty())
                return flag;
            else
            {
                Queue<string> tempQue = new Queue<string>(edgeQueue.size());
                while (!edgeQueue.isEmpty())
                {
                    string popped = edgeQueue.deQueue();
                    tempQue.enQueue(popped);
                    if (popped.CompareTo(id) == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                while (!tempQue.isEmpty())
                    edgeQueue.enQueue(tempQue.deQueue());
                return flag;

            }
        }
    }
}
