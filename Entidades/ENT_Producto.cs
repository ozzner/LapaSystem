using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Entidades
{
    public class ENT_Producto
    {
        public int ProductoID { get; set; }
        public string ProdLabCod { get; set; }
        public string NombreProducto { get; set; }
        public string DescProducto { get; set; }
        public string NomCliente { get; set; }
        public int UsuarioID { get; set; }
        public int ProdLabID { get; set; }
     
    }
}
