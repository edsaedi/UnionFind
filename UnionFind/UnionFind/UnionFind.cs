using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace UnionFind
{
    public class UnionFind
    {
        int[] id;
        public UnionFind(int capacity)
        {
            id = new int[capacity];

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
        }

        public int NumSets => id.Distinct().Count();

        public bool Connected(int p, int q) => Find(p) == Find(q);

        public int Find(int q) => id[q];

        public void Union(int p, int q)
        {
            int pId = Find(p);

            int qId = Find(q);

            //If connected
            if (pId == qId) return;

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pId)
                {
                    id[i] = qId;
                }
            }
        }





    }
}
