using Data.Data;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<TradeMarketDbContext>();
        services.AddScoped<ICustomerDbContext>(provider =>  provider.GetService<TradeMarketDbContext>());
        services.AddScoped<IPersonDbContext>(provider =>  provider.GetService<TradeMarketDbContext>());
        services.AddScoped<IProductCategoryDbContext>(provider =>  provider.GetService<TradeMarketDbContext>());
        services.AddScoped<IProductDbContext>(provider =>  provider.GetService<TradeMarketDbContext>());
        services.AddScoped<IReceiptDetailsDbContext>(provider =>  provider.GetService<TradeMarketDbContext>());
        services.AddScoped<IReceiptDbContext>(provider =>  provider.GetService<TradeMarketDbContext>());
        return services;
    }
}