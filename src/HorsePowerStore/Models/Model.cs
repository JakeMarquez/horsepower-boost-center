﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorsePowerStore.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Year> Years { get; set; }
    }
}
