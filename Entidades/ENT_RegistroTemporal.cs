using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ENT_RegistroTemporal
    {
        public int RegTempID { get; set; }
        public string RazonSocial { get; set; }
        public string Dominio { get; set; }
        public string Correo { get; set; }
        public string Serial { get; set; }
        public bool Gratuito { get; set; }
    }
}
