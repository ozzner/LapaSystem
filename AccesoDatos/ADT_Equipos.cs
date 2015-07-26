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
    public class ADT_Equipos
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;



        public bool ActualizarEquipo(ENT_Equipos oENT_Equipo)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ActualizandoEquipo";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oENT_Equipo.Nombre;
            connect.MyCmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = oENT_Equipo.SerialNumber;
            connect.MyCmd.Parameters.Add("@Marca", SqlDbType.VarChar).Value = oENT_Equipo.Marca;
            connect.MyCmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = oENT_Equipo.Modelo;
            connect.MyCmd.Parameters.Add("@Proveedor", SqlDbType.VarChar).Value = oENT_Equipo.Proveedor;
            connect.MyCmd.Parameters.Add("@Estado", SqlDbType.Int).Value = oENT_Equipo.Estado;
            connect.MyCmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = oENT_Equipo.EquipoID;

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
                enterror = new ENT_Error(ex.Message, "ActualizarEquipo", "Web");
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

        public bool InsertarEquipo(ENT_Equipos oENT_Equipo)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarEquipo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@NomEquipo", SqlDbType.VarChar).Value = oENT_Equipo.Nombre;
            connect.MyCmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = oENT_Equipo.SerialNumber;
            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.VarChar).Value = oENT_Equipo.UsuarioID;
            connect.MyCmd.Parameters.Add("@LaboratorioCod", SqlDbType.VarChar).Value = oENT_Equipo.LaboratorioCod;
            //connect.MyCmd.Parameters.Add("@Marca", SqlDbType.VarChar).Value = oENT_Equipo.Marca;
            //connect.MyCmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = oENT_Equipo.Modelo;

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
                enterror = new ENT_Error(ex.Message, "InsertarEquipo", "Web");
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

        public bool QuitarEquipo(int EquipoID,ref int existe)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_QuitarEquipo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@EquipoID", SqlDbType.VarChar).Value = EquipoID;
            //connect.MyCmd.Parameters.Add("@existe", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                //existe = Convert.ToInt32(connect.MyCmd.Parameters["@existe"].Value);
                TransSql.Commit();
                existe = 0;
                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "QuitarEquipo", "Web");
                enterror.RegisterLog();
                TransSql.Rollback();
                existe = 1;
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
