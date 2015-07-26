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
    public class ADNT_TipoParametro
    {

        public Conexion connect = new Conexion();
        public ENT_Error enterror;


        public List<ENT_TipoParametro> ListarTipoParametro()
        {
            List<ENT_TipoParametro> oLista = new List<ENT_TipoParametro>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarTipoParametro";
            connect.MyCmd.Parameters.Clear();

          //  connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = UsuarioID;


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
                    ENT_TipoParametro oEnt_TipoParametro = new ENT_TipoParametro();
                    oEnt_TipoParametro.TipoParametroID = DrSql.GetInt32(DrSql.GetOrdinal("TipoParametroID"));
                    oEnt_TipoParametro.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomParametro"));
                    oLista.Add(oEnt_TipoParametro);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListaTipoParametro", "Web");
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
