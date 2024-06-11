using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using KayaksEcommerce.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class KayakService : IKayakService
    {
        private readonly IKayakRepository _kayakRepository;
        public KayakService(IKayakRepository kayakRepository)
        {
            _kayakRepository = kayakRepository;
        }

        public List<Kayak> GetAllFullData()
        {
            return _kayakRepository.GetAll();
        }

        public KayakDto GetById(int id)
        {
            var obj = _kayakRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Kayak), id);
            var dto = KayakDto.Create(obj);
            return dto;
        }

        public List<KayakDto> GetAll()
        {
            var list = _kayakRepository.GetAll();
            return KayakDto.CreateList(list);
        }

        public Kayak Create(KayakCreateRequest kayakCreateRequest)
        {
            var obj = new Kayak();
            obj.Name = kayakCreateRequest.Name;
            obj.Description = kayakCreateRequest.Description;
            obj.Price = kayakCreateRequest.Price;
            return _kayakRepository.Add(obj);
        }

        public void Update(int id, KayakUpdateRequest kayakUpdateRequest)
        {

            var obj = _kayakRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Kayak), id);

            if (kayakUpdateRequest.Name != string.Empty) obj.Name = kayakUpdateRequest.Name;

            if (kayakUpdateRequest.Description != string.Empty) obj.Description = kayakUpdateRequest.Description;

            if (kayakUpdateRequest.Price != string.Empty) obj.Price = kayakUpdateRequest.Price;

            _kayakRepository.Update(obj);

        }

        public void Delete(int id)
        {
            var obj = _kayakRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Kayak), id);

            _kayakRepository.Delete(obj);
        }
    }
}
