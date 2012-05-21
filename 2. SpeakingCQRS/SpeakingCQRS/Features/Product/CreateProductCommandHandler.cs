using System;
using FubuMVC.Core.Ajax;
using SpeakingCQRS.CQRS;

namespace SpeakingCQRS.Features.Product
{
    public class CreateProductCommandHandler
    {
        public AjaxContinuation Post(CreateProductCommand createProductCommand)
        {
            var commandHandler = new CQRS.CreateProductCommandHandler();
            createProductCommand.CommandId = Guid.NewGuid();
            createProductCommand.ProductId = new Random().Next(1000);

            commandHandler.Publish(createProductCommand);

            var continuation = AjaxContinuation.Successful();
            continuation.Message = "/Product/Details/?Id=" + createProductCommand.ProductId;
            return continuation;
        }
    }
}