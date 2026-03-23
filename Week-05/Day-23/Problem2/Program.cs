namespace ConsoleApp8
{


    class Program
    {
        
      
        static void Main()
        {
            Product obj = new Product();
            var products = obj.GetProducts();

            //1.Write a LINQ query to search and display all products with category “FMCG”.
            var q1 = products.Where(p => p.ProCategory == "FMCG").Select(p =>p.ProName).ToList();
            /*
            foreach (var prod in q1)
            {
                Console.WriteLine($"{prod}");
            }
            */

            //2. Write a LINQ query to search and display all products with category “Grain”.
            var q2 = products.Where(p => p.ProCategory == "Grain").Select(p => p.ProName).ToList();

            //3. Write a LINQ query to sort products in ascending order by product code.
            var q3 = products.OrderBy(p => p.ProCode).Select(p => p.ProName).ToList();

            //4. Write a LINQ query to sort products in ascending order by product Category.
            var q4 = products.OrderBy(p => p.ProCategory).Select(p => p.ProName).ToList();

            //5. Write a LINQ query to sort products in ascending order by product Mrp.
            var q5 = products.OrderBy(p => p.ProMrp).Select(p => p.ProName).ToList();

            //6. Write a LINQ query to sort products in descending order by product Mrp.
            var q6 = products.OrderByDescending(p => p.ProMrp).Select(p => p.ProName).ToList();

            //7. Write a LINQ query to display products group by product Category.
            var q7 = products.GroupBy(p => p.ProCategory);

            /*
            foreach (var group in q7)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine("--" + item.ProName);
                }
            } */


            //8. Write a LINQ query to display products group by product Mrp.
            var q8 = products.GroupBy(p => p.ProMrp);
            /*
            foreach (var group in q8)
            {
                Console.WriteLine($"Price: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine("--" + item.ProName);
                }
            }
            */

            //9. Write a LINQ query to display product detail with highest price in FMCG category.
            var q9 = products.Where(p => p.ProCategory == "FMCG").OrderByDescending(p => p.ProMrp).First();

            //10. Write a LINQ query to display count of total products.
            int q10 = products.Count();

            //11. Write a LINQ query to display count of total products with category FMCG.
            int q11 = products.Where(p => p.ProCategory == "FMCG").Count();

            //12.Write a LINQ query to display Max price.
            double q12 = products.Max(p => p.ProMrp);

            //13.Write a LINQ query to display Min price.
            double q13 = products.Min(p => p.ProMrp);

            //14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
            bool q14 = products.All(p => p.ProMrp <= 30);

            //15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.
            bool q15 = products.Any(p => p.ProMrp <= 30);

            Console.WriteLine($"Count : {q15}");


            //foreach (var prod in q6)
            //{
            //    Console.WriteLine($"{prod.ProCode}\t{prod.ProName}\t{prod.ProMrp}");
            //}




        }
    }

}
