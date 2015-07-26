using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Pais
    {
        ADNT_Pais dataNTx = new ADNT_Pais();
        ADT_Pais dataTx = new ADT_Pais();


        public List<ENT_Pais> ListarPais()
        {
            return dataNTx.ListarPais();

        }


    }

}
