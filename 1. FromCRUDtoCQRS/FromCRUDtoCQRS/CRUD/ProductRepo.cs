using System;
using System.Collections.Generic;
using System.Threading;

namespace FromCRUDtoCQRS.CRUD
{
    public class ProductRepo
    {
        public static Dictionary<int, Product> Products = new Dictionary<int, Product>();  
        public Product CreateProduct(Product product)
        {
            product.Id = Products.Count + 1;
            Products.Add(product.Id, product);
            return product;
        }

        public Product GetProduct(int id)
        {
            return Products[id];
        }

        public Product CreateProductWithDelay(Product product)
        {
            Thread.Sleep(10000);
            product.Id = Products.Count + 1;
            Products.Add(product.Id, product);
            return product;
        }

        public Product GetProductWithDelay(int id)
        {
            Thread.Sleep(10000);
            return Products[id];
        }
    }
}