using System;
using System.Collections.Generic;
using System.Text;

namespace App1.clases
{
    public class Concepto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string ClaveSat { get; set; }
        public bool Sistema { get; set; }
        public decimal Exento { get; set; }
        public decimal Importe { get; set; }
    }
}
