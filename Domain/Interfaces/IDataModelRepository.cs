using RealTimeDataApp.Domain.Entities;

namespace RealTimeDataApp.Domain.Interfaces
{
    public interface IDataModelRepository
    {
        Task<DataModel?> GetDataModelByIdAsync(int id);
        Task AddDataModelAsync(DataModel dataModel);
        Task UpdateDataModelAsync(DataModel dataModel);
    }
}
