using Data.Entities;

namespace Laboratorium3.Models
{
    public static class CarMapper
    {
        public static Car FromEntity(CarEntity entity)
        {
            return new Car()
            {
                Model = entity.Model,
                Producer = entity.Producer,
                EngineCapacity = entity.EngineCapacity,
                EnginePower = entity.EnginePower,
                EngineType = entity.EngineType,
                LicensePlateNumber = entity.LicensePlateNumber,
                Created = entity.Created,
                Priority = (Priority)entity.Priority,
            };
        }

        public static CarEntity ToEntity(Car model)
        {
            return new CarEntity()
            {
                CarId = model.Id,
                Model = model.Model,
                Producer = model.Producer,
                EngineCapacity = model.EngineCapacity,
                EnginePower = model.EnginePower,
                EngineType = model.EngineType,
                LicensePlateNumber = model.LicensePlateNumber,
                Created = model.Created,
                Priority = (int)model.Priority,
            };
        }
    }
}
