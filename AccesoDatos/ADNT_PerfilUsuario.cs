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
    public class ADNT_PerfilUsuario
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_PerfilUsuario> ListarPerfilUsuario()
        {
            List<ENT_PerfilUsuario> oLista = new List<ENT_PerfilUsuario>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarPerfilUsuario";
            connect.MyCmd.Parameters.Clear();
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();

                while (DrSql.Read())
                {
                    ENT_PerfilUsuario oEnt_PerfilUsuario = new ENT_PerfilUsuario();
                    oEnt_PerfilUsuario.NomPerfilUsuario = DrSql.GetString(DrSql.GetOrdinal("NomPerfilUsuario"));
                    oEnt_PerfilUsuario.PerfilUsuarioID = DrSql.GetInt32(DrSql.GetOrdinal("PerfilUsuarioID"));
                    oLista.Add(oEnt_PerfilUsuario);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarPerfilUsuario", "Web");
                enterror.RegisterLog();
                TransSql.Rollback();

                return null;

            }
            finally
            {
                TransSql.Dispose();
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();

            }

        }
    }
}
