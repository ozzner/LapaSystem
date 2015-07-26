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
    public class ADNT_Calibracion
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_Calibracion> ListarCalibracionesXEquipo(int EquipoID)
        {
            List<ENT_Calibracion> oLista = new List<ENT_Calibracion>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarCalibracionesXEquipo"; //no existe sp
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@EquipoID", SqlDbType.VarChar).Value = EquipoID;

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
                    ENT_Calibracion oEnt_Calibracion = new ENT_Calibracion();
                    //oEnt_Calibracion.EquipoID = DrSql.GetInt32(DrSql.GetOrdinal("EquipoID"));
                    //oEnt_Calibracion.NombreEquipo = DrSql.GetString(DrSql.GetOrdinal("NombreEquipo"));
                    //oEnt_Calibracion.EstadoID = DrSql.GetInt32(DrSql.GetOrdinal("EstadoID"));
                    //oEnt_Calibracion.NomEstado = DrSql.GetString(DrSql.GetOrdinal("NomEstado"));
                    //oEnt_Calibracion.FechaProgramacionAux = DrSql.GetString(DrSql.GetOrdinal("FechaProgramacion"));
                    //oEnt_Calibracion.FechaRealizadoAux = DrSql.GetString(DrSql.GetOrdinal("FechaRealizado"));
                    //oEnt_Calibracion.Operador = DrSql.GetString(DrSql.GetOrdinal("Operador"));
                    //oEnt_Calibracion.Observacion = DrSql.GetString(DrSql.GetOrdinal("Observacion"));
                    oLista.Add(oEnt_Calibracion);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarCalibracionesXEquipo", "Web");
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







        public List<ENT_Calibracion> ListarCalibraciones(int Tipo,string LaboratorioCod)
        {
            List<ENT_Calibracion> oLista = new List<ENT_Calibracion>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarCalibraciones";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@LaboratorioCod", SqlDbType.VarChar).Value = LaboratorioCod;
            connect.MyCmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;

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
                    ENT_Calibracion oEnt_Calibracion = new ENT_Calibracion();

                    oEnt_Calibracion.CalibracionID = DrSql.GetInt32(DrSql.GetOrdinal("CalibracionID"));
                    oEnt_Calibracion.EquipoID = DrSql.GetInt32(DrSql.GetOrdinal("EquipoID"));
                    oEnt_Calibracion.NombreEquipo = DrSql.GetString(DrSql.GetOrdinal("NombreEquipo"));
                    oEnt_Calibracion.EstadoID = DrSql.GetInt32(DrSql.GetOrdinal("EstadoID"));
                    oEnt_Calibracion.NomEstado = DrSql.GetString(DrSql.GetOrdinal("NomEstado"));
                    oEnt_Calibracion.FechaProgramacionAux = DrSql.GetString(DrSql.GetOrdinal("FechaProgramacion"));
                    oEnt_Calibracion.FechaRealizadoAux = DrSql.GetString(DrSql.GetOrdinal("FechaRealizado"));
                    oEnt_Calibracion.Operador = DrSql.GetString(DrSql.GetOrdinal("Operador"));
                    oEnt_Calibracion.Observacion = DrSql.GetString(DrSql.GetOrdinal("Observacion"));
                    oEnt_Calibracion.ISO = DrSql.GetString(DrSql.GetOrdinal("ISO"));
                    oLista.Add(oEnt_Calibracion);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListaMantenimientos", "Web");
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
