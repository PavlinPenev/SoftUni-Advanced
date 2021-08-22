using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            List<Store> stores = new List<Store>();
            string storeInfo;
            while ((storeInfo = Console.ReadLine()) != "Revision")
            {
                string[] info = storeInfo.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string store = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);
                Store currentStore = new Store(store, new List<Product>());
                Product currentProduct = new Product(product, price);
                
                if (!stores.Any(s => s.Name == store))
                {
                    stores.Add(currentStore);
                }
                int idx = stores.FindIndex(s => s.Name == store);
                stores[idx].Product.Add(currentProduct);
            }

            Console.WriteLine(string.Join(Environment.NewLine, stores.OrderBy(s=> s.Name)));
        }
    }

    class Store
    {
        public Store(string name, List<Product> product)
        {
            Name = name;
            Product = product;
        }
        public string Name { get; set; }
        public List<Product> Product { get; set; }
        public override string ToString()
        {
            return $"{Name}->{Environment.NewLine}{string.Join(Environment.NewLine, Product)}" ;
        }
    }

    class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}";
        }
    }
}
