using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ENT_FacturaDetalle
    {
        public int FacturaDetalleID { get; set; }
        public int FacturaID { get; set; }
        public int LicenciaID { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
        public int NumberOrder { get; set; }
        public string CodPaquete { get; set; }
        public string Description { get; set; }
       
    }
}
