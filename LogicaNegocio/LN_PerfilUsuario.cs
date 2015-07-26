using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_PerfilUsuario
    {
        ADNT_PerfilUsuario dataNTx = new ADNT_PerfilUsuario();
        ADT_PerfilUsuario dataTx = new ADT_PerfilUsuario();

        public List<ENT_PerfilUsuario> ListarPerfilUsuario()
        {
            return dataNTx.ListarPerfilUsuario();

        }

    }

}
