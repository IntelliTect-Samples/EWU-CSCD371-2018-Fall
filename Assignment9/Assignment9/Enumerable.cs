using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment9
{
    public static class Enumerable
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> collection)
        {
            Random rand = new Random();

            IEnumerable<T> randomizedCollection = collection.OrderBy(
                item => rand.Next());
            
            return randomizedCollection;
        }
    }
}