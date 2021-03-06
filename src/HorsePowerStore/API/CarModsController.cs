﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HorsePowerStore.Models;
using HorsePowerStore.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HorsePowerStore.Controllers
{
    [Route("api/[controller]")]
    public class CarModsController : Controller
    {
        private int pageLength = 50;
        private CarModsService carModsService;

        public CarModsController(CarModsService carModsService)
        {
            this.carModsService = carModsService;
        }
        
        // GET api/values/5
        [HttpGet("{id}/{page}")]
        public List<CarMod> Get(int id, int page)
        {
            return carModsService.ListProductsByStyle(id, pageLength * page, pageLength);
        }
    }
}
