using Data.Entities;
using Laboratorium3.Models;

namespace Laboratorium3.Mappers
{
    public static class CarMapper
    {
        public static Car FromEntity(CarEntity entity)
        {
            return new Car()
            {
                Id = entity.Id,
                Model = entity.Model,
                Producer = entity.Producer,
                EngineCapacity = entity.EngineCapacity,
                EnginePower = entity.EnginePower,
                EngineType = entity.EngineType,
                LicensePlateNumber = entity.LicensePlateNumber,
                Created = entity.Created,
                State = (State)entity.State,
                OwnerId = entity.OwnerId,
            };
        }

        public static CarEntity ToEntity(Car model)
        {
            return new CarEntity()
            {
                Id = model.Id,
                Model = model.Model,
                Producer = model.Producer,
                EngineCapacity = model.EngineCapacity,
                EnginePower = model.EnginePower,
                EngineType = model.EngineType,
                LicensePlateNumber = model.LicensePlateNumber,
                Created = model.Created,
                State = (int)model.State,
                OwnerId = model.OwnerId,
            };
        }
    }
}
