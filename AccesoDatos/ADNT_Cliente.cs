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
    public class ADNT_Cliente
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;


        public List<ENT_Cliente> ListarClientesXLab(string LaboratorioCod)
        {
            List<ENT_Cliente> oLista = new List<ENT_Cliente>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarClientes";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@LaboratorioCod", SqlDbType.VarChar).Value = LaboratorioCod;

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
                    ENT_Cliente oEnt_Cliente = new ENT_Cliente();
                    oEnt_Cliente.NombreCliente = DrSql.GetString(DrSql.GetOrdinal("NombreCliente"));
                    oEnt_Cliente.ClienteID = DrSql.GetInt32(DrSql.GetOrdinal("ClienteID"));
                    oLista.Add(oEnt_Cliente);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarClientesXLab", "Web");
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
        
        public List<ENT_Cliente> ListarDatosCliente(int ClienteID)
        {
            List<ENT_Cliente> oLista = new List<ENT_Cliente>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarDatosCliente";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = ClienteID;

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
                    ENT_Cliente oEnt_Cliente = new ENT_Cliente();
                    oEnt_Cliente.NombreCliente = DrSql.GetString(DrSql.GetOrdinal("NombreCliente"));
                    oEnt_Cliente.Ruc = DrSql.GetString(DrSql.GetOrdinal("Ruc"));
                    oEnt_Cliente.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Cliente.Pais = DrSql.GetString(DrSql.GetOrdinal("Pais"));
                    oEnt_Cliente.Ciudad = DrSql.GetString(DrSql.GetOrdinal("Ciudad"));
                    oEnt_Cliente.Direccion = DrSql.GetString(DrSql.GetOrdinal("Direccion"));
                    oEnt_Cliente.Contacto = DrSql.GetString(DrSql.GetOrdinal("Contacto"));

                    oLista.Add(oEnt_Cliente);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarDatosCliente", "Web");
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

        public List<ENT_Cliente> ListarClientesXEmpresa(int UsuarioID)
        {
            List<ENT_Cliente> oLista = new List<ENT_Cliente>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarClientesXEmpresa";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = UsuarioID;

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
                    ENT_Cliente oEnt_Cliente = new ENT_Cliente();
                    oEnt_Cliente.NombreCliente = DrSql.GetString(DrSql.GetOrdinal("NombreCliente"));
                    oEnt_Cliente.ClienteID = DrSql.GetInt32(DrSql.GetOrdinal("ClienteID"));
                    oLista.Add(oEnt_Cliente);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarClientesXEmpresa", "Web");
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
