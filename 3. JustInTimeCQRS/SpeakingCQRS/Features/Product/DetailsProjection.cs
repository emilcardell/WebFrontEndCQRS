
using FubuMVC.Core;

namespace SpeakingCQRS.Features.Product
{
    public class DetailsProjection
    {
        public CQRS.Product Get(DetailsInputModel inputModel)
        {
            return new CQRS.ProductProjections().GetProduct(inputModel.Id);
        }
    }

    public class DetailsInputModel
    {
        public int Id { get; set; }
    }
}