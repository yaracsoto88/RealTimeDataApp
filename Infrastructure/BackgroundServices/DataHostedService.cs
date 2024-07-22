using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RealTimeDataApp.Application.Mappers;
using RealTimeDataApp.Application.Services;
using RealTimeDataApp.Application.DTOs;
using RealTimeDataApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RealTimeDataApp.Infrastructure.BackgroundServices
{
    public class DataHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<DataHostedService> _logger;
        private readonly ApiService _apiService;
        private readonly DataModelMapper _mapper;
        private readonly IDataModelService _dataModelService;

        private Timer? _timer = null;
        public DataHostedService(ILogger<DataHostedService> logger, ApiService apiService, DataModelMapper mapper, IDataModelService dataModelService)
        {
            _logger = logger;
            _apiService = apiService;
            _mapper = mapper;
            _dataModelService = dataModelService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Iniciar el servicio
            _logger.LogInformation("DataHostedService is starting.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            _logger.LogInformation("Data Hosted Service is working.");

            try
            {
                var data = await _apiService.GetDataAsync("https://jsonplaceholder.typicode.com/posts");
                _logger.LogInformation("Data: {data}", data);

                var dataModels = JsonConvert.DeserializeObject<List<DataModelDto>>(data);

                foreach (var dataModelDto in dataModels)
                {
                    var dataModel = _mapper.DtoToModel(dataModelDto);
                    var existingDataModel = await _dataModelService.GetDataModelByIdAsync(dataModel.Id);

                    if (existingDataModel != null)
                    {
                        // Actualizar entidad existente
                        _mapper.UpdateModel(existingDataModel, dataModelDto);
                        await _dataModelService.UpdateDataModelAsync(existingDataModel);
                    }
                    else
                    {
                        // Añadir nueva entidad
                        await _dataModelService.AddDataModelAsync(dataModelDto);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calling the API.");
            }
        }

        public void Dispose()
        {
            // Descargar recursos
            _timer?.Dispose();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Detener el servicio
            _logger.LogInformation("DataHostedService is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
