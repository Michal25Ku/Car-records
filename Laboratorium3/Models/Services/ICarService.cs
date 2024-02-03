using Data.Entities;

namespace Laboratorium3.Models.Services
{
    public interface ICarService
    {
        int Add(Car car);
        void Delete(int id);
        void Update(Car car);
        List<Car> FindAll();
        Car? FindById(int id);
        List<OwnerEntity> FindAllOwnersForVievModel();
    }
}
