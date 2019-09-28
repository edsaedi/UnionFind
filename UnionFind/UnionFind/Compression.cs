using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    public class Compression
    {
        public int[] parent { get; set; }
        public int[] size { get; set; }
        public int count { get; private set; }

        public Compression(int n)
        {
            count = n;
            parent = new int[n];
            size = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                size[i] = 1;
            }
        }

        public int Find(int p)
        {
            Validate(p);

            int root = p;
            while (root != parent[root])
            {
                root = parent[root];
            }
            while (p != root)
            {
                int newp = parent[p];
                parent[p] = root;
                p = newp;
            }

            return root;
        }

        public void Validate(int p)
        {
            int n = parent.Length;
            if (p < 0 || p >= n)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Union(int p, int q)
       {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ)
            {
                return;
            }

            if (size[rootP] < size[rootQ])
            {
                parent[rootP] = rootQ;
                size[rootQ] += size[rootP];
            }
            else
            {
                parent[rootQ] = rootP;
                size[rootP] += size[rootQ];
            }
            count--;
        }

    }
}
