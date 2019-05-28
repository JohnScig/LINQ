using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class Conversion
    {
        /// <summary>
        /// Returns sequence ordered from highest number to lowest as an array.
        /// </summary>
        /// <returns>Array with numbers ordered in descending order.</returns>
        public static double[] ToArray()
        {
            List<double> doubles = new List<double> { 1.7, 2.3, 1.9, 4.1, 2.9 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!            

            return doubles.OrderByDescending(x=>x).ToArray();
        }

        /// <summary>
        /// Returns sequence ordered alphabetically as a list.
        /// </summary>
        /// <returns>List with words ordered alphabetically.</returns>
        public static List<string> ToList()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!
            
            return words.OrderBy(w=>w).ToList();
        }

        /// <summary>
        /// Returns dictionary of test results.
        /// </summary>
        /// <returns>Dictionary with test results where student name is the key and their score is the value.</returns>
        public static Dictionary<string, int> ToDictionary()
        {
            var scoreRecords = new[] { new {Name = "Alice", Score = 50},
                                       new {Name = "Bob"  , Score = 40},
                                       new {Name = "Cathy", Score = 45} };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!
            
            return scoreRecords.ToDictionary(x=>x.Name, x=>x.Score);
        }

        /// <summary>
        /// Returns only elements of type double from array.
        /// </summary>
        /// <returns>Collection with only elements of type double.</returns>
        public static IEnumerable<double> OfType()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!
            
            return numbers.OfType<double>();
        }
    }
}