using System.Collections.Generic;


namespace SpeakingCQRS.Features.Product
{
    public class PriceListProjection
    {
        public PriceListModel Get()
        {
            var productList = new CQRS.ProductProjections().GetAllProducts();
            return new PriceListModel() {Products = productList};
        }
    }

    public class PriceListModel
    {
        public List<CQRS.Product> Products { get; set; } 
    }
}