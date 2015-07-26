using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ENT_Factura
    {
        public int FacturaID { get; set; }
        public int EmpresaID { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IGV { get; set; }
        public decimal Total    { get; set; }
        public DateTime Fecha { get; set; }
      
    }
}
