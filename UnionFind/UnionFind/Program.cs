using System;
using System.Collections.Generic;
using System.IO;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] file = File.ReadAllLines(@"\\GMRDC1\Folder Redirection\Edan.Saedi\Desktop\UnionFind\UnionFind\UnionFind\input.txt");
            List<string> list = new List<string>();
            int capacity = int.Parse(file[0]);
            for (int i = 1; i < capacity + 1; i++)
            {
                list.Add(file[i]);
            }

            UnionFindPractice<string> Union = new UnionFindPractice<string>(list);

            for (int i = capacity + 2; i < file.Length; i++)
            {
                string[] ids = file[i].Split(',');
                Union.Union(ids[0].Trim(), ids[1].Trim());
            }


            //Questions:
            //Is phoebe friends with rachel?
            Console.WriteLine($"Is phoebe friends with rachel: {Union.IsConnected("Phoebe", "Rachael")}");
            // Is jim friends with creed?
            Console.WriteLine($"Is Jim friends with Creed: {Union.IsConnected("Jim", "Creed")}");
            // Is michael friends with pam?
            Console.WriteLine($"Is Michael friends with Pam: {Union.IsConnected("Michael", "Pam")}");
            // is chandler friends with creed?
            Console.WriteLine($"Is Chandler friends with Creed: {Union.IsConnected("Chandler", "Creed")}");
            // how many friend groups are there?
            Console.WriteLine($"How many friend groups are there? : {Union.NumSets()}");
            // followup, list each person in the friend groups
            //Console.WriteLine(Union.GetAllGroupsWithMembers());
            //who is in the largest friend group
            //who is in the smallest friend group
        }
    }
}
