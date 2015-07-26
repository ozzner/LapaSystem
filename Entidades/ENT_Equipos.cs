using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ENT_Equipos
    {
        public int EquipoID { get; set; }
        public int Estado { get; set; }
        public string Nombre { get; set; }
        public string SerialNumber { get; set; }
        public string FechaRegistro { get; set; }
        public string UsuarioID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Proveedor { get; set; }
        public string LaboratorioID { get; set; }
        public string LaboratorioCod { get; set; }
    }
}
