using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Entidades;
using System.IO;
using System.Xml;
using System.Data.SqlTypes;

namespace AccesoDatos
{
    public class ADT_Muestra
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public bool InsertarMuestra(int UsuarioID, string CodigoMuestra, string ProdLabCod, List<ENT_Muestra> oLista_Muestra, List<ENT_Muestra> oLista_MuestraAttr)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarMuestra";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = UsuarioID;
            connect.MyCmd.Parameters.Add("@CodigoMuestra", SqlDbType.VarChar, 200).Value = CodigoMuestra;
            connect.MyCmd.Parameters.Add("@ProdLabCod", SqlDbType.VarChar, 10).Value = ProdLabCod;

            MemoryStream objMS = new MemoryStream();
            using (XmlWriter XmlWriter = XmlWriter.Create(objMS))
            {
                XmlWriter.WriteStartElement("r");
                XmlWriter.WriteStartElement("dc");
                if (oLista_Muestra != null)
                {
                    foreach (ENT_Muestra ENT_TxD in oLista_Muestra)
                    {
                        XmlWriter.WriteStartElement("d");
                        XmlWriter.WriteAttributeString("pp", ENT_TxD.NomParametro.ToString());
                        XmlWriter.WriteAttributeString("pr", ENT_TxD.Prioridad.ToString());
                        XmlWriter.WriteEndElement();
                    }
                    XmlWriter.WriteEndElement();
                    XmlWriter.WriteEndElement();
                    XmlWriter.Close();
                    objMS.Position = 0;
                }
            }

            connect.MyCmd.Parameters.Add("@doc", SqlDbType.Xml).Value = new SqlXml(objMS);


            MemoryStream objMSAttr = new MemoryStream();
            using (XmlWriter XmlWriter = XmlWriter.Create(objMSAttr))
            {
                XmlWriter.WriteStartElement("r");
                XmlWriter.WriteStartElement("dc");
                if (oLista_Muestra != null)
                {
                    foreach (ENT_Muestra ENT_TxD in oLista_MuestraAttr)
                    {
                        XmlWriter.WriteStartElement("d");
                        XmlWriter.WriteAttributeString("pp", ENT_TxD.NomParametro.ToString());
                        XmlWriter.WriteAttributeString("pr", ENT_TxD.Prioridad.ToString());
                        XmlWriter.WriteEndElement();
                    }
                    XmlWriter.WriteEndElement();
                    XmlWriter.WriteEndElement();
                    XmlWriter.Close();
                    objMS.Position = 0;
                }
            }

            connect.MyCmd.Parameters.Add("@docAttr", SqlDbType.Xml).Value = new SqlXml(objMSAttr);

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
                enterror = new ENT_Error(ex.Message, "InsertarMuestra", "Web");
                enterror.RegisterLog();
                //   mensajeError = ex.Message.ToString();
                return false;
            }
            finally
            {
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();
            }
        }

        public bool InsertarResultadoAttr(string result, int MuestraDetalleID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarResultadoAttr";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@Resultado", SqlDbType.VarChar,100).Value = result;
            connect.MyCmd.Parameters.Add("@MuestraDetalleID", SqlDbType.Int).Value = MuestraDetalleID;

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
                enterror = new ENT_Error(ex.Message, "InsertarResultadoAttr", "Web");
                enterror.RegisterLog();
                //   mensajeError = ex.Message.ToString();
                return false;
            }
            finally
            {
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();
            }
        }



        public bool RegistrarUsoEquipo(int EquipoID, int MuestraDetalleID)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_RegistrarUsoEquipo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = EquipoID;
            connect.MyCmd.Parameters.Add("@MuestraDetalleID", SqlDbType.Int).Value = MuestraDetalleID;

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
                enterror = new ENT_Error(ex.Message, "InsertarMuestra", "Web");
                enterror.RegisterLog();
                //   mensajeError = ex.Message.ToString();
                return false;
            }
            finally
            {
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();
            }
        }

        public bool RegistrarEquiposUsados(string listaEquipos, int MuestraDetalleID)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_RegistrarEquiposUsados";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ListaEquipos", SqlDbType.VarChar).Value = listaEquipos;
            connect.MyCmd.Parameters.Add("@MuestraDetalleID", SqlDbType.Int).Value = MuestraDetalleID;

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
                enterror = new ENT_Error(ex.Message, "InsertarMuestra", "Web");
                enterror.RegisterLog();
                //   mensajeError = ex.Message.ToString();
                return false;
            }
            finally
            {
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();
            }
        }

        //public bool InsertarResultado(decimal result, int MuestraDetalleID)
        public bool InsertarResultado(string result, int MuestraDetalleID)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarResultado";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@Resultado", SqlDbType.VarChar).Value = result;
            connect.MyCmd.Parameters.Add("@MuestraDetalleID", SqlDbType.Int).Value = MuestraDetalleID;

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
                enterror = new ENT_Error(ex.Message, "InsertarResultado", "Web");
                enterror.RegisterLog();
                //   mensajeError = ex.Message.ToString();
                return false;
            }
            finally
            {
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();
            }
        }

        public bool PasarAEnProceso(int MuestraDetalleID, int UsuarioID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_PasarAEnProceso";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@MuestraDetalleID", SqlDbType.Int).Value = MuestraDetalleID;
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
                enterror = new ENT_Error(ex.Message, "PasarAEnProceso", "Web");
                enterror.RegisterLog();
                //   mensajeError = ex.Message.ToString();
                return false;
            }
            finally
            {
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();
            }
        }

        public bool VolverAEnCola(int MuestraDetalleID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_VolverAEnCola";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@MuestraDetalleID", SqlDbType.Int).Value = MuestraDetalleID;

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
                enterror = new ENT_Error(ex.Message, "VolverAEnCola", "Web");
                enterror.RegisterLog();
                return false;
            }
            finally
            {
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();
            }
        }

        public bool EliminarMuestraDetalle(int MuestraDetalleID)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_EliminarMuestraDetalle";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@MuestraDetalleID", SqlDbType.Int).Value = MuestraDetalleID;

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
                enterror = new ENT_Error(ex.Message, "EliminarMuestraDetalle", "Web");
                enterror.RegisterLog();
                //   mensajeError = ex.Message.ToString();
                return false;
            }
            finally
            {
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();
            }
        }



        public bool EliminarMuestraCabecera(int MuestraID)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_EliminarMuestraCabecera";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@MuestraID", SqlDbType.Int).Value = MuestraID;

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
                enterror = new ENT_Error(ex.Message, "EliminarMuestraCabecera", "Web");
                enterror.RegisterLog();
                //   mensajeError = ex.Message.ToString();
                return false;
            }
            finally
            {
                connect.MyCmd.Dispose();
                if (connect.MyConn.State == ConnectionState.Open)
                    connect.MyConn.Close();
                connect.MyConn.Dispose();
            }
        }
    }
}
