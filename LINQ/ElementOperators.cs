using LINQ.Data;
using LINQ.Models;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class ElementOperators
    {
        /// <summary>
        /// Returns first product from Confections category.
        /// </summary>
        /// <returns>First product from Confections category.</returns>
        public static Product First01()
        {
            List<Product> products = DataLoader.GetProductList();

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!            
            
            return products.First(p=>p.Category == "Confections");
        }

        /// <summary>
        /// Returns first element in the array that starts with 'o'.
        /// </summary>
        /// <returns>First element in the array that starts with 'o'.</returns>
        public static string First02()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!            

            return strings.First(s => s[0] == 'o');
        }

        /// <summary>
        /// Tries to return first or default element from an array.
        /// </summary>
        /// <returns>First or default element from an array.</returns>
        public static int FirstOrDefault01()
        {
            int[] numbers = { };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!            
            
            return numbers.FirstOrDefault();
        }

        /// <summary>
        /// Tries to return first or default product with ID 789.
        /// </summary>
        /// <returns>First or default product with ID 789.</returns>
        public static Product FirstOrDefault02()
        {
            List<Product> products = DataLoader.GetProductList();

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!            
            
            return products.FirstOrDefault(p=>p.ProductID==789);
        }

        /// <summary>
        /// Returns second number greater than 5 from an array.
        /// </summary>
        /// <returns>Second number greater than 5 from an array.</returns>
        public static int ElementAt()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!            
            
            return numbers.Where(n=>n>5).ElementAt(1);
        }
    }
}