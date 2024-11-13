using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Product(string productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public override string ToString()
        {
            return $"Product ID: {ProductId}, Name: {ProductName}, Price: {Price:C}";
        }
    }

    class SortingClass
    {
        static void Main()
        {
            List<Product> products = new List<Product>();

            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter details for Product {i + 1}:");

                Console.Write("Product ID: ");
                string productId = Console.ReadLine();

                Console.Write("Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                products.Add(new Product(productId, productName, price));
                Console.WriteLine();
            }

            
            var sortedProducts = products.OrderBy(p => p.Price).ToList();

            
            Console.WriteLine("Sorted Products by Price: ");
            foreach (var product in sortedProducts)
            {
                Console.WriteLine(product);
            }
            Console.Read();
        }
    }
   
}
