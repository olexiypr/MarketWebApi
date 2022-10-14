using System;
using System.Collections.Generic;
using System.Reflection;
using Business.Common.Mapping;
using Business.Repository;
using Data.Data;
using Data.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddMediatR(typeof(IMapWith<>).Assembly);
        services.AddMediatR(typeof(TradeMarketDbContext).Assembly);
        services.AddTransient<IGenericRepository<Product>, GenericRepository<Product>>();
        services.AddTransient<IGenericRepository<Customer>, GenericRepository<Customer>>();
        services.AddTransient<IGenericRepository<Receipt>, GenericRepository<Receipt>>();
        services.AddTransient<IGenericRepository<ProductCategory>, GenericRepository<ProductCategory>>();
        return services;
    }
}