using System;
using System.IO;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] file = File.ReadAllLines("file.txt");
            UnionFindPractice Union = new UnionFindPractice(int.Parse(file[0]));

            for (int i = 1; i < file.Length; i++)
            {
                string[] ids = file[1].Split(',');
                Union.Union(int.Parse(ids[0]), int.Parse(ids[1]));
            }

            Console.WriteLine(Union.NumSets());
            Console.WriteLine();



            // Questions:
            // Is phoebe friends with rachel?
            // Is jim friends with creed?
            // Is michael friends with pam?
            // is chandler friends with creed?
            // how many friend groups are there?
            // followup, list each person in the friend groups
            // who is in the largest friend group
            // who is in the smallest friend group
        }
    }
}
