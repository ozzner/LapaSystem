using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ENT_Empresa
    {
        public int EmpresaID { get; set; }
        public string EmpresaCod { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string PaisID { get; set; }
        public string CiudadID { get; set; }
        public string Direccion { get; set; }
        public string RubroID { get; set; }
        public string Dominio { get; set; }
        public string Correo { get; set; }
        public string NomCiudad { get; set; }
        public string NomPais { get; set; }
        public string NomRubro { get; set; }
        public int TipoUsoID { get; set; }
        public bool Servicio { get; set; }
        public bool Gratuito { get; set; }
        public string nomLab { get; set; }
        public string ubicacion { get; set; }
        public string segmento { get; set; }
        public string enlace { get; set; }
        public string imagen { get; set; }
        public string PathLogo { get; set; }
        public string IP { get; set; }
        public string Idioma { get; set; }
        
        }
}
