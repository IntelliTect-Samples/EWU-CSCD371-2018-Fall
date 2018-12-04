using System;
using System.Collections.Generic;
using System.Linq;
namespace Assignment9
{
    
    public class PatentDataAnalyzer
    {
        public static List<string> InventorNames(string specifiedCountry)
        {
            return (from inventor in PatentData.Inventors
                where inventor.Country == specifiedCountry
                select inventor.Name).ToList();
        }

        public static IEnumerable<string> InventorLastNames()
        {
            return from inventor in PatentData.Inventors
                let lastName = inventor.Name.Split(' ').Last()
                orderby inventor.Id descending
                select lastName;
        }

        public static string LocationsWithInventors()
        {
            return string.Join(", ",
                (from inventor in PatentData.Inventors 
                    select $"{inventor.State}-{inventor.Country}").Distinct());
        }
        
        /*EXTRA CREDIT*/
        
        public static List<Inventor> GetInventorsWithMulitplePatents(int n)
        {
            return (from inventor in PatentData.Inventors
                let count = PatentData.Patents.Count(patent => patent.InventorIds.Contains(inventor.Id))
                where count == n
                select inventor).ToList();
        }

        //this is a changed version of a traditional dynamic programming fibonacci algorithm that uses arrays
        public static IEnumerable<long> NthFibonacciNumbers(int n)
        {
            if(n < 1) throw new ArgumentException($"{nameof(n)} cannot be less than 1");
            long prevFibMinusOne = 1;
            long prevFibMinusTwo = 0;
            long numberOfFibCalculated = 2;

            if (1 % n == 0) yield return 1;
            while (true)
            {
                var currentFib = prevFibMinusOne + prevFibMinusTwo;
                if(numberOfFibCalculated % n == 0)
                    yield return currentFib;
                prevFibMinusTwo = prevFibMinusOne;
                prevFibMinusOne = currentFib;
                numberOfFibCalculated++;
            }
        }
    }
}