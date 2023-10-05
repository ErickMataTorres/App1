using System;
using System.Collections.Generic;
using System.Text;

namespace App1.clases
{
    public class CatalogoSat
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
