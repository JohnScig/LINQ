using LINQ.Data;
using LINQ.Models;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class Filtering
    {

        /// <summary>
        /// Finds all elements of an array less than 5.
        /// </summary>
        /// <returns>Collection with elements less than 5.</returns>
        public static IEnumerable<int> Where01()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return numbers.Where(n=>n<5);
        }

        /// <summary>
        /// Find all products that are out of stock.
        /// </summary>
        /// <returns>Collection with products that are out of stock.</returns>
        public static IEnumerable<Product> Where02()
        {
            List<Product> products = DataLoader.GetProductList();

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return products.Where(p=>p.UnitsInStock == 0);
        }

        /// <summary>
        /// Finds all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        /// <returns>Collection with products that are in stock and cost more than 3.00 per unit.</returns>
        public static IEnumerable<Product> Where03()
        {
            List<Product> products = DataLoader.GetProductList();

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return products.Where(p=> p.UnitsInStock>0 && p.UnitPrice > 3);
        }

        /// <summary>
        /// Finds all customers from Washington (WA) region and number of their orders.
        /// </summary>
        /// <returns>Collection with customer IDs and their order count.</returns>
        public static IEnumerable<CustomerDto> WhereDrillDown()
        {
            List<Customer> customers = DataLoader.GetCustomerList();
            return customers.Where(c => c.Region == "WA").Select(c => new CustomerDto() { CustomerId = c.CustomerID, OrderCount = c.Orders.Count() });
        }

        /// <summary>
        /// Finds all digits whose name is shorter than their value (index).
        /// </summary>
        /// <returns>Collection with digits whose name is shorter than their value (index).</returns>
        public static IEnumerable<string> WhereIndexed()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return digits.Where((d,i)=>d.Length<i);
        }

    }
}