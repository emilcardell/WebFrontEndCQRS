using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakingCQRS.CQRS
{
    public class UpdatePriceCommand
    {
        public Guid CommandId { get; set; }
        public int ProductId { get; set; }
        public int NewPrice { get; set; }
    }
}