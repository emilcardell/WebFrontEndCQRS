using System.Collections.Generic;
using System.Linq;

namespace SpeakingCQRS.CQRS
{
    public class ProductProjections
    {
        public static Dictionary<int, Product> ProductRepo = new Dictionary<int, Product>();
        public Product GetProduct(int id)
        {
            return ProductRepo.ContainsKey(id) ? ProductRepo[id] : null;
        }

        public List<Product> GetAllProducts()
        {
            return ProductRepo.Select(x => x.Value).ToList();
        }
    }
}