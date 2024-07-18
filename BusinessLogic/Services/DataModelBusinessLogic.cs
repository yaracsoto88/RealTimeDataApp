using RealTimeDataApp.BusinessLogic.Interfaces;
using RealTimeDataApp.Domain.Entities;

namespace RealTimeDataApp.BusinessLogic.Services
{
    public class DataModelBusinessLogic : IDataModelBusinessLogic
    {
        public Task ValidateAndProcessData(DataModel dataModel)
        {
            if (dataModel.TimeStamp > DateTime.UtcNow)
            {
                throw new Exception("Timestamp cannot be in the future.");
            }

            if (string.IsNullOrEmpty(dataModel.Value))
            {
                throw new Exception("Value cannot be empty.");
            }

            return Task.CompletedTask;
        }
    }
}