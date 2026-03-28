using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name,-20}  {Price,10:F0} р  {Category}";
        }
    }

    public class ProductFileWriter
    {
        public void WriteProducts(List<Product> products)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream("file.data", FileMode.Create)))
            {
                foreach (Product product in products)
                {
                    writer.Write(product.Name ?? "");
                    writer.Write((double)product.Price);
                    writer.Write(product.Category ?? "");
                }
            }
            Console.WriteLine($"Записано {products.Count} товаров в file.data");
        }
    }

    class Program
    {
        static void Main()
        {
            List<Product> products = new List<Product>
        {
            new Product("Ноутбук Dell", 85000m, "Электроника"),
            new Product("iPhone 15", 120000m, "Смартфоны"),
            new Product("Книга C#", 1500m, "Литература"),
            new Product("Кофе", 800m, "Продукты"),
            new Product("Монитор 27\"", 25000m, "Электроника")
        };

            Console.WriteLine("Товары для записи:");
            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }

            ProductFileWriter writer = new ProductFileWriter();
            writer.WriteProducts(products);
        }
    }
}