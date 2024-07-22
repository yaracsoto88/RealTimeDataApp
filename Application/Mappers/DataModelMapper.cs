using RealTimeDataApp.Application.DTOs;
using RealTimeDataApp.Domain.Entities;

namespace RealTimeDataApp.Application.Mappers
{
    public class DataModelMapper
    {
        public DataModelDto DataModelToDto(DataModel dataModel)
        {
            return new DataModelDto
            {
                Id = dataModel.Id,
                Title = dataModel.TimeStamp.ToString(),
                Body = dataModel.Value
            };
        }

        public static DataModel DtoToModel(DataModelDto dataModelDto)
        {
            return new DataModel
            {
                Id = dataModelDto.Id,
                TimeStamp = DateTime.UtcNow,
                Value = dataModelDto.Body
            };
        }

        public static void UpdateModel(DataModel existingModel, DataModelDto dto)
        {
            existingModel.TimeStamp = DateTime.UtcNow;
            existingModel.Value = dto.Body;
        }
    }
}