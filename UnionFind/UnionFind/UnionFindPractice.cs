using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnionFind
{
    public class UnionFindPractice<T> where T : IEquatable<T>
    {
        Dictionary<T, int> map;
        T[] id;

        public UnionFindPractice(List<T> list, int capacity)
        {
            id = new T[capacity];
            map = new Dictionary<T, int>(capacity);
            for (int i = 0; i < list.Count; i++)
            {
                map.Add(list[i], i);
            }
        }

        public int NumSets() => id.Distinct().Count();

        public IEnumerable<T> TSets()
        {
            return id.Distinct().ToList();
        }

        public bool IsConnected(T p, T q) => Find(p).Equals(Find(q));

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
                if (id[i].Equals(pId))
                {
                    id[i] = qId;
                }
            }
        }

        public T Find(T item)
        {
            return id[map[item]];
        }

    }
}
