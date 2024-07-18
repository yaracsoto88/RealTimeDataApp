using RealTimeDataApp.Application.DTOs;
using RealTimeDataApp.Application.Mappers;
using RealTimeDataApp.BusinessLogic.Interfaces;
using RealTimeDataApp.Domain.Interfaces;

namespace RealTimeDataApp.Application.Services
{
    public class DataModelService : IDataModelService
    {
        private readonly IDataModelRepository _dataModelRepository;
        private readonly IDataModelBusinessLogic _dataModelBusinessLogic;
        private readonly DataModelMapper _mapper;
        
        public DataModelService(IDataModelRepository dataModelRepository, IDataModelBusinessLogic dataModelBusinessLogic, DataModelMapper mapper)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelBusinessLogic = dataModelBusinessLogic;
            _mapper = mapper;
        }

        public async Task AddDataModelAsync(DataModelDto dataModelDto){
            var dataModel = _mapper.DtoToModel(dataModelDto);
            await _dataModelRepository.AddDataModelAsync(dataModel);

        }
        public async Task<IEnumerable<DataModelDto>> GetDataModelsAsync(){
            //hacer algo
            await Task.CompletedTask;
            return null;
        }
    }
}