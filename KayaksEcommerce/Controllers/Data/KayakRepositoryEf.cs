using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace KayaksEcommerce.Infrastructure.Data
{
    public class KayakRepositoryEf : IKayakRepository
    {
        private readonly ApplicationContext _context;
        public KayakRepositoryEf(ApplicationContext context)
        {

            _context = context;

        }

        public Kayak Add(Kayak kayak)
        {
            _context.Kayaks.Add(kayak);
            _context.SaveChanges();
            return kayak;
        }

        public void Delete(Kayak kayak)
        {
            _context.Remove(kayak);
            _context.SaveChanges();

        }

        public List<Kayak> GetAll()
        {
            return _context.Kayaks.ToList();
        }

        public Kayak? GetById(int id)
        {
            return _context.Kayaks
                //.AsNoTracking() //Tema avanzado. Pueden ignorar esta linea.
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Kayak kayak)
        {
            //Tema avanzado. Pueden ignorar estas lineas.
            /*
            var entry = _context.Entry(subject); 
            if (entry.State == EntityState.Detached) _context.Subjects.Update(subject);
            */

            _context.SaveChanges();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
