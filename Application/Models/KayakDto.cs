﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class KayakDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Color {  get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; }

        public static KayakDto Create(Kayak kayak)
        {
            var dto = new KayakDto();
            dto.Id = kayak.Id;
            dto.Name = kayak.Name;
            dto.Color = kayak.Color;
            dto.Description = kayak.Description;
            dto.Price = kayak.Price;

            return dto;
        }

        public static List<KayakDto> CreateList(IEnumerable<Kayak> kayaks)
        {
            List<KayakDto> listDto = [];
            foreach (var s in kayaks)
            {
                listDto.Add(Create(s));
            }

            return listDto;
        }
    }
}
