using System;
using System.Collections.Generic;
using System.Linq;


namespace HW9
{
    //Requirement #4 - •	Randomize: Write an IEnumerable<T> extension method on a class called Enumerable<T> that returns an IEnumerable<T>of the original items in random order. 
    //To test execute the method using LINQ and verify the order is not the same for at least 3 invocations.
    public static class Enumerable
    {
        public static IEnumerable<T> RandomizeCollection<T>(this IEnumerable<T> RandomSet)
        {
            if (RandomSet == null) throw new ArgumentNullException(nameof(RandomSet));

            List<T> items = new List<T>();
            List<T> randomList = new List<T>();

            foreach (T item in RandomSet)
            {
                items.Add(item);
            }

            Random r = new Random();

            int randomIndex = 0;

            while (items.Count > 0)
            {
                randomIndex = r.Next(0, items.Count); //Choose a random object in the list
                randomList.Add(items[randomIndex]); //add it to the new, random list
                items.RemoveAt(randomIndex); //remove to avoid duplicates
            }
            
            return randomList; //return the new random list
        }  
    }
}
