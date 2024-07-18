using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                TimeStamp = dataModel.TimeStamp,
                Value = dataModel.Value
            };
        }

        public DataModel DtoToModel(DataModelDto dataModelDto)
        {
            return new DataModel
            {
                Id = dataModelDto.Id,
                TimeStamp = dataModelDto.TimeStamp,
                Value = dataModelDto.Value
            };
        }

    }
}