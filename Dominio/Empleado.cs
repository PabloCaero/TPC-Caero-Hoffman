﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado
    {
        public int Legajo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public Cargo Cargo { get; set; }
    }
}
