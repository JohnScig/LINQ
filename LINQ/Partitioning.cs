using LINQ.Data;
using LINQ.Models;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class Partitioning
    {

        /// <summary>
        /// Returns only first 3 elements of the array.
        /// </summary>
        /// <returns>Collection with first 3 elements of the array.</returns>
        public static IEnumerable<int> Take()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return numbers.Take(3);
        }

        /// <summary>
        /// Returns first 3 orders from customers in Washington (WA) region.
        /// </summary>
        /// <returns>Collection with first 3 orders from customers in Washington (WA) region.</returns>
        public static IEnumerable<CustomerOrderDto> TakeNested()
        {
            List<Customer> customers = DataLoader.GetCustomerList();

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return (from c in customers
                    where c.Region == "WA"
                    from o in c.Orders
                    select new CustomerOrderDto()
                    {
                        CustomerId = c.CustomerID,
                        OrderId = o.OrderID
                    }).Take(3);
        }

        /// <summary>
        /// Returns all but the first 4 elements of the array.
        /// </summary>
        /// <returns>Collection with all but the first 4 elements of the array.</returns>
        public static IEnumerable<int> Skip()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return numbers.Skip(4);;
        }

        /// <summary>
        /// Returns all but first 2 orders from customers in Washington (WA) region.
        /// </summary>
        /// <returns>Collection with all but first 2 orders from customers in Washington (WA) region.</returns>
        public static IEnumerable<CustomerOrderDto> SkipNested()
        {
            List<Customer> customers = DataLoader.GetCustomerList();

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return (from c in customers
                    where c.Region == "WA"
                    from o in c.Orders
                    select new CustomerOrderDto()
                    {
                        CustomerId = c.CustomerID,
                        OrderId = o.OrderID
                    }).Skip(2);
        }

        /// <summary>
        /// Returns elements starting from the beginning of the array until a number is hit that is not less than 6.
        /// </summary>
        /// <returns>Collection with elements starting from the beginning of the array until a number is hit that is not less than 6.</returns>
        public static IEnumerable<int> TakeWhile()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return numbers.TakeWhile(n=>n<6);
        }

        /// <summary>
        /// Returns elements starting from the beginning of the array until a number is hit that is less than its position in the array.
        /// </summary>
        /// <returns>Collection with elements starting from the beginning of the array until a number is hit that is less than its position in the array.</returns>
        public static IEnumerable<int> TakeWhileIndexed()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return numbers.TakeWhile((n,i)=>n>=i);
        }

        /// <summary>
        /// Returns elements of the array starting from the first element divisible by 3.
        /// </summary>
        /// <returns>Collection with elements of the array starting from the first element divisible by 3.</returns>
        public static IEnumerable<int> SkipWhile()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return numbers.SkipWhile(n=>n%3!=0);
        }

        /// <summary>
        /// Returns elements of the array starting from the first element less than its position.
        /// </summary>
        /// <returns>Collection with elements of the array starting from the first element less than its position.</returns>
        public static IEnumerable<int> SkipWhileIndexed()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // !!! INSERT YOUR LINQ  MAGIC HERE !!!

            return numbers.SkipWhile((n,i)=>n>i);
        }
    }
}