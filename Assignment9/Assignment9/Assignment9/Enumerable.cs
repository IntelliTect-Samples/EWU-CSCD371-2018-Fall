using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment9
{
    public static class Enumerable
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> collection)
        {
            List<T> items = collection.ToList();
            Random random = new Random();
            while (items.Any())
            {
                int randomIndex = random.Next(items.Count);
                T item = items[randomIndex];
                items.RemoveAt(randomIndex);
                yield return item;
            }
        }
    }
}