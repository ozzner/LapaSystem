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
    public class ADNT_Laboratorio
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_Laboratorio> ListarLaboratorio(int UsuarioID)
        {
            List<ENT_Laboratorio> oLista = new List<ENT_Laboratorio>(UsuarioID);

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarLaboratorio";
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
                    ENT_Laboratorio oEnt_Laboratorio = new ENT_Laboratorio();
                    oEnt_Laboratorio.NomLaboratorio = DrSql.GetString(DrSql.GetOrdinal("NomLaboratorio"));
                    oEnt_Laboratorio.LaboratorioID = DrSql.GetInt32(DrSql.GetOrdinal("LaboratorioID"));
                    oEnt_Laboratorio.LaboratorioCod = DrSql.GetString(DrSql.GetOrdinal("LaboratorioCod"));
                    oEnt_Laboratorio.Ubicacion  = DrSql.GetString(DrSql.GetOrdinal("Ubicacion"));
                    oEnt_Laboratorio.FechaRegistro = DrSql.GetDateTime(DrSql.GetOrdinal("FechaRegistro"));
                    oLista.Add(oEnt_Laboratorio);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarLaboratorio", "Web");
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


        public List<ENT_Laboratorio> ListarLaboratorioXEmpresa(int UsuarioID)
        {
            List<ENT_Laboratorio> oLista = new List<ENT_Laboratorio>(UsuarioID);

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarLaboratorioXEmpresa";
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
                    ENT_Laboratorio oEnt_Laboratorio = new ENT_Laboratorio();
                    oEnt_Laboratorio.NomLaboratorio = DrSql.GetString(DrSql.GetOrdinal("NomLaboratorio"));
                    oEnt_Laboratorio.LaboratorioID = DrSql.GetInt32(DrSql.GetOrdinal("LaboratorioID"));
                    oEnt_Laboratorio.LaboratorioCod = DrSql.GetString(DrSql.GetOrdinal("LaboratorioCod"));
                    oEnt_Laboratorio.Ubicacion = DrSql.GetString(DrSql.GetOrdinal("Ubicacion"));
                    oEnt_Laboratorio.NomUsuario = DrSql.GetString(DrSql.GetOrdinal("Nombre"));
                    oLista.Add(oEnt_Laboratorio);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarLaboratorio", "Web");
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
        

        
        public ENT_Laboratorio ObtenerLab(string ProdLabCod)
        {
            
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerLab";
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
                ENT_Laboratorio oEnt_Laboratorio = new ENT_Laboratorio();
                while (DrSql.Read())
                {
                    oEnt_Laboratorio.NomLaboratorio = DrSql.GetString(DrSql.GetOrdinal("NomLaboratorio"));
                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Laboratorio;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerLab", "Web");
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

        public string ObtenerSupervisor(int labID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerSupervisor";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@LaboratorioID", SqlDbType.Int).Value = labID;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                string nomSupervisor = string.Empty;
                while (DrSql.Read())
                {
                    nomSupervisor = DrSql.GetString(DrSql.GetOrdinal("Nombre"));
                }

                DrSql.Close();

                TransSql.Commit();
                return nomSupervisor;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerSupervisor", "Web");
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
