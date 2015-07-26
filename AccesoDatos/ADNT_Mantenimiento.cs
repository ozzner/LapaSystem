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
    public class ADNT_Mantenimiento
    {

        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_Mantenimiento> ListarMantenimientosXEquipo(int EquipoID)
        {
            List<ENT_Mantenimiento> oLista = new List<ENT_Mantenimiento>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarMantenimientosXEquipo";
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
                    ENT_Mantenimiento oEnt_Mantenimiento = new ENT_Mantenimiento();
                    oEnt_Mantenimiento.EquipoID = DrSql.GetInt32(DrSql.GetOrdinal("EquipoID"));
                    oEnt_Mantenimiento.NombreEquipo = DrSql.GetString(DrSql.GetOrdinal("NombreEquipo"));
                    oEnt_Mantenimiento.EstadoID = DrSql.GetInt32(DrSql.GetOrdinal("EstadoID"));
                    oEnt_Mantenimiento.NomEstado = DrSql.GetString(DrSql.GetOrdinal("NomEstado"));
                    oEnt_Mantenimiento.FechaProgramacionAux = DrSql.GetString(DrSql.GetOrdinal("FechaProgramacion"));
                    oEnt_Mantenimiento.FechaRealizadoAux = DrSql.GetString(DrSql.GetOrdinal("FechaRealizado"));
                    oEnt_Mantenimiento.Operador = DrSql.GetString(DrSql.GetOrdinal("Operador"));
                    oEnt_Mantenimiento.Observacion = DrSql.GetString(DrSql.GetOrdinal("Observacion"));
                    oLista.Add(oEnt_Mantenimiento);
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







        public List<ENT_Mantenimiento> ListarMantenimientos(int Tipo,string LaboratorioCod)
        {
            List<ENT_Mantenimiento> oLista = new List<ENT_Mantenimiento>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarMantenimientos";
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
                    ENT_Mantenimiento oEnt_Mantenimiento = new ENT_Mantenimiento();
                    
                    oEnt_Mantenimiento.MantenimientoID = DrSql.GetInt32(DrSql.GetOrdinal("MantenimientoID"));
                    oEnt_Mantenimiento.EquipoID = DrSql.GetInt32(DrSql.GetOrdinal("EquipoID"));
                    oEnt_Mantenimiento.NombreEquipo = DrSql.GetString(DrSql.GetOrdinal("NombreEquipo"));
                    oEnt_Mantenimiento.EstadoID = DrSql.GetInt32(DrSql.GetOrdinal("EstadoID"));
                    oEnt_Mantenimiento.NomEstado = DrSql.GetString(DrSql.GetOrdinal("NomEstado"));
                    oEnt_Mantenimiento.FechaProgramacionAux = DrSql.GetString(DrSql.GetOrdinal("FechaProgramacion"));
                    oEnt_Mantenimiento.FechaRealizadoAux = DrSql.GetString(DrSql.GetOrdinal("FechaRealizado"));
                    oEnt_Mantenimiento.Operador = DrSql.GetString(DrSql.GetOrdinal("Operador"));
                    oEnt_Mantenimiento.Observacion = DrSql.GetString(DrSql.GetOrdinal("Observacion"));
                    oLista.Add(oEnt_Mantenimiento);
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
