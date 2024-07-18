using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RealTimeDataApp.Application.Services;

namespace RealTimeDataApp.Infrastructure.BackgroundServices
{
    public class DataHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<DataHostedService> _logger;
        private readonly ApiService _apiService;
        
        private Timer? _timer = null;
        public DataHostedService(ILogger<DataHostedService> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
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
            // lógica de la tarea en segundo plano
            //guardo los datos de la api en data
            var data = await _apiService.GetDataAsync("https://jsonplaceholder.typicode.com/posts");
            _logger.LogInformation("Data: {data}", data);
            //y ahora quiero que data este almacenada en memoria

        }

        public void Dispose()
        {
            //descargar recursos
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
