using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLINQExtensionMethods
{
    public static class MyExtensionMethods
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
                yield return selector(item);
        }

        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keyselector)
        {
            return new Grouped<TSource, TKey, TSource>(source, keyselector);
        }

        internal class Grouped<TSource, TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>
        {
            IEnumerable<TSource> source;
            Func<TSource, TKey> keyselector;
            public Grouped(IEnumerable<TSource> source, Func<TSource, TKey> keyselector)
            {
                this.source = source;
                this.keyselector = keyselector;
            }

            public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public static List<TSource> MyToList<TSource>(this IEnumerable<TSource> source)
        {
            return new List<TSource>(source);
        }

        public static Dictionary<TKey, TElement> MyToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keyselector, Func<TSource, TElement> elementselector)
        {
            Dictionary<TKey, TElement> d = new Dictionary<TKey, TElement>();
            foreach(TSource element in source)
            {
                d.Add(keyselector(element), elementselector(element));
            }
            return d;
        }

    }
}
