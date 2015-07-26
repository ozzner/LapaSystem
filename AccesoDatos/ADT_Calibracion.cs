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
    public class ADT_Calibracion
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;


        public bool AgregarCalibracion(int EquipoID
                                            , string FecProgramada
                                            , string Operador
                                            , string ISO)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarCalibracion";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = EquipoID;
            connect.MyCmd.Parameters.Add("@ISO", SqlDbType.VarChar).Value = ISO;
            connect.MyCmd.Parameters.Add("@FecProgramada", SqlDbType.DateTime).Value = DateTime.Parse(FecProgramada);
            connect.MyCmd.Parameters.Add("@Operador", SqlDbType.VarChar).Value = Operador;

            //connect.MyCmd.Parameters.Add("@existe", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                //resultado = Convert.ToInt32(connect.MyCmd.Parameters["@existe"].Value);
                TransSql.Commit();

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "AgregarMantenimiento", "Web");
                enterror.RegisterLog();
                TransSql.Rollback();
                return false;
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




        public bool FinalizarCalibracion(int CalibracionID
                                            , string FechaRealizado
                                            , string Observaciones
                                            )
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_EditarCalibracion";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@CalibracionID", SqlDbType.Int).Value = CalibracionID;
            connect.MyCmd.Parameters.Add("@FechaRealizado", SqlDbType.DateTime).Value = DateTime.Parse(FechaRealizado);
            connect.MyCmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones;

            //connect.MyCmd.Parameters.Add("@existe", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                //resultado = Convert.ToInt32(connect.MyCmd.Parameters["@existe"].Value);
                TransSql.Commit();

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "EditarCalibracion", "Web");
                enterror.RegisterLog();
                TransSql.Rollback();
                return false;
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

        public bool EliminarCalibracion(string CalibracionID)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_EliminarCalibracion";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@CalibracionID", SqlDbType.Int).Value = Int32.Parse(CalibracionID);

            //connect.MyCmd.Parameters.Add("@existe", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                //resultado = Convert.ToInt32(connect.MyCmd.Parameters["@existe"].Value);
                TransSql.Commit();

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "EliminarCalibracion", "Web");
                enterror.RegisterLog();
                TransSql.Rollback();
                return false;
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
