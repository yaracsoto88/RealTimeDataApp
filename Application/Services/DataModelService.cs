using RealTimeDataApp.Application.DTOs;
using RealTimeDataApp.BusinessLogic.Interfaces;
using RealTimeDataApp.Domain.Interfaces;

namespace RealTimeDataApp.Application.Services
{
    public class DataModelService : IDataModelService
    {
        private readonly IDataModelRepository _dataModelRepository;
        private readonly IDataModelBusinessLogic _dataModelBusinessLogic;
        
        public DataModelService(IDataModelRepository dataModelRepository, IDataModelBusinessLogic dataModelBusinessLogic)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelBusinessLogic = dataModelBusinessLogic;
        }

        public async Task AddDataModelAsync(DataModelDto dataModelDto){
            //hacer algo
        }
        public async Task<IEnumerable<DataModelDto>> GetDataModelsAsync(){
            //hacer algo
            await Task.CompletedTask;
            return null;
        }
    }
}