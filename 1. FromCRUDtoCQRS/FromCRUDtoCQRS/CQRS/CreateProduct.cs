

using System;

namespace FromCRUDtoCQRS.CQRS
{
    
    public class CreateProduct{
        public Guid CommandId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}