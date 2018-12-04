using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

    }
}