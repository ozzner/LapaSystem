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
    public class ADT_Laboratorio
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public bool InsertarLab(string lab, string ubicacion, string ruc, int usuarioID)
        {
            {
                SqlTransaction TransSql = default(SqlTransaction);
                connect.MyConn = new SqlConnection(connect.strCxn());
                connect.MyCmd.CommandType = CommandType.StoredProcedure;
                connect.MyCmd.CommandText = "SLW_SP_InsertarLab";
                connect.MyCmd.Parameters.Clear();
                connect.MyCmd.Parameters.Add("@NomLaboratorio", SqlDbType.VarChar).Value = lab;
                connect.MyCmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = ubicacion;
                connect.MyCmd.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = ruc;
                connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = usuarioID;

                try
                {
                    if (connect.MyConn.State == ConnectionState.Closed)
                        connect.MyConn.Open();
                    connect.MyCmd.Connection = connect.MyConn;
                    TransSql = connect.MyConn.BeginTransaction();
                    connect.MyCmd.Transaction = TransSql;
                    connect.MyCmd.ExecuteNonQuery();
                    TransSql.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    enterror = new ENT_Error(ex.Message, "InsertarLab", "Web");
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

        public bool ActualizarLaboratorio(ENT_Laboratorio oEnt_Laboratorio)
        {
                SqlTransaction TransSql = default(SqlTransaction);
                connect.MyConn = new SqlConnection(connect.strCxn());
                connect.MyCmd.CommandType = CommandType.StoredProcedure;
                connect.MyCmd.CommandText = "SLW_SP_ActualizarLaboratorio";
                connect.MyCmd.Parameters.Clear();
                connect.MyCmd.Parameters.Add("@LaboratorioID", SqlDbType.Int).Value = oEnt_Laboratorio.LaboratorioID;
                connect.MyCmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = oEnt_Laboratorio.Ubicacion;
                connect.MyCmd.Parameters.Add("@NomLaboratorio", SqlDbType.VarChar).Value = oEnt_Laboratorio.NomLaboratorio;

                try
                {
                    if (connect.MyConn.State == ConnectionState.Closed)
                        connect.MyConn.Open();
                    connect.MyCmd.Connection = connect.MyConn;
                    TransSql = connect.MyConn.BeginTransaction();
                    connect.MyCmd.Transaction = TransSql;
                    connect.MyCmd.ExecuteNonQuery();
                    TransSql.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    enterror = new ENT_Error(ex.Message, "ActualizarLab", "Web");
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

        public bool EliminarLaboratorio(int laboratorioID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_EliminarLab";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@LaboratorioID", SqlDbType.Int).Value = laboratorioID;

            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                TransSql.Commit();

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "EliminarLab", "Web");
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
