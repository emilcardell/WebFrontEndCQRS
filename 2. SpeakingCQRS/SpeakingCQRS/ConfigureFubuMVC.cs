using System;
using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Razor;
using SpeakingCQRS.Features.Product;

namespace SpeakingCQRS
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            Actions
                .IncludeTypesNamed(x => x.EndsWith("Projection"))
                .IncludeTypesNamed(x => x.EndsWith("CommandHandler"));

            var httpVerbs = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { "GET", "POST", "DELETE", "PUT" };
            httpVerbs.Each(verb => Routes.ConstrainToHttpMethod(action => action.Method.Name.Equals(verb, StringComparison.InvariantCultureIgnoreCase), verb));
            httpVerbs.Each(verb => Routes.IgnoreMethodsNamed(verb));

            Routes
                .IgnoreMethodSuffix("Html")
                .RootAtAssemblyNamespace()
                .UrlPolicy<ProjectionUrlPolicy>()
                .UrlPolicy<CommandHandlerUrlPolicy>()
                .HomeIs<CreateFormProjection>(x => x.Get());

            this.UseRazor();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();
        }
    }
}