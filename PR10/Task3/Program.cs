using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task3
{

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(string name, double price, string category)
        {
            Name = name;
            Price = (decimal)price;
            Category = category;
        }

        public override string ToString() => $"{Name,-15} | {Price,8:C} | {Category}";
    }

    public class ProductFileReader
    {
        public List<Product> ReadProducts()
        {
            List<Product> products = new List<Product>();

            if (!File.Exists("file.data"))
            {
                Console.WriteLine("Создаем тестовый file.data...");
                CreateTestFile();
            }

            using (BinaryReader reader = new BinaryReader(new FileStream("file.data", FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    string name = reader.ReadString();
                    double price = reader.ReadDouble();
                    string category = reader.ReadString();
                    products.Add(new Product(name, price, category));
                }
            }

            Console.WriteLine($"Прочитано {products.Count} товаров");
            return products;
        }

        private void CreateTestFile()
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream("file.data", FileMode.Create)))
            {
                writer.Write("Ноутбук");
                writer.Write(85000.0);
                writer.Write("Электроника");

                writer.Write("Телефон");
                writer.Write(45000.0);
                writer.Write("Смартфоны");

                writer.Write("Книга");
                writer.Write(500.0);
                writer.Write("Книги");
            }
        }
    }

    public class ProductProcessor
    {
        public void SortByPrice(List<Product> products, bool ascending = true)
        {
            var sorted = ascending ?
                products.OrderBy(p => p.Price).ToList() :
                products.OrderByDescending(p => p.Price).ToList();

            Console.WriteLine($"\nСортировка по цене ({(ascending ? "↑" : "↓")}):");
            foreach (var p in sorted) Console.WriteLine(p);
        }
    }

    class Program
    {
        static void Main()
        {
            ProductFileReader reader = new ProductFileReader();
            var products = reader.ReadProducts();

            ProductProcessor processor = new ProductProcessor();
            processor.SortByPrice(products, true);
            processor.SortByPrice(products, false);
        }
    }
}