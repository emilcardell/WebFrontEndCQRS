using System;
using System.Threading;
using FubuMVC.Core.Ajax;
using SpeakingCQRS.CQRS;

namespace SpeakingCQRS.Features.Product
{
    public class UpdatePriceCommandHandler
    {
        public AjaxContinuation Post(UpdatePriceCommand updatePriceCommand)
        {
            Thread.Sleep(5000);
            var commandHandler = new CQRS.UpdatePriceCommandHandler();
            updatePriceCommand.CommandId = Guid.NewGuid();
            
            commandHandler.Publish(updatePriceCommand);

            var continuation = AjaxContinuation.Successful();
            return continuation;
        }
    }
}