using System;
using System.Collections.Generic;
using System.Text;

namespace App1.clases
{
    public class Empleado
    {
        public int Id { get; set; }
        public int Empresa { get; set; }
        public string Nombre { get; set; }
        public string ApePat { get; set; }
        public string ApeMat { get; set; }
        public string Puesto { get; set; }
        public decimal Sueldo { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
