﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorsePowerStore.Models
{
    public class CarInstance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Car Car { get; set; }
        public Engine Engine { get; set; }
        public List<ProductSelection> SelectedProducts { get; set; }
    }
}
