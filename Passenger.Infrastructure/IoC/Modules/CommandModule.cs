using Autofac;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Handlers.Users;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>)).
                InstancePerLifetimeScope();

            // the snippet above allows to do the snippet below for every type of ICommandHandler in the assembly automagically 

            //builder.RegisterType<CreateUserHandler>()
            //    .As<ICommandHandler>()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}
