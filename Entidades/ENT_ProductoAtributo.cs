using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Entidades
{
    [Serializable]
    public class ENT_ProductoAtributo
    {
        public int ProdAtriID { get; set; }
        public int AtributoID { get; set; }
        public int ProdLabID { get; set; }
        public string Opciones { get; set; }
        public string NomAtributo { get; set; }
     
    }
}
