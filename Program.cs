using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealTimeDataApp.Application.Services;
using RealTimeDataApp.Domain.Interfaces;
using RealTimeDataApp.Infrastructure.Data;
using RealTimeDataApp.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using RealTimeDataApp.Infrastructure.BackgroundServices;
using RealTimeDataApp.Application.Mappers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(context.Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IDataModelRepository, DataModelRepository>();
        services.AddHttpClient<ApiService>();
        services.AddScoped<IDataModelService, DataModelService>();
        services.AddScoped<DataModelMapper>();
        services.AddHostedService<DataHostedService>();

    })
    .Build();

await host.RunAsync();
