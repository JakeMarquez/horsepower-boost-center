﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorsePowerStore.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; }

    }
}
