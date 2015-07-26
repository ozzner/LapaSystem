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
    public class ADT_Producto
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public bool AsociarProducto(int ProductoID, string LaboratorioCod, int Tipo, ref int Resultado)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_AsociarProducto";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProductoID", SqlDbType.Int).Value = ProductoID;
            connect.MyCmd.Parameters.Add("@LaboratorioCod", SqlDbType.VarChar,10).Value = LaboratorioCod;
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
                Resultado = Convert.ToInt32(connect.MyCmd.Parameters["@Resultado"].Value);

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "AsociarProducto", "Web");
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




        public bool AsociarProductoCliente(int ProductoID,int ClienteID, string LaboratorioCod)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_AsociarProductoCliente";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProductoID", SqlDbType.Int).Value = ProductoID;
            connect.MyCmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = ClienteID;
            connect.MyCmd.Parameters.Add("@LaboratorioCod", SqlDbType.VarChar,10).Value = LaboratorioCod;
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
                enterror = new ENT_Error(ex.Message, "AsociarProductoCliente", "Web");
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


        public bool QuitarProdLab(int ProdLabID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_QuitarProdLab";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdLabID", SqlDbType.Int).Value = ProdLabID;
            //connect.MyCmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                TransSql.Commit();
              //  Resultado = Convert.ToInt32(connect.MyCmd.Parameters["@Resultado"].Value);

                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "AsociarProducto", "Web");
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





        public bool InsertarProducto(ENT_Producto oEnt_Producto)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarProducto";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = oEnt_Producto.NombreProducto;
            connect.MyCmd.Parameters.Add("@DescProducto", SqlDbType.VarChar).Value = oEnt_Producto.DescProducto;
            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = oEnt_Producto.UsuarioID;
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
                enterror = new ENT_Error(ex.Message, "InsertarProducto", "Web");
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


        public bool ActualizarProducto(ENT_Producto oEnt_Producto)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ActualizarProducto";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProductoID", SqlDbType.VarChar).Value = oEnt_Producto.ProductoID;
            connect.MyCmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = oEnt_Producto.NombreProducto;
            connect.MyCmd.Parameters.Add("@DescProducto", SqlDbType.VarChar).Value = oEnt_Producto.DescProducto;
            
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
                enterror = new ENT_Error(ex.Message, "InsertarProducto", "Web");
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



        public bool EliminarProducto(string ProductoID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_EliminarProducto";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProductoID", SqlDbType.VarChar).Value = ProductoID;
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
                enterror = new ENT_Error(ex.Message, "EliminarProducto", "Web");
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
