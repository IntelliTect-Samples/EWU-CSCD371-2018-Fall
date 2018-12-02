using System;
using System.Linq;
using System.Collections.Generic;
using EssentialCSharpChapter15Listing15_10;

namespace src
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
                return new List<string>();
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

        public static void Randomize()
        {

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

        public static void NthFibonacciNumbers()
        {

        }

    }
}
