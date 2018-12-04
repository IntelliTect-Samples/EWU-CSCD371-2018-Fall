using System;
using System.Collections.Generic;
using System.Linq;

namespace HW9
{
    public static class PatentDataAnalyzer 
    {
        //Requirement #1 -InventorNames: Return a list of the inventor names from the specified country where the country is specified as a parameter.
        public static List<string> InventorNames(string countryOfInventor)
        {
            if (countryOfInventor == null) throw new ArgumentNullException(nameof(countryOfInventor));  //Based off recommendations from Kevin's lecture

            var queryInvetersLastName = from invetor in PatentData.Inventors
                                        where invetor.Country == countryOfInventor
                                        select invetor.Name;

            return queryInvetersLastName.ToList();
        }

        //Requiement #2 - InventorLastNames: Returns the only the last name of each of the inventor sorted in reverse order by inventor Id.
        public static IEnumerable<string> InventorLastNames()
        {
            //Using query syntax 
            IEnumerable<string> inventorLastNames =
                      from inventorFullName in PatentData.Inventors
                      let lastName = inventorFullName.Name.Split().Last()
                      orderby inventorFullName.Id descending
                      select lastName;

            return inventorLastNames;
        }

        //Requirement #3 - LocationsWithInventors: Returns a single comma separated list of all the unique "-" strings for each inventor. 
        //   The result should be a scalar value of type string, not a collection (other than the fact that a string is a collection of characters).
        public static string LocationsWithInventors()
        {
            return string.Join(",",
                (from inventor in PatentData.Inventors
                 select $"{inventor.State}-{inventor.Country}")
                 .Distinct()).ToString();
        }

        //Extra credit requirment #2 - NthFibonacciNumbers: Write a method that returns a collection of every nth fibonacci number.
        public static IEnumerable<int> NthFibonacciNumbers(int nthFibNumToSkip)
        {
            int maxFibonacciNumbers = 40;

            if (nthFibNumToSkip <= 0 || nthFibNumToSkip > maxFibonacciNumbers)
                throw new ArgumentOutOfRangeException("The value of " + maxFibonacciNumbers + " is out of range");
            
            List<int> FibonacciSeries = new List<int>();

            int a = 0, b = 1, c = 0;

            FibonacciSeries.Add(a);
            FibonacciSeries.Add(b);

            for (int i = 2; i < maxFibonacciNumbers; i++)
            {
                c = a + b;
                FibonacciSeries.Add(c);
                a = b;
                b = c;
            }
            List<int> skipNthFibNum = new List<int>();            

            int nthFibSkipNumberCounter = nthFibNumToSkip;

            for (int i = nthFibNumToSkip; i < maxFibonacciNumbers; )
            {
                skipNthFibNum.Add(FibonacciSeries.First());
                FibonacciSeries.RemoveRange(0, nthFibNumToSkip);
                
                i+= nthFibNumToSkip;                
            }

            return skipNthFibNum;
        }
    }  //end PatentDataAnalyzer class
}
