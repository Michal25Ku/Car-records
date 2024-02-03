using Data;
using Data.Entities;
using Laboratorium3.Mappers;

namespace Laboratorium3.Models.Services
{
    public class EfOwnerService : IOwnerService
    {
        private readonly CarDbContext _context;

        public EfOwnerService(CarDbContext context)
        {
            _context = context;
        }

        public int Add(Owner owner)
        {
            var e = _context.Owners.Add(OwnerMapper.ToEntity(owner));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            var entity = _context.Owners.Find(id);
            if (entity != null)
            {
                _context.Owners.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<Owner> FindAll()
        {
            return _context.Owners.Select(e => OwnerMapper.FromEntity(e)).ToList();
        }

        public List<CarEntity> FindAllCarsForOwner(int id)
        {
            return _context.Cars.Where(c => c.OwnerId == id).ToList();
        }

        public Owner? FindById(int id)
        {
            return OwnerMapper.FromEntity(_context.Owners.Find(id));
        }

        public void Update(Owner owner)
        {
            _context.Owners.Update(OwnerMapper.ToEntity(owner));
            _context.SaveChanges();
        }
    }
}
