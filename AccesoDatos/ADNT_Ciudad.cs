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
    public class ADNT_Ciudad
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_Ciudad> ListarCiudad(int filtro)
        {
            List<ENT_Ciudad> oLista = new List<ENT_Ciudad>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarCiudad";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;

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
                    ENT_Ciudad oEnt_Ciudad = new ENT_Ciudad();
                    oEnt_Ciudad.NombreCiudad = DrSql.GetString(DrSql.GetOrdinal("NombreCiudad"));
                    oEnt_Ciudad.CiudadID = DrSql.GetInt32(DrSql.GetOrdinal("CiudadID"));
                    oLista.Add(oEnt_Ciudad);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListaCiudad", "Web");
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
