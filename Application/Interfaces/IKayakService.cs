using Application.Models;
using Domain.Entities;
using KayaksEcommerce.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IKayakService
    {
        Kayak Create(KayakCreateRequest kayakCreateRequest);
        object Create(KayaksEcommerce.Application.Models.Requests.KayakCreateRequest createKayakRequest);
        object Create(KayakCreateRequest createKayakRequest);
        void Delete(int id);
        List<KayakDto> GetAll();
        List<Kayak> GetAllFullData();
        KayakDto GetById(int id);
        void Update(int id, KayakUpdateRequest kayakUpdateRequest);
    }
}
