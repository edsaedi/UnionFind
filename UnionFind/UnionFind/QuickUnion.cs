using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UnionFind
{
    public class QuickUnion
    {
        public int[] id { get; private set; }
        public int[] size { get; private set; }

        public int Capacity { get; private set; }

        public QuickUnion(int capacity)
        {
            Capacity = capacity;
            id = new int[capacity];
            size = new int[capacity];

            for (int i = 0; i < capacity; i++)
            {
                id[i] = i;
                size[i] = 1;
            }

        }

        public int Find(int index)
        {
            while (id[index] != index)
            {
                index = id[index];
            }
            return id[index];
        }

        public bool IsConnected(int p, int q) => Find(p) == Find(q);

        public void Union(int p, int q)
        {
            if (size[p] < size[q])
            {
                id[p] = id[q];
                size[p] += size[q];
            }
            else
            {
                id[q] = id[p];
                size[q] += size[p];
            }

        }
    }
}
