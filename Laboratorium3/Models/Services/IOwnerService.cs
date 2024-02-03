using Data.Entities;

namespace Laboratorium3.Models.Services
{
    public interface IOwnerService
    {
        int Add(Owner owner);
        void Delete(int id);
        void Update(Owner owner);
        List<Owner> FindAll();
        Owner? FindById(int id);
        List<CarEntity> FindAllCarsForOwner(int id);
    }
}
