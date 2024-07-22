using RealTimeDataApp.Application.DTOs;
using RealTimeDataApp.Application.Mappers;
using RealTimeDataApp.BusinessLogic.Interfaces;
using RealTimeDataApp.Domain.Entities;
using RealTimeDataApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task AddDataModelAsync(DataModelDto dataModelDto)
        {
            var dataModel = _mapper.DtoToModel(dataModelDto);
            await _dataModelRepository.AddDataModelAsync(dataModel);
        }

        public async Task<DataModel?> GetDataModelByIdAsync(int id)
        {
            return await _dataModelRepository.GetDataModelByIdAsync(id);
        }

        public async Task UpdateDataModelAsync(DataModel dataModel)
        {
            await _dataModelRepository.UpdateDataModelAsync(dataModel);
        }

        public async Task<IEnumerable<DataModelDto>> GetDataModelsAsync()
        {
            // hacer algo
            await Task.CompletedTask;
            return null;
        }
    }
}
