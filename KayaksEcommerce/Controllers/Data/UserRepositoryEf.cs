using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace KayaksEcommerce.Infrastructure.Data
{
    public class UserRepositoryEf : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepositoryEf(ApplicationContext context)
        {

            _context = context;

        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();

        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users
                //.AsNoTracking() //Tema avanzado. Pueden ignorar esta linea.
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(User user)
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

        User IUserRepository.Add(User user)
        {
            throw new NotImplementedException();
        }
    }
}
