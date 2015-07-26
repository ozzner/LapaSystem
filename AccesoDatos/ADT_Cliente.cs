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
    public class ADT_Cliente
    {

        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public bool InsertarCliente(string NomCliente, int UsuarioID)
        {
            {
                SqlTransaction TransSql = default(SqlTransaction);
                connect.MyConn = new SqlConnection(connect.strCxn());
                connect.MyCmd.CommandType = CommandType.StoredProcedure;
                connect.MyCmd.CommandText = "SLW_SP_InsertarClientess";
                connect.MyCmd.Parameters.Clear();
                connect.MyCmd.Parameters.Add("@NomCliente", SqlDbType.VarChar).Value = NomCliente;
                connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = UsuarioID;

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
                    enterror = new ENT_Error(ex.Message, "InsertarCliente", "Web");
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

        public bool ActualizarContacto(string cadenaXML, int ClienteID)
        {
            {
                SqlTransaction TransSql = default(SqlTransaction);
                connect.MyConn = new SqlConnection(connect.strCxn());
                connect.MyCmd.CommandType = CommandType.StoredProcedure;
                connect.MyCmd.CommandText = "SLW_SP_ActualizarContacto";
                connect.MyCmd.Parameters.Clear();
                connect.MyCmd.Parameters.Add("@cadenaXML", SqlDbType.VarChar).Value = cadenaXML;
                connect.MyCmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = ClienteID;

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
                    enterror = new ENT_Error(ex.Message, "ActualizarContacto", "Web");
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

        public bool EliminarCliente(int ClienteID)
        {
            {
                SqlTransaction TransSql = default(SqlTransaction);
                connect.MyConn = new SqlConnection(connect.strCxn());
                connect.MyCmd.CommandType = CommandType.StoredProcedure;
                connect.MyCmd.CommandText = "SLW_SP_EliminarCliente";
                connect.MyCmd.Parameters.Clear();
                connect.MyCmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = ClienteID;

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
                    enterror = new ENT_Error(ex.Message, "SLW_SP_EliminarCliente", "Web");
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


        public bool ActualizarDatos(ENT_Cliente oEnt_Cliente)
        {
            {
                SqlTransaction TransSql = default(SqlTransaction);
                connect.MyConn = new SqlConnection(connect.strCxn());
                connect.MyCmd.CommandType = CommandType.StoredProcedure;
                connect.MyCmd.CommandText = "SLW_SP_ActualizarDatosCliente";
                connect.MyCmd.Parameters.Clear();
                connect.MyCmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oEnt_Cliente.NombreCliente;
                connect.MyCmd.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = oEnt_Cliente.Ruc;
                connect.MyCmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = oEnt_Cliente.RazonSocial;
                connect.MyCmd.Parameters.Add("@Pais", SqlDbType.VarChar).Value = oEnt_Cliente.Pais;
                connect.MyCmd.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = oEnt_Cliente.Ciudad;
                connect.MyCmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = oEnt_Cliente.Direccion;
                connect.MyCmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = oEnt_Cliente.ClienteID;

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
                    enterror = new ENT_Error(ex.Message, "ActualizarDatosCliente", "Web");
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
    
        public ENT_Cliente ObtenerCliente(string ProdLabCod)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerClientePC";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdLabCod", SqlDbType.VarChar).Value = ProdLabCod;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Cliente oEnt_Cliente = new ENT_Cliente();
                while (DrSql.Read())
                {
                    oEnt_Cliente.NombreCliente = DrSql.GetString(DrSql.GetOrdinal("nombrecliente"));
                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Cliente;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerClientePC", "Web");
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
