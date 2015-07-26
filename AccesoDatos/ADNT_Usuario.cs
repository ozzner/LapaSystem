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
    public class ADNT_Usuario
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;
        public bool ValidarUsuario(ENT_Usuario oEnt_Usuario
                                    , ref int resultado
                                    , ref int perfil
                                    , ref string nombrecompleto
                                    , ref int usuarioid
                                    , ref int PerfilUsuarioID
                                    , ref int habilitado
                                    , ref bool servicio
                                    , ref string ruc
                                    , ref int paquete
                                    , ref int downgrade
                                    , ref int restriccionip
                                    , ref string ip
                                    , ref string idioma
            
            )
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ValidarUsuario";
            connect.MyCmd.Parameters.Clear();
            //connect.MyCmd.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = oEnt_Usuario.Ruc;
            connect.MyCmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oEnt_Usuario.Correo;
            connect.MyCmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = oEnt_Usuario.Clave;
            connect.MyCmd.Parameters.Add("@resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@perfil", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@nombrecompleto", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@usuarioid", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@PerfilUsuarioID", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@Habilitado", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@Servicio", SqlDbType.Bit).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@Rucc", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@paquete", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@downgrade", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@restriccionip", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@ip", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@idioma", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
            
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                resultado = Convert.ToInt32(connect.MyCmd.Parameters["@resultado"].Value);
                //perfil = (connect.MyCmd.Parameters["@perfil"].SqlValue SqlDbType.Equals(DBNull.Value)) ? 5000 : Convert.ToInt32(connect.MyCmd.Parameters["@perfil"].Value);
                perfil = (connect.MyCmd.Parameters["@perfil"].Value.Equals(DBNull.Value)) ? 5000 : Convert.ToInt32(connect.MyCmd.Parameters["@perfil"].Value);
                nombrecompleto = (connect.MyCmd.Parameters["@nombrecompleto"].Value.Equals(DBNull.Value)) ? "" : Convert.ToString(connect.MyCmd.Parameters["@nombrecompleto"].Value);
                usuarioid = (connect.MyCmd.Parameters["@usuarioid"].Value.Equals(DBNull.Value)) ? 0 : Convert.ToInt32(connect.MyCmd.Parameters["@usuarioid"].Value);
                PerfilUsuarioID = (connect.MyCmd.Parameters["@PerfilUsuarioID"].Value.Equals(DBNull.Value)) ? 0 : Convert.ToInt32(connect.MyCmd.Parameters["@PerfilUsuarioID"].Value);
                habilitado = (connect.MyCmd.Parameters["@Habilitado"].Value.Equals(DBNull.Value)) ? 0 : Convert.ToInt32(connect.MyCmd.Parameters["@Habilitado"].Value);
                servicio = (connect.MyCmd.Parameters["@Servicio"].Value.Equals(DBNull.Value)) ? false : Convert.ToBoolean(connect.MyCmd.Parameters["@Servicio"].Value);
                ruc = (connect.MyCmd.Parameters["@Rucc"].Value.Equals(DBNull.Value)) ? "" : Convert.ToString(connect.MyCmd.Parameters["@Rucc"].Value);
                paquete = (connect.MyCmd.Parameters["@paquete"].Value.Equals(DBNull.Value)) ? 50000 : Convert.ToInt32(connect.MyCmd.Parameters["@paquete"].Value);
                downgrade = (connect.MyCmd.Parameters["@downgrade"].Value.Equals(DBNull.Value)) ? 50000 : Convert.ToInt32(connect.MyCmd.Parameters["@downgrade"].Value);
                restriccionip = (connect.MyCmd.Parameters["@restriccionip"].Value.Equals(DBNull.Value)) ? 50000 : Convert.ToInt32(connect.MyCmd.Parameters["@restriccionip"].Value);
                ip = (connect.MyCmd.Parameters["@ip"].Value.Equals(DBNull.Value)) ? "" : Convert.ToString(connect.MyCmd.Parameters["@ip"].Value);
                idioma = (connect.MyCmd.Parameters["@idioma"].Value.Equals(DBNull.Value)) ? "" : Convert.ToString(connect.MyCmd.Parameters["@idioma"].Value);
                TransSql.Commit();

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ValidarUsuario", "Web");
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

        public List<ENT_Usuario> ListarUsuario(int UsuarioID, int PerfilUsuario)
        {
            List<ENT_Usuario> oLista = new List<ENT_Usuario>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarUsuario";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = UsuarioID;
            connect.MyCmd.Parameters.Add("@PerfilUsuario", SqlDbType.Int).Value = PerfilUsuario;
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
                        ENT_Usuario oEnt_Usuario = new ENT_Usuario();
                    oEnt_Usuario.UsuarioID= DrSql.GetInt32(DrSql.GetOrdinal("UsuarioID"));
                    oEnt_Usuario.Nombre = DrSql.GetString(DrSql.GetOrdinal("Nombre"));
                    oEnt_Usuario.PerfilUsuario = DrSql.GetString(DrSql.GetOrdinal("PerfilUsuario"));
                    oEnt_Usuario.PerfilUsuarioID = DrSql.GetInt32(DrSql.GetOrdinal("PerfilUsuarioID"));
                    oEnt_Usuario.Laboratorio = DrSql.GetString(DrSql.GetOrdinal("Laboratorio"));
                    oEnt_Usuario.Correo = DrSql.GetString(DrSql.GetOrdinal("Correo"));

                    if (DrSql.GetInt32(DrSql.GetOrdinal("EstadoID")) == 2)
                    {
                        oEnt_Usuario.NomEstado = "Deshabilitado";
                    }
                    else if (DrSql.GetInt32(DrSql.GetOrdinal("EstadoID")) == 1)
                    {
                        oEnt_Usuario.NomEstado = "Habilitado";                        
                    }

                    if (DrSql.GetInt32(DrSql.GetOrdinal("RestriccionIP")) == 0)
                    {
                        oEnt_Usuario.NomRestriccion = "No";
                    }
                    else if (DrSql.GetInt32(DrSql.GetOrdinal("RestriccionIP")) == 1)
                    {
                        oEnt_Usuario.NomRestriccion = "Si";
                    }
                    
                    oLista.Add(oEnt_Usuario);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarUsuario", "Web");
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

        public ENT_Usuario obtenerCredenciales(string email)
        {
            ENT_Usuario oEnt_Usuario = new ENT_Usuario();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_obtenerCredenciales";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
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
                    oEnt_Usuario.Clave = DrSql.GetString(DrSql.GetOrdinal("Clave"));
                    oEnt_Usuario.Correo = DrSql.GetString(DrSql.GetOrdinal("Correo"));
                    oEnt_Usuario.Nombre = DrSql.GetString(DrSql.GetOrdinal("Nombre"));
                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Usuario;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "obtenerCredenciales", "Web");
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
