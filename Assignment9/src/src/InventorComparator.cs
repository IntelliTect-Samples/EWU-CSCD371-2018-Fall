using EssentialCSharpChapter15Listing15_10;
using System;
using System.Collections.Generic;
using System.Text;


//Comparer class created to confirm when testing that returned list of inventors is equivalent to the original.
namespace src
{
    public class InventorComparator : Comparer<Inventor>
    {
        public override int Compare(Inventor firstInventor, Inventor secondInventor)
        {
            int stateInt = CompareString(firstInventor.State, secondInventor.State);
            if (stateInt == 0)
            {
                int nameInt = CompareString(firstInventor.Name, secondInventor.Name);
                if (firstInventor.Name.Equals(secondInventor.Name))
                {
                    int longInt = CompareLong(firstInventor.Id, secondInventor.Id);
                    if (longInt == 0)
                    {
                        int countryInt = CompareString(firstInventor.Country, secondInventor.Country);
                        if (countryInt == 0)
                        {
                            int cityInt = CompareString(firstInventor.City, secondInventor.City);
                            if (cityInt == 0)
                            {
                                return 0;
                            }
                            return cityInt;
                        }
                        return countryInt;
                    }
                    return longInt;
                }
                return nameInt;
            }
            return stateInt;
        }

        /// <summary>
        ///split up into two method to compare the data type for easier testing as there are only two datatypes
        ///when testing for equality.
        /// </summary>

        public int CompareString(string stringOne, string stringTwo)
        {
            return stringOne.CompareTo(stringTwo);
        }

        public int CompareLong(long longOne, long longTwo)
        {
            return longOne.CompareTo(longTwo);
        }
    }
}
