using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace AccesoDatos
{
    public class ADNT_FacturaDetalle
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_FacturaDetalle> insertDetails;

    }
}
