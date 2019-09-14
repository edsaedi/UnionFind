using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnionFind
{
    public class UnionFindPractice<T>
    {
        Dictionary<T, int> map;
        int[] id;

        public UnionFindPractice(List<T> list)
        {
            id = new int[list.Count];
            map = new Dictionary<T, int>();
            for (int i = 0; i < list.Count; i++)
            {
                map.Add(list[i], i);
                id[i] = i;
            }
        }


        public T ReverseMap(int num)
        {
            foreach (var (name, mapVal) in map)
            {
                if (mapVal == num)
                {
                    return name;
                }
            }

            return default(T);
        }

        public int NumSets() => id.Distinct().Count();

        public List<T> GetAllMembersInGroup(int groupId)
        {
            List<T> groupMembers = new List<T>();

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == groupId)
                {
                    groupMembers.Add(ReverseMap(i));
                }
            }

            return groupMembers;
        }


        public Dictionary<int, List<T>> GetAllGroupsWithMembers()
        {
            // for all the disjoint sets, get all their members and return it
            var temp = id.Distinct();
            Dictionary<int, List<T>> keyValuePairs = new Dictionary<int, List<T>>();
            foreach (var item in temp)
            {
                keyValuePairs.Add(item, GetAllMembersInGroup(item));
            }
            return keyValuePairs;
        }


        public bool IsConnected(T p, T q) => Find(p) == (Find(q));

        public void Union(T p, T q)
        {
            if (IsConnected(p, q))
            {
                return;
            }

            var pId = Find(p);
            var qId = Find(q);

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == (pId))
                {
                    id[i] = qId;
                }
            }
        }

        public int Find(T item)
        {
            var innerKey = map[item];
            return id[innerKey];
        }

    }
}
