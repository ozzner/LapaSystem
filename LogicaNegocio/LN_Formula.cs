using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Formula
    {
        ADNT_Formula dataNTx = new ADNT_Formula();
        ADT_Formula dataTx = new ADT_Formula();
        public List<ENT_Formula> ListarFormula()
        {
            return dataNTx.ListarFormula();
        }


    }

}
