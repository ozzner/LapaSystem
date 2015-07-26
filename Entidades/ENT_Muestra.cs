using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Entidades
{
    public class ENT_Muestra:ENT_MuestraDetalle
    {
        public int MuestraID { get; set; }
        public string CodigoMuestra { get; set; }
        public int ProdLabID { get; set; }
        public string Prioridad{ get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime HoraRegistro { get; set; }
        public string Nombre { get; set; }
        public string NomParametro { get; set; }
        public decimal MinAccion { get; set; }
        public decimal MinAdvertencia { get; set; }
        public decimal Promedio { get; set; }
        public decimal MaxAdvertencia { get; set; }
        public decimal MaxAccion { get; set; }
        public int EstadoMuestraID { get; set; }
        public int TipoParametroID { get; set; }
        public string NomEstado { get; set; }
        public string CreadoPor { get; set; }
        public string FechaTerminado { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public DateTime FechaFinDt { get; set; }
        public string Formula { get; set; }

        public DateTime FechaFinEstimado { get; set; }
        public string UnidadMedida { get; set; }
        public string NomProducto { get; set; }
    




    }
}
