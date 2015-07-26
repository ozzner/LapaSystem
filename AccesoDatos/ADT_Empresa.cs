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
    public class ADT_Empresa
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;
        public bool InsertarNuevaEmpresa(ENT_Empresa oEnt_Empresa, ENT_Usuario oEnt_Usuario, ref int resultado)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarNuevaEmpresa";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = oEnt_Empresa.Ruc;
            connect.MyCmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = oEnt_Empresa.RazonSocial;
            connect.MyCmd.Parameters.Add("@PaisID", SqlDbType.VarChar).Value = oEnt_Empresa.PaisID;
            connect.MyCmd.Parameters.Add("@CiudadID", SqlDbType.VarChar).Value = oEnt_Empresa.CiudadID;
            connect.MyCmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = oEnt_Empresa.Direccion;
            connect.MyCmd.Parameters.Add("@RubroID", SqlDbType.VarChar).Value = oEnt_Empresa.RubroID;
            connect.MyCmd.Parameters.Add("@Segmento", SqlDbType.VarChar).Value = oEnt_Empresa.segmento;
            connect.MyCmd.Parameters.Add("@Dominio", SqlDbType.VarChar).Value = oEnt_Empresa.Dominio;
            connect.MyCmd.Parameters.Add("@Servicio", SqlDbType.Bit).Value = oEnt_Usuario.Servicio;
            connect.MyCmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oEnt_Empresa.Correo;
            connect.MyCmd.Parameters.Add("@nomLab", SqlDbType.VarChar).Value = oEnt_Empresa.nomLab;
            connect.MyCmd.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = oEnt_Empresa.ubicacion;
            connect.MyCmd.Parameters.Add("@idioma", SqlDbType.VarChar).Value = oEnt_Empresa.Idioma;


            connect.MyCmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oEnt_Usuario.Nombre;
            connect.MyCmd.Parameters.Add("@CorreoE", SqlDbType.VarChar).Value = oEnt_Usuario.Correo;
            connect.MyCmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = oEnt_Usuario.Clave;

            connect.MyCmd.Parameters.Add("@existe", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                resultado = Convert.ToInt32(connect.MyCmd.Parameters["@existe"].Value);
                TransSql.Commit();

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "InsertarRegistroTemporal", "Web");
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

        public bool ActualizarLogoEmpresa(ENT_Empresa oEnt_Empresa)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ActualizarLogoEmpresa";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = oEnt_Empresa.Ruc;
            connect.MyCmd.Parameters.Add("@PathLogo", SqlDbType.VarChar).Value = oEnt_Empresa.PathLogo;
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
                enterror = new ENT_Error(ex.Message, "ActualizarLogoEmpresa", "Web");
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

        public bool ActualizarIPEmpresa(string nuevaip, string ruc)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ActualizarIPEmpresa";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@NuevaIP", SqlDbType.VarChar).Value = nuevaip;
            connect.MyCmd.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = ruc;
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
                enterror = new ENT_Error(ex.Message, "ActualizarIPEmpresa", "Web");
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
