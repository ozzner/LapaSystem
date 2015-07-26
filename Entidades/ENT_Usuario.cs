using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ENT_Usuario:ENT_Empresa
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Dominio { get; set; }
        public string Laboratorio { get; set; }
        public int LaboratorioID { get; set; }
        public string PerfilUsuario { get; set; }
        public int PerfilUsuarioID { get; set; }
        public int Estado { get; set; }
        public string NomEstado { get; set; }
        public int Anulado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Intentos { get; set; }
        public int RestriccionIP { get; set; }
        public string NomRestriccion { get; set; }
    }
}
