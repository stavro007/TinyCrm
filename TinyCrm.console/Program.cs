using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace TinyCrm.console
{
    class Program

     
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Spyros/Desktop/products.txt";
          
            // anoigma arxeiou gia na diabasoume grammi grammi
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            var lineCount = File.ReadAllLines(path).Length;
            
            List<Product> products = new List<Product>();  // lista me ta antikeimena typou Product
            List<String> product_ids = new List<String>(); // lista me ta ids ton proionton gia check

            foreach (string line in readText)
            {
                string[] columns = line.Split(';');
                if (product_ids.Contains(columns[0])){      // ean den einai unique to id
                    Console.WriteLine("Yparxei hdh product me to id");
                }
                else
                {
                    var prod = new Product(columns[0], columns[1], columns[2]); // dhmioyrgia antikeimenou
                    products.Add(prod);
                }
                
            }
            Console.WriteLine("To katasthma mas diathetei ta eksis proionta\n");
            foreach (Product aProduct in products)
            {
                Console.WriteLine($"|| Productid:{aProduct.ProductId} " +
                                  $"\n|| Name:{aProduct.Name} " +
                                  $"\n|| Description:{aProduct.Description} " +
                                  $"\n|| PRICE:{aProduct.Price}\n");
            }
            
            
            


        }
    }
}
