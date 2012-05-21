using System;
using FubuMVC.Core.Diagnostics;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.Routes;

namespace SpeakingCQRS
{
    public class CommandHandlerUrlPolicy : IUrlPolicy
    {
        public bool Matches(ActionCall call, IConfigurationObserver log)
        {
            return call.HandlerType.Name.EndsWith("CommandHandler", StringComparison.InvariantCultureIgnoreCase);
        }

        public IRouteDefinition Build(ActionCall call)
        {
            var routeDefinition = call.ToRouteDefinition();
            routeDefinition.Append(call.HandlerType.Namespace.Substring(call.HandlerType.Namespace.LastIndexOf('.') + 1));
            routeDefinition.Append(call.HandlerType.Name.Substring(0, call.HandlerType.Name.LastIndexOf("CommandHandler")));
            return routeDefinition;
        }
    }
}