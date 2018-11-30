using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment9
{
    public static class PatentDataAnalyzer
    {
        public static List<string> InventorNames(string country)
        {
            IEnumerable<Inventor> inventors = PatentData.Inventors;

            IEnumerable<string> subList = inventors.Where(
                inventor => inventor.Country.Equals(country))
                    .Select(
                        inventor => inventor.Name);

            return subList.ToList();
        }

        public static List<string> InventorLastNames()
        {
            IEnumerable<Inventor> inventors = PatentData.Inventors;

            IEnumerable<Inventor> orderedList = inventors.OrderByDescending(
                inventor => inventor.Id);

            IEnumerable<string> result = orderedList.Select(
                inventor =>
                {
                    string[] splitName = inventor.Name.Split();

                    return splitName[splitName.Length - 1];
                });

            return result.ToList();
        }

        public static string LocationsWithInventors()
        {
            string result = string.Join(",",
                (
                    from inventor in PatentData.Inventors
                    select $"{inventor.State}-{inventor.Country}"
                )
                .Distinct());

            return result;
        }

        public static IEnumerable<int> NthFibonacciNumbers(int n)
        {
            if (n == 0)
            {
                throw new ArgumentException("n must be greater than or equal to 1");
            }

            if (n <= 2)
            {
                for (int i = n-1; i < 2; i = i+n)
                {
                    yield return 1;
                }
            }

            int lowNum = 1; // n - 2
            int highNum = 1; // n - 1

            int res = 0;

            bool firstIteration = true;

            while (true)
            {
                for(int i = 0; i < n; i++)
                {
                    if (firstIteration)
                    {
                        if (n != 2)
                        {
                            i = i + 2;
                        }
                        firstIteration = false;
                    }
                    res = highNum + lowNum;
                
                    lowNum = highNum;
                    highNum = res;
                }

                yield return res;
            }
        }
    }
}