using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class Grouping
    {
        /// <summary>
        /// Returns dictionary with numbers grouped by their remainder when divided by 5.
        /// </summary>
        /// <returns>Dictionary where key is remainder and value is list of numbers with that remainder when divided by 5.</returns>
        public static Dictionary<int, int[]> GroupBy01()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!
            // Use ToDictionary(x => {key}, x => {values})
            // Use group.Key as Dictionary key and group as Dictionary values
            // If compiler complains about IGrouping<int, int>, use ToArray() method
            return numbers.GroupBy(p => p % 5).ToDictionary(x => x.Key, x => x.ToArray());

        }

        /// <summary>
        /// Returns dictionary with words grouped by their first letter.
        /// </summary>
        /// <returns>Dictionary where key is first letter of the word and value is word itself.</returns>
        public static Dictionary<char, string[]> GroupBy02()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!
            // Use ToDictionary(x => {key}, x => {values})
            // Use group.Key as Dictionary key and group as Dictionary values
            // If compiler complains about IGrouping<char, string>, use ToArray() method

            return words.GroupBy(w => w[0]).ToDictionary(x => x.Key, x => x.ToArray());
        }
    }
}