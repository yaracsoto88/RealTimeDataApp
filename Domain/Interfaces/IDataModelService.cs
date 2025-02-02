using RealTimeDataApp.Application.DTOs;
using RealTimeDataApp.Domain.Entities;

namespace RealTimeDataApp.Domain.Interfaces
{
    public interface IDataModelService
    {
        Task AddDataModelAsync(DataModelDto dataModelDto);
        Task <DataModel?> GetDataModelByIdAsync(int id);
        Task UpdateDataModelAsync(DataModel dataModel);
    }
}