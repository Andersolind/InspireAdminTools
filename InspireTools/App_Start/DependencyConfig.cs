using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Util;
using Autofac.Integration;
using InspireTools.Controllers;

namespace InspireTools.App_Start {
    public static class DependencyConfig {
        public static void RegisterComponent(ContainerBuilder builder) {
         

            builder.RegisterType<InspireController>()
                   .As<InspireController>()
                   .SingleInstance();
        }
        public static IContainer Build() {
            var builder = new ContainerBuilder();
            RegisterComponent(builder);

            //register validation module
          //  builder.RegisterModule<ValidationModule>();
         

            return builder.Build();
        }
        public static IContainer Register() {


            // Build the container.
            IContainer container = Build();

            // Create the depenedency resolver.
           

            return container;

        }



    }
}