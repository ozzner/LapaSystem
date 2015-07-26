using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Entidades;
using System.Globalization;

namespace AccesoDatos
{
    public class ADNT_Muestra
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_Muestra> ObtenerMuestras(int MuestraID)
        {
            List<ENT_Muestra> oLista = new List<ENT_Muestra>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerMuestras";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@MuestraID", SqlDbType.VarChar, 10).Value = MuestraID;

            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                // Parametro,prioridad, resultado, fec_i,fech_f, estado, operdador
                while (DrSql.Read())
                {
                    ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                    oEnt_Muestra.MuestraID = MuestraID;
                    oEnt_Muestra.MuestraDetalleID = DrSql.GetInt32(DrSql.GetOrdinal("MuestraDetalleID"));
                    oEnt_Muestra.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomParametro"));
                    oEnt_Muestra.Prioridad = DrSql.GetString(DrSql.GetOrdinal("Prioridad"));
                    oEnt_Muestra.ResultadoAux = DrSql.GetString(DrSql.GetOrdinal("Resultado"));
                    oEnt_Muestra.FechaInicio = (DrSql.GetValue(DrSql.GetOrdinal("FechaInicio")).Equals(DBNull.Value) ||
                        DrSql.GetValue(DrSql.GetOrdinal("FechaInicio")).Equals(null)) ? oEnt_Muestra.FechaTerminado = "" :
                        oEnt_Muestra.FechaTerminado = DrSql.GetDateTime(DrSql.GetOrdinal("FechaInicio")).
                        ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    oEnt_Muestra.FechaFin = (DrSql.GetValue(DrSql.GetOrdinal("FechaFin")).Equals(DBNull.Value) ||
                        DrSql.GetValue(DrSql.GetOrdinal("FechaFin")).Equals(null)) ? oEnt_Muestra.FechaTerminado = "" :
                        oEnt_Muestra.FechaTerminado = DrSql.GetDateTime(DrSql.GetOrdinal("FechaFin")).
                        ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    oEnt_Muestra.NomEstado = DrSql.GetString(DrSql.GetOrdinal("NomEstado"));
                    oEnt_Muestra.Nombre = DrSql.GetString(DrSql.GetOrdinal("NomUsuario"));
                    oEnt_Muestra.UnidadMedida = DrSql.GetString(DrSql.GetOrdinal("UnidadMedida"));

                    oLista.Add(oEnt_Muestra);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerMuestras", "Web");
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

        public  ENT_Atributo ListarOpciones(int MuestraDetalleID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarOpciones";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@MuestraDetalleID", SqlDbType.Int).Value = MuestraDetalleID;

            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                // Parametro,prioridad, resultado, fec_i,fech_f, estado, operdador
                ENT_Atributo oEnt_Atributo = new ENT_Atributo();
                while (DrSql.Read())
                {

                    oEnt_Atributo.Opciones = DrSql.GetString(DrSql.GetOrdinal("Opciones"));
   
                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Atributo;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarOpciones", "Web");
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

        public List<ENT_Muestra> ObtenerMuestrasAttr(int MuestraID)
        {
            List<ENT_Muestra> oLista = new List<ENT_Muestra>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerMuestrasAttr";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@MuestraID", SqlDbType.VarChar, 10).Value = MuestraID;

            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                // Parametro,prioridad, resultado, fec_i,fech_f, estado, operdador
                while (DrSql.Read())
                {
                    ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                    oEnt_Muestra.MuestraID = MuestraID;
                    oEnt_Muestra.MuestraDetalleID = DrSql.GetInt32(DrSql.GetOrdinal("MuestraDetalleID"));
                    oEnt_Muestra.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomAtributo"));
                    oEnt_Muestra.Prioridad = DrSql.GetString(DrSql.GetOrdinal("Prioridad"));
                    oEnt_Muestra.ResultadoAux = DrSql.GetString(DrSql.GetOrdinal("Resultado"));
                    oEnt_Muestra.FechaInicio = (DrSql.GetValue(DrSql.GetOrdinal("FechaInicio")).Equals(DBNull.Value) ||
                        DrSql.GetValue(DrSql.GetOrdinal("FechaInicio")).Equals(null)) ? oEnt_Muestra.FechaTerminado = "" :
                        oEnt_Muestra.FechaTerminado = DrSql.GetDateTime(DrSql.GetOrdinal("FechaInicio")).
                        ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    oEnt_Muestra.FechaFin = (DrSql.GetValue(DrSql.GetOrdinal("FechaFin")).Equals(DBNull.Value) ||
                        DrSql.GetValue(DrSql.GetOrdinal("FechaFin")).Equals(null)) ? oEnt_Muestra.FechaTerminado = "" :
                        oEnt_Muestra.FechaTerminado = DrSql.GetDateTime(DrSql.GetOrdinal("FechaFin")).
                        ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    oEnt_Muestra.NomEstado = DrSql.GetString(DrSql.GetOrdinal("NomEstado"));
                    oEnt_Muestra.Nombre = DrSql.GetString(DrSql.GetOrdinal("NomUsuario"));
                    oEnt_Muestra.UnidadMedida = DrSql.GetString(DrSql.GetOrdinal("UnidadMedida"));

                    oLista.Add(oEnt_Muestra);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerMuestrasAttr", "Web");
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

        public List<ENT_Muestra> ListarMuestrasPendientes(int UsuarioID)
        {
            List<ENT_Muestra> oLista = new List<ENT_Muestra>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarMuestrasPendientes";
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
                // Parametro,prioridad, resultado, fec_i,fech_f, estado, operdador
                while (DrSql.Read())
                {
                    ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                    oEnt_Muestra.MuestraDetalleID = DrSql.GetInt32(DrSql.GetOrdinal("MuestraDetalleID"));
                    oEnt_Muestra.CodigoMuestra = DrSql.GetString(DrSql.GetOrdinal("CodigoMuestra"));
                    oEnt_Muestra.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomParametro"));
                    oEnt_Muestra.FechaRegistro = DrSql.GetDateTime(DrSql.GetOrdinal("FechaRegistro"));
                    oEnt_Muestra.NomProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));
                    oEnt_Muestra.Prioridad = DrSql.GetString(DrSql.GetOrdinal("Prioridad"));
                    oLista.Add(oEnt_Muestra);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarMuestrasPendientes", "Web");
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



        public List<ENT_Muestra> ListarMuestrasPendientesAttr(int UsuarioID)
        {
            List<ENT_Muestra> oLista = new List<ENT_Muestra>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarMuestrasPendientesAttr";
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
                // Parametro,prioridad, resultado, fec_i,fech_f, estado, operdador
                while (DrSql.Read())
                {
                    ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                    oEnt_Muestra.MuestraDetalleID = DrSql.GetInt32(DrSql.GetOrdinal("MuestraDetalleID"));
                    oEnt_Muestra.CodigoMuestra = DrSql.GetString(DrSql.GetOrdinal("CodigoMuestra"));
                    oEnt_Muestra.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomAtributo"));
                    oEnt_Muestra.FechaRegistro = DrSql.GetDateTime(DrSql.GetOrdinal("FechaRegistro"));
                    oEnt_Muestra.NomProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));
                    oEnt_Muestra.Prioridad = DrSql.GetString(DrSql.GetOrdinal("Prioridad"));
                    oLista.Add(oEnt_Muestra);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarMuestrasPendientesAttr", "Web");
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


        public List<ENT_Muestra> ListarTerminadoAttr(int UsuarioID)
        {
            List<ENT_Muestra> oLista = new List<ENT_Muestra>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarTerminadoAttr";
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
                // Parametro,prioridad, resultado, fec_i,fech_f, estado, operdador
                while (DrSql.Read())
                {
                    ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                    oEnt_Muestra.MuestraDetalleID = DrSql.GetInt32(DrSql.GetOrdinal("MuestraDetalleID"));
                    oEnt_Muestra.CodigoMuestra = DrSql.GetString(DrSql.GetOrdinal("CodigoMuestra"));
                    oEnt_Muestra.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomAtributo"));
                    oEnt_Muestra.Resultado = DrSql.GetString(DrSql.GetOrdinal("Resultado"));
                    oEnt_Muestra.FechaFinDt = DrSql.GetDateTime(DrSql.GetOrdinal("FechaFin"));
                    oEnt_Muestra.UnidadMedida = DrSql.GetString(DrSql.GetOrdinal("UnidadMedida"));
                    oEnt_Muestra.NomProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));
                    oLista.Add(oEnt_Muestra);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarMuestrasPendientes", "Web");
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

        public List<ENT_Muestra> ListarTerminado(int UsuarioID)
        {
            List<ENT_Muestra> oLista = new List<ENT_Muestra>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarTerminado";
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
                // Parametro,prioridad, resultado, fec_i,fech_f, estado, operdador
                while (DrSql.Read())
                {
                    ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                    oEnt_Muestra.MuestraDetalleID = DrSql.GetInt32(DrSql.GetOrdinal("MuestraDetalleID"));
                    oEnt_Muestra.CodigoMuestra = DrSql.GetString(DrSql.GetOrdinal("CodigoMuestra"));
                    oEnt_Muestra.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomParametro"));
                    oEnt_Muestra.Resultado = DrSql.GetString(DrSql.GetOrdinal("Resultado"));
                    oEnt_Muestra.FechaFinDt = DrSql.GetDateTime(DrSql.GetOrdinal("FechaFin"));
                    oEnt_Muestra.UnidadMedida = DrSql.GetString(DrSql.GetOrdinal("UnidadMedida"));
                    oEnt_Muestra.NomProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));
                    oLista.Add(oEnt_Muestra);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarMuestrasPendientes", "Web");
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



        public List<ENT_Muestra> ListarEnProceso(int UsuarioID)
        {
            List<ENT_Muestra> oLista = new List<ENT_Muestra>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarEnProceso";
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
                // Parametro,prioridad, resultado, fec_i,fech_f, estado, operdador
                while (DrSql.Read())
                {
                    ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                    oEnt_Muestra.MuestraDetalleID = DrSql.GetInt32(DrSql.GetOrdinal("MuestraDetalleID"));
                    oEnt_Muestra.CodigoMuestra = DrSql.GetString(DrSql.GetOrdinal("CodigoMuestra"));
                    oEnt_Muestra.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomParametro"));
                    oEnt_Muestra.TipoParametroID = DrSql.GetInt32(DrSql.GetOrdinal("TipoParametroID"));
                    oEnt_Muestra.Formula = DrSql.GetString(DrSql.GetOrdinal("Formula"));
                    oEnt_Muestra.FechaFinEstimado = DrSql.GetDateTime(DrSql.GetOrdinal("FechaFinEstimado"));
                    oLista.Add(oEnt_Muestra);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarMuestrasPendientes", "Web");
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



        public List<ENT_Muestra> ListarEnProcesoAttr(int UsuarioID)
        {
            List<ENT_Muestra> oLista = new List<ENT_Muestra>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarEnProcesoAttr";
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
                // Parametro,prioridad, resultado, fec_i,fech_f, estado, operdador
                while (DrSql.Read())
                {
                    ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                    oEnt_Muestra.MuestraDetalleID = DrSql.GetInt32(DrSql.GetOrdinal("MuestraDetalleID"));
                    oEnt_Muestra.CodigoMuestra = DrSql.GetString(DrSql.GetOrdinal("CodigoMuestra"));
                    oEnt_Muestra.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomAtributo"));
                    oLista.Add(oEnt_Muestra);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarEnProcesoAttr", "Web");
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

        public List<ENT_Muestra> ListarMuestras(string ProdLabCod)
        {
            List<ENT_Muestra> oLista = new List<ENT_Muestra>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarMuestras";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@ProdLabCod", SqlDbType.VarChar, 10).Value = ProdLabCod;
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
                    var val = DrSql.GetValue(DrSql.GetOrdinal("FechaTerminado"));
                    var val2 = "";
                    ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                    oEnt_Muestra.MuestraID = DrSql.GetInt32(DrSql.GetOrdinal("MuestraID"));
                    oEnt_Muestra.CodigoMuestra = DrSql.GetString(DrSql.GetOrdinal("CodigoMuestra"));
                    oEnt_Muestra.FechaRegistro = DrSql.GetDateTime(DrSql.GetOrdinal("FechaRegistro"));
                    oEnt_Muestra.NomEstado = DrSql.GetString(DrSql.GetOrdinal("EstadoMuestra"));
                    oEnt_Muestra.CreadoPor = DrSql.GetString(DrSql.GetOrdinal("CreadoPor"));
                    oEnt_Muestra.FechaTerminado = (DrSql.GetValue(DrSql.GetOrdinal("FechaTerminado")).Equals(DBNull.Value) ||
                        DrSql.GetValue(DrSql.GetOrdinal("FechaTerminado")).Equals(null)) ? oEnt_Muestra.FechaTerminado = "" :
                        oEnt_Muestra.FechaTerminado = DrSql.GetDateTime(DrSql.GetOrdinal("FechaTerminado")).
                        ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    oLista.Add(oEnt_Muestra);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerMuestras", "Web");
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
