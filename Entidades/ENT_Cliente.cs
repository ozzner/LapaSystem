using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Entidades
{
    [Serializable]
    public class ENT_Cliente
    {
        public int ClienteID { get; set; }
        public string NombreCliente { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public int PaisID { get; set; }
        public int CiudadID { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public string NombreContacto { get; set; }
        public string NombrePais { get; set; }
        public string NombreCiudad { get; set; }
        public string TelefonoContacto { get; set; }
        public string EmailContacto { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

    }
}
