
using System;
using System.Collections.Generic;
using System.Threading;

namespace SpeakingCQRS.CQRS
{
    public class UpdatePriceCommandHandler
    {
        public static Dictionary<Guid, UpdatePriceCommand> EventRepo = new Dictionary<Guid, UpdatePriceCommand>();
        public void Publish(UpdatePriceCommand updatePriceCommand)
        {
            EventRepo.Add(updatePriceCommand.CommandId, updatePriceCommand);
            ThreadPool.QueueUserWorkItem(x => PublishToProjection(updatePriceCommand));
        }

        public void PublishToProjection(UpdatePriceCommand updatePriceCommand)
        {
            Thread.Sleep(3000);
            if(!ProductProjections.ProductRepo.ContainsKey(updatePriceCommand.ProductId))
                return;

            var product = ProductProjections.ProductRepo[updatePriceCommand.ProductId];
            product.Price = updatePriceCommand.NewPrice;
            ProductProjections.ProductRepo[updatePriceCommand.ProductId] = product;
        }
    }
}