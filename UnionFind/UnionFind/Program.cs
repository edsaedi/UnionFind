using System;
using System.IO;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("file.txt");

            int numObjects = int.Parse(file[0]);

            UnionFind uf = new UnionFind(numObjects);

            for (int i = 1; i < file.Length; i++)
            {
                string temp = file[i];

                string[] split = temp.Split(',');

                int p = int.Parse(split[0]);
                int q = int.Parse(split[1]);

                if (!uf.Connected(p, q))
                {
                    uf.Union(p, q);
                    Console.WriteLine($"{p} {q}");
                }
            }

            Console.WriteLine(uf.NumSets);
        }
    }
}
