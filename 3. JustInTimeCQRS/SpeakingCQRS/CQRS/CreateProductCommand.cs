using System;

namespace SpeakingCQRS.CQRS
{
    
    public class CreateProductCommand
    {
        public Guid CommandId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}