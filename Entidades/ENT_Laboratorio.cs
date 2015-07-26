using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Entidades
{
    public class ENT_Laboratorio
    {
        public int LaboratorioID { get; set; }
        public string LaboratorioCod { get; set; }
        public string Codigo { get; set; }
        public string NomLaboratorio { get; set; }
        public string NomUsuario { get; set; }
        public int EmpresaID { get; set; }
        public int ProdLabID { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
