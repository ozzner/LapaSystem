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
    public class ADT_Atributo
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;


        public bool GuardarCambios(List<ENT_ProductoAtributo> oEnt_ProdAttr, int ProdAttrID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_GuardarCambiosAttr";
            connect.MyCmd.Parameters.Clear();

            string cadenaXml = "<Atributo>";

            foreach (ENT_ProductoAtributo oProdAttr in oEnt_ProdAttr) {
                cadenaXml = cadenaXml + "<Opcion>" + oProdAttr.Opciones.ToString()+"</Opcion>";
            }

            cadenaXml = cadenaXml + "</Atributo>";

            connect.MyCmd.Parameters.Add("@cadenaXml", SqlDbType.VarChar).Value = cadenaXml;
            connect.MyCmd.Parameters.Add("@ProdAtriID", SqlDbType.Int).Value = ProdAttrID;
            
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
                enterror = new ENT_Error(ex.Message, "AsociarAtributo", "Web");
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


        public bool AsociarAtributo(int AtributoID, string ProdLabID, int Tipo, ref int resultado)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_AsociarAtributo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@AtributoID", SqlDbType.Int).Value = AtributoID;
            connect.MyCmd.Parameters.Add("@ProdLabCod", SqlDbType.VarChar, 10).Value = ProdLabID;
            connect.MyCmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
            connect.MyCmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                TransSql.Commit();
                resultado = Convert.ToInt32(connect.MyCmd.Parameters["@Resultado"].Value);

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "AsociarAtributo", "Web");
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


        public bool QuitarAtributo(int ProdAtriID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_QuitarAtributo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdAtriID", SqlDbType.Int).Value = ProdAtriID;
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
                enterror = new ENT_Error(ex.Message, "QuitarAtributo", "Web");
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


        public bool InsertarAtributo(ENT_Atributo oEnt_Atributo)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarAtributo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@NomAtributo", SqlDbType.VarChar).Value = oEnt_Atributo.NomAtributo;
            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = oEnt_Atributo.UsuarioID;
            
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
                enterror = new ENT_Error(ex.Message, "InsertarAtributo", "Web");
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


        public bool ActualizarAtributo(ENT_Atributo oEnt_Atributo) {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ActualizarAtributo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@NomAtributo", SqlDbType.VarChar).Value = oEnt_Atributo.NomAtributo;
            connect.MyCmd.Parameters.Add("@AtributoID", SqlDbType.Int).Value = oEnt_Atributo.AtributoID;

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
                enterror = new ENT_Error(ex.Message, "ActualizarAtributo", "Web");
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




        public bool EliminarAtributo(int AtributoID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_EliminarAtributo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@AtributoID", SqlDbType.Int).Value = AtributoID;

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
                enterror = new ENT_Error(ex.Message, "EliminarAtributo", "Web");
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
