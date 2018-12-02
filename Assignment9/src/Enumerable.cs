using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace src
{
    public static class Enumerable
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> other)
        {
            List<T> list = other.ToList();
            Random randomIndexer = new Random();
            int size, index;
            T item;
            while (list.Any())//better to use any than list.count() == 0
            {
                size = list.Count();
                index = randomIndexer.Next(size); //index between 0, and size
                item = list.ElementAt(index);
                list.Remove(item);
                yield return item;
            }
        }
    }
}
