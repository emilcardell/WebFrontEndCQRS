using FubuMVC.Core.Ajax;

namespace SpeakingCQRS.Features.Product
{

    public class ExistsProjection
    {
        public AjaxContinuation Get(ExistsInputModel inputModel)
        {
            var productFound = new CQRS.ProductProjections().GetProduct(inputModel.Id);
            if (productFound == null)
                return new AjaxContinuation() {Success = false};

            return AjaxContinuation.Successful();
        }
    }

    public class ExistsInputModel
    {
        public int Id { get; set; }
    }
}