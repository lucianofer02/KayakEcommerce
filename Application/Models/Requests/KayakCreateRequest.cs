﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayaksEcommerce.Application.Models.Requests;

public class KayakCreateRequest
{
    public string Name { get; set; } = string.Empty;
    public string Color {  get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; } = int.MinValue;
}
