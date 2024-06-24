using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IKayakRepository
    {
        List<Kayak> GetAll();
        Kayak? GetById(int id);
        Kayak Add(Kayak kayak);
        void Delete(Kayak kayak);
        void Update(Kayak kayak);
        void SaveChanges();
    }
}
