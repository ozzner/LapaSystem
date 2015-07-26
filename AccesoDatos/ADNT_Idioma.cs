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
    public class ADNT_Idioma
    {

        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public Dictionary<string,string> ObtenerEtiquetasPorIdioma(string codigoidioma)
        {
            Dictionary<string,string> iLista = new Dictionary<string,string>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarEtiquetas";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@Idioma", SqlDbType.VarChar).Value = codigoidioma;

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
                    iLista.Add(DrSql.GetString(DrSql.GetOrdinal("coetiqueta")).ToString().Trim(), DrSql.GetString(DrSql.GetOrdinal("valor")).ToString().Trim());
                }

                DrSql.Close();

                TransSql.Commit();
                return iLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerEtiquetasPorIdioma", "Web");
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
