using SpeakingCQRS.CQRS;

namespace SpeakingCQRS.Features.Product
{
    public class CreateFormProjection
    {
        public CreateProductCommand Get()
        {
            return new CreateProductCommand();
        }
    }

    
}