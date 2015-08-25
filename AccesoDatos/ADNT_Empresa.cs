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
    public class ADNT_Empresa
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        //public List<ENT_Empresa> ListaA() {

        //    List<ENT_Empresa> oLista = new List<ENT_Empresa>();
        //    string strSQLconnection = "Data Source=dbServer;Initial Catalog=testDB;Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.CommandText = "Nombre_Procedimiento_Almacenado";
        //    sqlCommand.Parameters.Clear();
        //    sqlCommand.Parameters.Add("@Valor", SqlDbType.VarChar).Value = ruc;

        //    sqlConnection.Open();
        //    SqlDataReader DrSql = default(SqlDataReader);
        //    DrSql = sqlCommand.ExecuteReader();
        //    sqlConnection.Close();

        //    while (DrSql.Read())
        //    {
        //        ENT_Empresa oEnt_Empresa = new ENT_Empresa();
        //        oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
        //        oEnt_Empresa.EmpresaCod = DrSql.GetString(DrSql.GetOrdinal("EmpresaCod"));
        //        oLista.Add(oEnt_Empresa);
        //    }

        //    DrSql.Close();

        //}

        
        public List<ENT_Empresa> ListarEmpresa(string ruc) {
            List<ENT_Empresa> oLista = new List<ENT_Empresa>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarEmpresa";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RUC", SqlDbType.VarChar).Value = ruc;
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
                    ENT_Empresa oEnt_Empresa = new ENT_Empresa();
                    oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Empresa.EmpresaCod = DrSql.GetString(DrSql.GetOrdinal("EmpresaCod"));
                    oLista.Add(oEnt_Empresa);
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
        
        public ENT_Empresa ListarInfoEmpresa(string ruc)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarInfoEmpresa";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RUC", SqlDbType.VarChar).Value = ruc;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Empresa oEnt_Empresa = new ENT_Empresa();
                while (DrSql.Read())
                {
                    
                    oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Empresa.NomPais = DrSql.GetString(DrSql.GetOrdinal("PaisCod"));
                    oEnt_Empresa.NomCiudad = DrSql.GetString(DrSql.GetOrdinal("Ciudad"));
                    oEnt_Empresa.NomRubro = DrSql.GetString(DrSql.GetOrdinal("Rubro"));
                    oEnt_Empresa.segmento = DrSql.GetString(DrSql.GetOrdinal("Segmento"));
                    oEnt_Empresa.Direccion = DrSql.GetString(DrSql.GetOrdinal("Direccion"));
                    oEnt_Empresa.Dominio = DrSql.GetString(DrSql.GetOrdinal("Dominio"));
                    oEnt_Empresa.Servicio = DrSql.GetBoolean(DrSql.GetOrdinal("Servicio"));
                    oEnt_Empresa.TipoUsoID = DrSql.GetInt32(DrSql.GetOrdinal("Paquete"));
                    var p = DrSql.GetSqlValue(DrSql.GetOrdinal("PathLogo"));
                    var c = DBNull.Value;
                    oEnt_Empresa.PathLogo = (DrSql.IsDBNull(DrSql.GetOrdinal("PathLogo"))) ? "" : 
                                            DrSql.GetString(DrSql.GetOrdinal("PathLogo"));
                
                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Empresa;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarInfoEmpresa", "Web");
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

        //Procedure PUB-Raíz
        public ENT_Empresa ListarPublicidadRaíz(string ruc)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarPubRaiz";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RUC", SqlDbType.VarChar).Value = ruc;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Empresa oEnt_Empresa = new ENT_Empresa();
                while (DrSql.Read())
                {

                    oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Empresa.enlace = DrSql.GetString(DrSql.GetOrdinal("URL"));
                    oEnt_Empresa.imagen = DrSql.GetString(DrSql.GetOrdinal("Imagen"));

                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Empresa;
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


        //Procedure PUB-INICIO 1
        public ENT_Empresa ListarPubInicio1(string ruc)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarPubInicio1";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RUC", SqlDbType.VarChar).Value = ruc;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Empresa oEnt_Empresa = new ENT_Empresa();
                while (DrSql.Read())
                {

                    oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Empresa.enlace = DrSql.GetString(DrSql.GetOrdinal("URL"));
                    oEnt_Empresa.imagen = DrSql.GetString(DrSql.GetOrdinal("Imagen"));

                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Empresa;
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


        //Procedure PUB-INICIO 2
        public ENT_Empresa ListarPubInicio2(string ruc)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarPubInicio2";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RUC", SqlDbType.VarChar).Value = ruc;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Empresa oEnt_Empresa = new ENT_Empresa();
                while (DrSql.Read())
                {

                    oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Empresa.enlace = DrSql.GetString(DrSql.GetOrdinal("URL"));
                    oEnt_Empresa.imagen = DrSql.GetString(DrSql.GetOrdinal("Imagen"));

                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Empresa;
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


        //Procedure PUB-REP PARAM EST
        public ENT_Empresa ListarPubRepParamEst(string ruc)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarPubRepParamEst";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RUC", SqlDbType.VarChar).Value = ruc;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Empresa oEnt_Empresa = new ENT_Empresa();
                while (DrSql.Read())
                {

                    oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Empresa.enlace = DrSql.GetString(DrSql.GetOrdinal("URL"));
                    oEnt_Empresa.imagen = DrSql.GetString(DrSql.GetOrdinal("Imagen"));

                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Empresa;
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


        //Procedure PUB-REP ATRIB EST
        public ENT_Empresa ListarPubRepAtribEst(string ruc)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarPubRepAtribEst";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RUC", SqlDbType.VarChar).Value = ruc;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Empresa oEnt_Empresa = new ENT_Empresa();
                while (DrSql.Read())
                {

                    oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Empresa.enlace = DrSql.GetString(DrSql.GetOrdinal("URL"));
                    oEnt_Empresa.imagen = DrSql.GetString(DrSql.GetOrdinal("Imagen"));

                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Empresa;
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


        //Procedure PUB-REP PARAM STAT
        public ENT_Empresa ListarPubRepParamStat(string ruc)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarPubRepParamStat";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RUC", SqlDbType.VarChar).Value = ruc;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Empresa oEnt_Empresa = new ENT_Empresa();
                while (DrSql.Read())
                {

                    oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Empresa.enlace = DrSql.GetString(DrSql.GetOrdinal("URL"));
                    oEnt_Empresa.imagen = DrSql.GetString(DrSql.GetOrdinal("Imagen"));

                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Empresa;
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


        //Procedure PUB-REP ATRIB STAT
        public ENT_Empresa ListarPubRepAtribStat(string ruc)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarPubRepAtribStat";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RUC", SqlDbType.VarChar).Value = ruc;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Empresa oEnt_Empresa = new ENT_Empresa();
                while (DrSql.Read())
                {

                    oEnt_Empresa.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_Empresa.enlace = DrSql.GetString(DrSql.GetOrdinal("URL"));
                    oEnt_Empresa.imagen = DrSql.GetString(DrSql.GetOrdinal("Imagen"));

                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Empresa;
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

        public int VerificarRestriccion(int usuarioId, string tipo, int valor)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_VerificarRestriccion";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = usuarioId;
            connect.MyCmd.Parameters.Add("@TipoAVerificar", SqlDbType.VarChar).Value = tipo;
            connect.MyCmd.Parameters.Add("@Valor1", SqlDbType.Int).Value = valor;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                int resultado = -1;
                while (DrSql.Read())
                {
                    resultado = DrSql.GetInt32(DrSql.GetOrdinal("total"));
                }

                DrSql.Close();

                TransSql.Commit();
                return resultado;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarLaboratorio", "Web");
                enterror.RegisterLog();
                TransSql.Rollback();

                return -1;

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
