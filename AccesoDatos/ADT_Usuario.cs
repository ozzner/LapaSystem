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
    public class ADT_Usuario
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public bool EliminarUsuario(int UsuarioID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_EliminarUsuario";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = UsuarioID;

            //connect.MyCmd.Parameters.Add("@existe", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
               // resultado = Convert.ToInt32(connect.MyCmd.Parameters["@existe"].Value);
                TransSql.Commit();

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "EliminarUsuario", "Web");
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


        public bool InsertarUsuario(ENT_Usuario oEnt_Usuario, ref int resultado, int UsuarioLogeado,ref int existeSupervisor)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarUsuario";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oEnt_Usuario.Nombre;
            connect.MyCmd.Parameters.Add("@PerfilUsuarioID", SqlDbType.Int).Value = oEnt_Usuario.PerfilUsuarioID;
            connect.MyCmd.Parameters.Add("@LaboratorioID", SqlDbType.Int).Value = oEnt_Usuario.LaboratorioID;
            connect.MyCmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oEnt_Usuario.Correo;
            connect.MyCmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = oEnt_Usuario.Clave;
            connect.MyCmd.Parameters.Add("@Estado", SqlDbType.Int).Value = oEnt_Usuario.Estado;
            connect.MyCmd.Parameters.Add("@Dominio", SqlDbType.VarChar).Value = oEnt_Usuario.Dominio;
            connect.MyCmd.Parameters.Add("@UsuarioLogeado", SqlDbType.VarChar).Value = UsuarioLogeado;
            connect.MyCmd.Parameters.Add("@RestriccionIP", SqlDbType.Int).Value = oEnt_Usuario.RestriccionIP;
            connect.MyCmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@ExisteSupervisor", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                resultado = (connect.MyCmd.Parameters["@Resultado"].Value.Equals(DBNull.Value)) ? 5 : Convert.ToInt32(connect.MyCmd.Parameters["@Resultado"].Value);
                existeSupervisor = Convert.ToInt32(connect.MyCmd.Parameters["@existeSupervisor"].Value);
                TransSql.Commit();

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "InsertarUsuario", "Web");
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



        public bool ActualizarUsuario(ENT_Usuario oEnt_Usuario, int Tipo)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ActualizarUsuario";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = oEnt_Usuario.UsuarioID;
            connect.MyCmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oEnt_Usuario.Nombre;
            connect.MyCmd.Parameters.Add("@PerfilUsuarioID", SqlDbType.Int).Value = oEnt_Usuario.PerfilUsuarioID;
            connect.MyCmd.Parameters.Add("@LaboratorioID", SqlDbType.Int).Value = oEnt_Usuario.LaboratorioID;
            connect.MyCmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oEnt_Usuario.Correo;
            connect.MyCmd.Parameters.Add("@Estado", SqlDbType.Int).Value = oEnt_Usuario.Estado;
            connect.MyCmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = oEnt_Usuario.Clave;
            connect.MyCmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
            connect.MyCmd.Parameters.Add("@RestriccionIP", SqlDbType.Int).Value = oEnt_Usuario.RestriccionIP;

            //connect.MyCmd.Parameters.Add("@existe", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                // resultado = Convert.ToInt32(connect.MyCmd.Parameters["@existe"].Value);
                TransSql.Commit();

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ActualizarUsuario", "Web");
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
