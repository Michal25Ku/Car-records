using Data.Entities;
using Laboratorium3.Models;

namespace Laboratorium3.Mappers
{
    public class OwnerMapper
    {
        public static Owner FromEntity(OwnerEntity entity)
        {
            return new Owner()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Pesel = entity.Pesel,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                City = entity.Address.City,
                Street = entity.Address.Street,
                PostalCode = entity.Address.PostalCode,
                Region = entity.Address.Region,
            };
        }

        public static OwnerEntity ToEntity(Owner model)
        {
            return new OwnerEntity()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Pesel = model.Pesel,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = new Address()
                {
                    City = model.City,
                    Street = model.Street,
                    PostalCode = model.PostalCode,
                    Region = model.Region,
                }
            };
        }
    }
}
