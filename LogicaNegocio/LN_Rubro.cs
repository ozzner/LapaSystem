using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Rubro
    {
        ADNT_Rubro dataNTx = new ADNT_Rubro();
        ADT_Rubro dataTx = new ADT_Rubro();


        public List<ENT_Rubro> ListarRubro()
        {
            return dataNTx.ListarRubro();

        }

    }

}
