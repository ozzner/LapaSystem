using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_TipoParametro
    {
        ADNT_TipoParametro dataNTx = new ADNT_TipoParametro();
        ADT_TipoParametro dataTx = new ADT_TipoParametro();

        public List<ENT_TipoParametro> ListarTipoParametro (){
        return dataNTx.ListarTipoParametro();
        }


    }

}
