using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment9
{
    
    /*
     *
     *
     * InventorNames: Return a list of the inventor names from the specified country where the country is specified as a parameter.
I    * InventorLastNames: Returns the only the last name of each of the inventor sorted in reverse order by inventor Id.
     * LocationsWithInventors: Returns a single comma separated list of all the unique "-" (where you list the unique state and country combinations with a dash between the state and the country) strings for each inventor. The result should be a scalar value of type string, not a collection (other than the fact that a string is a collection of characters). E.g. NC-USA, PA-USA, NY, etc....
     * Randomize: Write an IEnumerable<T> extension method on a class called Enumerable<T> that returns an IEnumerable<T> of the original items in random order. To test execute the method using LINQ and verify the order is not the same for at least 3 invocations.
     */
    public class PatentDataAnalyzer
    {
        public static IEnumerable<string> GetInventorNames(string speifiedCountry)
        {
            return null;
        }
    }
}