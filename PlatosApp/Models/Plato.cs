﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatosApp.Models
{
    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Costo { get; set; }
        public string Ingredientes { get; set; }
    }
}