﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorsePowerStore.Models
{
    public class CarMod
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Engine Engine { get; set; }
        public Product Product { get; set; }
        public decimal HorsePower { get; set; }
    }
}
