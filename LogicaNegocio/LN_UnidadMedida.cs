using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_UnidadMedida
    {
        ADNT_UnidadMedida dataNTx = new ADNT_UnidadMedida();
        ADT_UnidadMedida dataTx = new ADT_UnidadMedida();

        public List<ENT_UnidadMedida> ListarUM() {

            return dataNTx.ListarUM();
        }

    }

}
