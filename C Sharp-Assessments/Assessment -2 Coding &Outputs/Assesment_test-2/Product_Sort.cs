using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2
{
    class Product
    {
        int Productid { get; set; }
        string ProductName { get; set; }
        double Product_price { get; set; }
        public Product (int productid,string productName, double product_price)
        {
            Productid = productid;
            ProductName = productName;
            Product_price = product_price;


        }
    public override string ToString()
        {
            return " Productid  :" + Productid + " ProductName  :" + ProductName + "   Product_price" + Product_price;
        }
        public static int Compare(Product p1,Product p2)
        {
            return p1.Product_price.CompareTo(p2.Product_price);
        }

    }
    public class Items
    {
        public static void main()
        {
            Product[] prod = new Product[10];
            for(int i=0;i< prod.Length; i++)
            {
                Console.WriteLine("Enter the product details");

                Console.WriteLine("Enter the product id");
                int productid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the product name");
                string productName = Console.ReadLine();
                Console.WriteLine("Enter the product price");
                Double product_price = Convert.ToDouble(Console.ReadLine());

                prod[i] = new Product(productid, productName, product_price);

                Console.ReadLine();
            }
            Array.Sort(prod, Product.Compare);
            Console.WriteLine("The sorted products are");
                foreach(var prodcts in prod)
            {
                Console.WriteLine(prodcts);
            }

            
        }
    }
}
