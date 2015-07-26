using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Entidades
{
    public class ENT_MuestraDetalle
    {
        public int MuestraDetalleID { get; set; }
        public int MuestraID { get; set; }
        public int ProdParaID { get; set; }
        public int UsuarioID { get; set; }
        public string Resultado { get; set; }
        public string ResultadoAux { get; set; }
        public DateTime FechaMuestra { get; set; }
        public DateTime HoraMuestra { get; set; }
        
    
    }
}
