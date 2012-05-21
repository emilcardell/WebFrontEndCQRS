using System;
using System.Collections.Generic;
using System.Threading;


namespace SpeakingCQRS.CQRS
{
    public class CreateProductCommandHandler
    {
        public static Dictionary<Guid, CreateProductCommand> EventRepo = new Dictionary<Guid, CreateProductCommand>();
        public void Publish(CreateProductCommand createProductCommand)
        {
            EventRepo.Add(createProductCommand.CommandId, createProductCommand);
            ThreadPool.QueueUserWorkItem(x => PublishToProjection(createProductCommand));
        }

        public void PublishToProjection(CreateProductCommand createProductCommand)
        {
            Thread.Sleep(500);
            var product = new Product();
            product.Id = createProductCommand.ProductId;
            product.Name = createProductCommand.Name;
            ProductProjections.ProductRepo.Add(product.Id, product);
        }
    }
}