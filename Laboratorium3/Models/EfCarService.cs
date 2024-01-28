using Data;
using Laboratorium3.Mappers;

namespace Laboratorium3.Models
{
    public class EfCarService : ICarService
    {
        private readonly CarDbContext _context;

        public EfCarService(CarDbContext context)
        {
            _context = context;
        }

        public int Add(Car car)
        {
            var e = _context.Cars.Add(CarMapper.ToEntity(car));
            _context.SaveChanges();
            return e.Entity.CarId;
        }

        public void Delete(int id)
        {
            var entity = _context.Cars.Find(id);
            if(entity != null)
            {
                _context.Cars.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<Car> FindAll()
        {
            return _context.Cars.Select(e => CarMapper.FromEntity(e)).ToList();
        }

        public Car? FindById(int id)
        {
            return CarMapper.FromEntity(_context.Cars.Find(id));
        }

        public void Update(Car car)
        {
            _context.Cars.Update(CarMapper.ToEntity(car));
            _context.SaveChanges();
        }
    }
}
