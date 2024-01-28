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
                Id = entity.CarId,
                Model = entity.Model,
                Producer = entity.Producer,
                EngineCapacity = entity.EngineCapacity,
                EnginePower = entity.EnginePower,
                EngineType = entity.EngineType,
                LicensePlateNumber = entity.LicensePlateNumber,
                Created = entity.Created,
                Priority = (Priority)entity.Priority,
                Owner = new CarContactDetails()
                {
                    FirstName = entity.ContactDetails?.FirstName,
                    LastName = entity.ContactDetails?.LastName,
                    PhoneNumber = entity.ContactDetails?.PhoneNumber,
                    Email = entity.ContactDetails?.Email
                }
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
                ContactDetails = new CarContactDetailsEntity()
                {
                    FirstName = model.Owner.FirstName,
                    LastName = model.Owner.LastName,
                    PhoneNumber = model.Owner.PhoneNumber,
                    Email = model.Owner.Email,
                }
            };
        }
    }
}
