using RealTimeDataApp.Domain.Entities;

namespace RealTimeDataApp.Domain.Interfaces
{
    public interface IDataModelRepository
    {
        Task AddDataModelAsync(DataModel dataModel);
        Task<IEnumerable<DataModel>> GetAllDataModelsAsync();
    }
}