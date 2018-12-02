using System;
using System.Linq;
using System.Collections.Generic;
using EssentialCSharpChapter15Listing15_10;

namespace Assingment9
{
    public static class PatentDataAnalyzer
    {
        public static List<string> InventorNames(string countryName)
        {
            if (countryName is null)
            {
                throw new ArgumentNullException("Argument name cannot be null");
            }
            else
            {
                List<string> listOfInventorNames = new List<string>(from inventors
                                                                    in PatentData.Inventors
                                                                    where inventors.Country.Equals(countryName)
                                                                    //orderby inventors ascending
                                                                    select inventors.Name);
                return listOfInventorNames;
                //Or
                /*
                 *                 List<string> listOfInventorNames = (from inventors
                                                    in PatentData.Inventors
                                                    where inventors.Country.Equals(countryName)
                                                    //orderby inventors ascending
                                                    select inventors.Name).ToList();
                                    return new List<string> ();
                 */
            }
        }

        public static List<string> InventorLastNames()
        {
            List<string> listOfLastNames = new List<string>(from inventors
                                                    in PatentData.Inventors
                                                            orderby inventors.Id descending
                                                            select inventors.Name.Split(" ").Last());
            return listOfLastNames;

        }

        public static string LocationsWithInventors()
        {
            //string empty = "";
            string uniqueLocationAll = string.Join(",", from inventors
                                                        in PatentData.Inventors
                                                        select (inventors.Name + "-" + inventors.Country).Distinct());
            return uniqueLocationAll;
        }

        public static int NumOfOccurance(long id)
        {
            //long.TryParse(id, out long result);
            return (from patients
            in PatentData.Patents
                    where patients.InventorIds.Contains(id)
                    select patients.Title).Count();
        }

        public static List<Inventor> GetInventorsWithMulitplePatents(int numOfPatients)
        {
            List<Inventor> nHavingPatientInventors = new List<Inventor>(from inventor
                                                                        in PatentData.Inventors
                                                                        where (NumOfOccurance(inventor.Id) == numOfPatients)
                                                                        select inventor);
            return nHavingPatientInventors;
            //return new List<Inventor>();
        }

        public static IEnumerable<int> NthFibonacciNumbers(int nth)//still wrapping head around yield statement
        {
            if (nth < 0 || nth == 0)//cannot do a 0th or -#th fibonacci value
            {
                throw new ArgumentOutOfRangeException();
            }

            int termPrev = 1;//first term
            int termTwoPrev = 1;//second term

            //cannot do if/else if/else as that wouldn't allow the yield return to return all proper values.
            if (1 % nth == 0)
            {
                yield return termPrev;
            }
            if (2 % nth == 0)
            {
                yield return termTwoPrev;
            }

            int currentNth = 3;//inilize 3rd term, and go forward
            while (true)//since there is a yield return in the while loop, it will continue on "forever" but testing we can get the nth subset of it.
            {
                int currentTerm = termPrev + termTwoPrev;
                if (currentNth % nth == 0)
                {
                    yield return currentTerm;
                }
                termTwoPrev = termPrev;
                termPrev = currentTerm;
                currentNth++;
            }
            
        }
    }
}
