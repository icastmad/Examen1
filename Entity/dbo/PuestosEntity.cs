﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.dbo
{
    public class PuestosEntity : EN
    {
        public int? Id_Puesto { get; set; }
        public string Nombre { get; set; }
        public string Salario { get; set; }
    }
}
