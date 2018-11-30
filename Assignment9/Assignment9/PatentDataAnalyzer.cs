using System.Collections.Generic;
using System.Linq;

namespace Assignment9
{
    public static class PatentDataAnalyzer
    {
        public static List<Inventor> InventorNames(string country)
        {
            IEnumerable<Inventor> inventors = PatentData.Inventors;

            IEnumerable<Inventor> subList = inventors.Where(
                inventor => inventor.Country.Equals(country));

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
                .Distinct().ToArray());

            return result;
        }
    }
}