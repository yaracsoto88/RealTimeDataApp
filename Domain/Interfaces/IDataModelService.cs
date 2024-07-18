using RealTimeDataApp.Application.DTOs;

namespace RealTimeDataApp.Domain.Interfaces
{
    public interface IDataModelService
    {
        Task AddDataModelAsync(DataModelDto dataModelDto);
        Task<IEnumerable<DataModelDto>> GetDataModelsAsync();
    }
}