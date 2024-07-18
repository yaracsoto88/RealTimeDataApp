using RealTimeDataApp.Domain.Entities;

namespace RealTimeDataApp.BusinessLogic.Interfaces
{
    public interface IDataModelBusinessLogic
    {
        Task ValidateAndProcessData(DataModel dataModel);
    }
}