using System;
using System.Collections.Generic;
using System.Threading;
using FromCRUDtoCQRS.CRUD;

namespace FromCRUDtoCQRS.CQRS
{
    public class CreateProductCommandHandler
    {
        public static Dictionary<Guid, CreateProduct> EventRepo = new Dictionary<Guid, CreateProduct>();
        public void Publish(CreateProduct createProduct)
        {
            EventRepo.Add(createProduct.CommandId, createProduct);
            ThreadPool.QueueUserWorkItem(x => PublishToProjection(createProduct));
        }

        public void PublishToProjection(CreateProduct createProduct)
        {
            var product = new Product();
            product.Id = createProduct.ProductId;
            product.Name = createProduct.Name;
            ProductProjections.ProductRepo.Add(product.Id, product);
        }

        public void PublishWithProjectionDelay(CreateProduct createProduct)
        {
            EventRepo.Add(createProduct.CommandId, createProduct);
            ThreadPool.QueueUserWorkItem(x => PublishToProjectionWithDelay(createProduct));
        }

        public void PublishToProjectionWithDelay(CreateProduct createProduct)
        {
            Thread.Sleep(10000);
            var product = new Product();
            product.Id = createProduct.ProductId;
            product.Name = createProduct.Name;
            ProductProjections.ProductRepo.Add(product.Id, product);
        }
    }
}