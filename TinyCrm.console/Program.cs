using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace TinyCrm.console
{
    class Program

    {
        public static List<Product> OrderProducts(List<Product> products) // epilogh 10 products apo ta diathesima sto katastima
        {
            var selectProducts = new List<Product>();
            Random rnd = new Random();
            for (var i = 0; i < 10; i++)
            {
                int n = rnd.Next(products.Count);
                Product pro = products.ElementAt(n);
                selectProducts.Add(pro);
            }
            return selectProducts;
        }
        static void Main(string[] args)
        {
            string path = "C:/Users/Spyros/Desktop/products.txt";

            // anoigma arxeiou gia na diabasoume grammi grammi
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            var lineCount = File.ReadAllLines(path).Length;

            List<Product> products = new List<Product>();  // lista me ta antikeimena typou Product
            List<string> product_ids = new List<string>(); // lista me ta ids ton proionton gia check

            foreach (string line in readText)
            {
                string[] columns = line.Split(';');
                var check = product_ids.Any(product_ids => product_ids.Contains(columns[0]));

                if (check)            // ean yparxei hdh to id sth lista enhmeronei
                {
                    Console.WriteLine("Yparxei hdh product me to id");
                }
                else
                {
                    var prod = new Product(columns[0], columns[1], columns[2]); // allios dhmioyrgia antikeimenou
                    products.Add(prod);
                    product_ids.Add(columns[0]);
                }

            }

            var C1 = new Customer("Georgios", "Georgiou", "000111222");    // dhmioyrgia customers
            var C2 = new Customer("Basilis", "Basiliou", "000111222");

            var Order1 = new Order();
            var selected_prod1 = OrderProducts(products);    // pernoyme mia lista me 10 random products
            Order1.products = selected_prod1;               // anathetoume th lista me ta products sthn order1( 1os pelatis)

            var Order2 = new Order();
            var selected_prod2 = OrderProducts(products);      // pernoyme mia lista me 10 random products
            Order2.products = selected_prod2;                 // anathetoume th lista me ta products sthn order2( 2os pelatis)


            C1.AddOrder(Order1);                 // syndeoyme to 1o pelati me thn order1
            C2.AddOrder(Order2);                  // syndeoyme to 2o pelati me thn order2


            decimal total = Order1.products.Sum(item => item.Price);  // pernoyme to kostos ths agoras toy 1ou pelati
            decimal total2 = Order2.products.Sum(item => item.Price);  // pernoyme to kostos ths agoras toy 2ou pelati

            // the most valuable customer is...
            if (total > total2)
            {
                Console.WriteLine($"The most valuable customer is Georgios Georgiou, kostos {total} eyro");
            }
            else if (total < total2)
            {
                Console.WriteLine($"The most valuable customer is Basilis Basiliou, kostos {total2} eyro");
            }
            else Console.WriteLine("To kostos agoras einai to idio");


        }
    }
}
