using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealTimeDataApp.Application.Services;
using RealTimeDataApp.Domain.Interfaces;
using RealTimeDataApp.Infrastructure.Data;
using RealTimeDataApp.Infrastructure.Repositories;
using RealTimeDataApp.BusinessLogic.Interfaces;
using RealTimeDataApp.BusinessLogic.Services;
using Microsoft.Extensions.Configuration;
using RealTimeDataApp.Infrastructure.BackgroundServices;
using RealTimeDataApp.Application.Mappers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Configuración del AppDbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(context.Configuration.GetConnectionString("DefaultConnection")));

        // Capa de Infraestructura
        services.AddScoped<IDataModelRepository, DataModelRepository>();
        services.AddHttpClient<ApiService>();

        // Capa de Lógica de Negocio
        services.AddScoped<IDataModelBusinessLogic, DataModelBusinessLogic>();

        // Capa de Aplicación
        services.AddScoped<IDataModelService, DataModelService>();

        services.AddScoped<DataModelMapper>();
        services.AddScoped<InMemoryDataStore>();

        // Servicios Hospedados
        services.AddHostedService<DataHostedService>();

    })
    .Build();

await host.RunAsync();
