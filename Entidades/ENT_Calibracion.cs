using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ENT_Calibracion
    {
        public int CalibracionID { get; set; }
        public string Observacion { get; set; }
        public int EstadoID { get; set; }
        public string NomEstado { get; set; }
        public DateTime FechaProgramacion { get; set; }
        public string FechaProgramacionAux { get; set; }
        public DateTime FechaRealizado { get; set; }
        public string FechaRealizadoAux { get; set; }
        public string Operador { get; set; }
        public string NombreEquipo { get; set; }
        public string ISO { get; set; }
        public int EquipoID { get; set; }

    }
}
