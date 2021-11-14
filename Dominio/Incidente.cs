using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Incidente
    {
        public int ID { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_cierre { get; set; }
        public string Detalles { get; set; }
        public Empleado Empleado { get; set; }
        public Estado Estado { get; set; }
        public string ComentarioFinal { get; set; }

    }
}
