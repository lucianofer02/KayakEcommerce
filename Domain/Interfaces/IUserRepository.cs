using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        void Delete(User user);
        List<User> GetAll();
        User? GetById(int id);
        void SaveChanges();
        void Update(User user);
        User? GetUserByUserName(string userName);
    }
}
