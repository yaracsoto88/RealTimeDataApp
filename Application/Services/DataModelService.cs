using RealTimeDataApp.Application.DTOs;
using RealTimeDataApp.Application.Mappers;
using RealTimeDataApp.Domain.Entities;
using RealTimeDataApp.Domain.Interfaces;

namespace RealTimeDataApp.Application.Services
{
    public class DataModelService : IDataModelService
    {
        private readonly IDataModelRepository _dataModelRepository;
        private readonly DataModelMapper _mapper;

        public DataModelService(IDataModelRepository dataModelRepository, DataModelMapper mapper)
        {
            _dataModelRepository = dataModelRepository;
            _mapper = mapper;
        }

        public async Task AddDataModelAsync(DataModelDto dataModelDto)
        {
            var dataModel = DataModelMapper.DtoToModel(dataModelDto);
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
    }
}
