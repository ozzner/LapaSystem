using System;
using System.Xml;

namespace CrearCaptcha
{
    public class XML
    {
        public static string leerClave(string archivoXml, string claveNombre, string claveValor, string atributoNombre)
        {
            string atributoValor = "";
            XmlTextReader xtr = new XmlTextReader(archivoXml);
            while (xtr.Read())
            {
                if (xtr.Name.Equals("add"))
                {
                    string nombre = xtr.GetAttribute(claveNombre);
                    if (nombre != null && nombre.Equals(claveValor))
                    {
                        atributoValor = xtr.GetAttribute(atributoNombre);
                        break;
                    }
                }
            }
            return (atributoValor);
        }
    }
}