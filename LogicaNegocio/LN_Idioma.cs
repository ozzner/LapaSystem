using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{   
    public class LN_Idioma
    {
        ADNT_Idioma dataNTx = new ADNT_Idioma();

        public Dictionary<string, string> ObtenerEtiquetasPorIdioma(string codigoidioma)
        {
            return dataNTx.ObtenerEtiquetasPorIdioma(codigoidioma);
        }

       
    }

}
