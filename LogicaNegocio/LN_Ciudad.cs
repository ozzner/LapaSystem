using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_Ciudad
    {
        ADNT_Ciudad dataNTx = new ADNT_Ciudad();
        ADT_Ciudad dataTx = new ADT_Ciudad();

        public List<ENT_Ciudad> ListarCiudad(int filtro)
        {
            return dataNTx.ListarCiudad(filtro);

        }

    }

}
