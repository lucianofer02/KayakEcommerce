using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using KayaksEcommerce.Infrastructure.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class KayakRepository : IKayakRepository
    {
        private readonly ApplicationContext _context;
        public KayakRepository(ApplicationContext context)
        {
            _context = context;
        }
        static int LastIdAssigned = 0;
        static List<Kayak> kayaks = [];
        public Kayak Add(Kayak kayak)
        {
            kayak.Id = ++LastIdAssigned;
            kayaks.Add(kayak);
            return kayak;
        }

        public void Delete(Kayak kayak)
        {
            kayaks.Remove(kayak);
        }

        public List<Kayak> GetAll()
        {
            return kayaks.ToList();
        }

        public Kayak? GetById(int id)
        {
            return kayaks.FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Kayak kayak)
        {
            var obj = kayaks.FirstOrDefault(x => x.Id == kayak.Id)
                ?? throw new NotFoundException(nameof(Kayak), kayak.Id);

            obj.Name = kayak.Name;

        }
    }
}
