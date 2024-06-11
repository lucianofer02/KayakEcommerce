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
        Kayak Add(Kayak kayak);
        void Delete(Kayak kayak);
        List<Kayak> GetAll();
        Kayak? GetById(int id);
        void SaveChanges();
        void Update(Kayak kayak);
    }
}
