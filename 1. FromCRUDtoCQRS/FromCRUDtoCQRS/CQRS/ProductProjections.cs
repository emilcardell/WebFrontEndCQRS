using System.Collections.Generic;
using FromCRUDtoCQRS.CRUD;

namespace FromCRUDtoCQRS.CQRS
{
    public class ProductProjections
    {
        public static Dictionary<int, Product> ProductRepo = new Dictionary<int, Product>();
        public Product GetProduct(int id)
        {
            return ProductRepo.ContainsKey(id) ? ProductRepo[id] : null;
        }
    }
}