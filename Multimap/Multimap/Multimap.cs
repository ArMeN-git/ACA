using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimap
{
    class Multimap<T, V>
    {
        private Dictionary<T, List<V>> dictMult = new Dictionary<T, List<V>>();

        public List<V> this[T key] {
            get
            {
                List<V> list;
                if(this.dictMult.TryGetValue(key, out list))
                {
                    return list;
                }
                else
                {
                    return new List<V>();
                }
            }
        }

        public ICollection<T> Keys => this.dictMult.Keys;

        public ICollection<List<V>> Values => this.dictMult.Values;
 
        public int Count => this.dictMult.Count();

        public void Add(T key, V value)
        {
            List<V> list;
            if (this.dictMult.TryGetValue(key, out list))
            {
                list.Add(value);
            }
            else
            {
                list = new List<V>();
                list.Add(value);
                this.dictMult[key] = list;
            }
        }

        public bool ContainsKey(T key)
        {
            return dictMult.ContainsKey(key);
        }

        public bool TryGetValue(T key, out List<V> value)
        {
            return this.dictMult.TryGetValue(key, out value);
        }
    }
}
