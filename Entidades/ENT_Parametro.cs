using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Entidades
{
    public class ENT_Parametro
    {
        public int ParametroID { get; set; }
        public string NomParametro { get; set; }
        public string NomProducto { get; set; }
        public string NomLaboratorio { get; set; }
        public string Metodologia { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioID { get; set; }
        public int ProdLabID { get; set; }
        public int LaboratorioID { get; set; }
        public string Tiempo { get; set; }
        public string CodigoMuestra { get; set; }
        public decimal Resultado { get; set; }
        public decimal ProdParaCod { get; set; }
        public decimal MaxAdvertencia { get; set; }
        public decimal MinAdvertencia { get; set; }
        public decimal Promedio { get; set; }
        public decimal MaxAccion { get; set; }
        public decimal MinAccion { get; set; }
        public int Valor { get; set; }

        public int ParEqpID { get; set; }
    
    }
}
