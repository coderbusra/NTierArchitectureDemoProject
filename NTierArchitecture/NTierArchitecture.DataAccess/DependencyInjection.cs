﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Repositories;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        services.AddIdentityCore<AppUser>(cfr =>
        {
            cfr.Password.RequireNonAlphanumeric = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IUnitOfWork>(sv => sv.GetRequiredService<ApplicationDbContext>());

        //services.AddScoped<ICategoryRepository, CategoryRepository>();
        //services.AddScoped<IProductRepository, ProductRepository>();
        //services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        services.Scan(selector => selector
        .FromAssemblies(
            typeof(DependencyInjection).Assembly)
        .AddClasses(publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsMatchingInterface()
        .WithScopedLifetime());


        return services;
    }
}
