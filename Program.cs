using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;


namespace Crud_OperationsNC4
{
    class Program
    {
        static void Main(string[] args)
        {


            string defaultkey = File.ReadAllText("appsettings.Debug.json");
            JObject jObject = JObject.Parse(defaultkey);
            JToken token = jObject["DefaultConnection"];
            string connectionString = token.ToString();
            ProductRepo.connString = connectionString;
          

           
            
            
            
            
            
            
            
            //Create Products
            ProductRepo repo = new ProductRepo();


            Console.WriteLine("Creating Product.....");
            var newProduct = new Product { Name = "Jays Product", Price = 19.99M, CategoryID = 2, OnSale = 0 };
            repo.CreateProduct(newProduct);
            Console.WriteLine("Product Created!");







            // Update Product
            Console.WriteLine("Updating Product........");
            var newInfo = new Product { StockLevel = 31, ProductID = 940 };
            repo.UpdateProduct(newInfo);
            Console.WriteLine("Product Updated!");


            //Delete Product
            Console.WriteLine("Deleting Samsung Washer");
            repo.DeleteProduct(941, "Matts Product");
            Console.WriteLine("Deleting Macbook Pro");
            repo.DeleteProduct(940);
            Console.WriteLine("Deleting SamsungTV");
            repo.DeleteProduct("Jays Product");

            Console.WriteLine("Products Deleted!");





            //Read Products

            List<Product> products = repo.GetProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID}  {prod.Name} ----------- ${prod.Price}------You have {prod.StockLevel}");
            }


        }
    }
}
