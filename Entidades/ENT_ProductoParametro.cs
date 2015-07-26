using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Entidades
{
    public class ENT_ProductoParametro
    {
        public int ProdParaID { get; set; }
        public string ProdParaCod { get; set; }
        public int ParametroID { get; set; }
        public int ProdLabID { get; set; }
        public int NumDecimales { get; set; }
        public int TipoParametroID { get; set; }
        public string TiempoEstimado { get; set; }
        public string UnidadMedida { get; set; }
        public int UnidadMedidaID { get; set; }
        public decimal MinAdvertencia { get; set; }
        public decimal MaxAdvertencia { get; set; }
        public decimal Promedio { get; set; }
        public decimal MinAccion { get; set; }
        public decimal MaxAccion { get; set; }
        public int FormulaID { get; set; }
        public string NomParametro { get; set; }
        public string NomProducto { get; set; }
        public string NomUM { get; set; }
        public string Calculado { get; set; }

        public int Resultado { get; set; }
        public string CodigoMuestra { get; set; }
        public string FlagVgrafico { get; set; }
     
    }
}
