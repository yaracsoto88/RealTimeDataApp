using RealTimeDataApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealTimeDataApp.Domain.Interfaces
{
    public interface IDataModelRepository
    {
        Task<DataModel?> GetDataModelByIdAsync(int id);
        Task AddDataModelAsync(DataModel dataModel);
        Task UpdateDataModelAsync(DataModel dataModel);
        Task<IEnumerable<DataModel>> GetAllDataModelsAsync();
    }
}
