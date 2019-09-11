using System;
using System.Linq;
using Autofac;
using SpecFlow.Autofac;
using SpecFlowOcarambaBoilerplate.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowOcarambaBoilerplate
{
    public class AutofacSetup
    {
        [ScenarioDependencies]
        internal static ContainerBuilder CreateContainerBuilder()
        {
            // create container with the runtime dependencies
            var builder = new ContainerBuilder();

            builder.RegisterType<IntegrationTestSetup>();
            builder.RegisterTypes(typeof(AutofacSetup).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
            
            // ***************************************
            // Register your types here for injection
            // ***************************************

            builder.RegisterType<Google>();

            return builder;
        }
    }
}
