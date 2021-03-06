﻿using Autofac;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {


        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

       
        }
    }


    //services.AddScoped<IUserService, UserService>();
    //        services.AddScoped<IUserRepository, InMemoryUserRepository>();
    //        services.AddScoped<IDriverService, DriverService>();
    //        services.AddScoped<IDriverRepository, InMemoryDriverRepository>();
}
