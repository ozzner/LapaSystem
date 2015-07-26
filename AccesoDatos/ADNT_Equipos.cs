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
    public class ADNT_Equipos
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_Equipos> ListarEquiposLab(string LaboratorioCod)
        {
            List<ENT_Equipos> oLista = new List<ENT_Equipos>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarEquiposLab";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@LaboratorioCod", SqlDbType.VarChar, 10).Value = LaboratorioCod;
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
                    ENT_Equipos oEnt_Equipos = new ENT_Equipos();
                    oEnt_Equipos.Nombre = DrSql.GetString(DrSql.GetOrdinal("Nombre"));
                    oEnt_Equipos.EquipoID = DrSql.GetInt32(DrSql.GetOrdinal("EquipoID"));
                    oLista.Add(oEnt_Equipos);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarEquiposLab", "Web");
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

        public ENT_Equipos ObtenerDetalle(int EquipoID)
        {
      

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerDetalle";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = EquipoID;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Equipos oEnt_Equipos = new ENT_Equipos();

                while (DrSql.Read())
                {
                    oEnt_Equipos.Nombre = DrSql.GetString(DrSql.GetOrdinal("Nombre"));
                    oEnt_Equipos.SerialNumber = DrSql.GetString(DrSql.GetOrdinal("SerialNumber"));
                    oEnt_Equipos.Marca = DrSql.GetString(DrSql.GetOrdinal("Marca"));
                    oEnt_Equipos.Modelo = DrSql.GetString(DrSql.GetOrdinal("Modelo"));
                    oEnt_Equipos.Estado = DrSql.GetInt32(DrSql.GetOrdinal("Estado"));
                    oEnt_Equipos.Proveedor = DrSql.GetString(DrSql.GetOrdinal("Proveedor"));
                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Equipos;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerDetalle_Equipos", "Web");
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

        public List<ENT_Equipos> ListarEquiposParametro(int MuestraDetalleID)
        {
            List<ENT_Equipos> oLista = new List<ENT_Equipos>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarEquiposParametro";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@MuestraDetalleID", SqlDbType.Int).Value = MuestraDetalleID;
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
                    ENT_Equipos oEnt_Equipos = new ENT_Equipos();
                    oEnt_Equipos.Nombre = DrSql.GetString(DrSql.GetOrdinal("Nombre"));
                    oEnt_Equipos.EquipoID = DrSql.GetInt32(DrSql.GetOrdinal("EquipoID"));
                    oLista.Add(oEnt_Equipos);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarEquiposParametro", "Web");
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
