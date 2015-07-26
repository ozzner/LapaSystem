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
    public class ADNT_Producto
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_Producto> ListarProducto(int UsuarioID)
        {
            List<ENT_Producto> oLista = new List<ENT_Producto>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarProducto";
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
                    ENT_Producto oEnt_Producto = new ENT_Producto();
                    oEnt_Producto.NombreProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));
                    oEnt_Producto.DescProducto = DrSql.GetString(DrSql.GetOrdinal("DescProducto"));
                    oEnt_Producto.ProductoID = DrSql.GetInt32(DrSql.GetOrdinal("ProductoID"));
                    oLista.Add(oEnt_Producto);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListProducto", "Web");
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





        public List<ENT_Producto> ListarProductoXLab(string LaboratorioCod)
        {
            List<ENT_Producto> oLista = new List<ENT_Producto>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarProductoXLab";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@LaboratorioCod", SqlDbType.VarChar,10).Value = LaboratorioCod;

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
                    ENT_Producto oEnt_Producto = new ENT_Producto();
                    oEnt_Producto.NombreProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));
                    oEnt_Producto.ProductoID = DrSql.GetInt32(DrSql.GetOrdinal("ProductoID"));
                    oEnt_Producto.DescProducto = DrSql.GetString(DrSql.GetOrdinal("DescProducto"));
                    oEnt_Producto.ProdLabID = DrSql.GetInt32(DrSql.GetOrdinal("ProdLabID"));
                    oEnt_Producto.ProdLabCod = DrSql.GetString(DrSql.GetOrdinal("ProdLabCod"));
                    oEnt_Producto.NomCliente = DrSql.GetString(DrSql.GetOrdinal("NomCliente"));
                    oLista.Add(oEnt_Producto);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListProducto", "Web");
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

        public List<ENT_Producto> ListarProductoXLabID(string LaboratorioID)
        {
            List<ENT_Producto> oLista = new List<ENT_Producto>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarProductoXLabID";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@LaboratorioID", SqlDbType.VarChar, 10).Value = LaboratorioID;

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
                    ENT_Producto oEnt_Producto = new ENT_Producto();
                    oEnt_Producto.NombreProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));
                    oEnt_Producto.ProductoID = DrSql.GetInt32(DrSql.GetOrdinal("ProductoID"));
                    oEnt_Producto.DescProducto = DrSql.GetString(DrSql.GetOrdinal("DescProducto"));
                    oEnt_Producto.ProdLabID = DrSql.GetInt32(DrSql.GetOrdinal("ProdLabID"));
                    oEnt_Producto.ProdLabCod = DrSql.GetString(DrSql.GetOrdinal("ProdLabCod"));
                    oEnt_Producto.NomCliente = DrSql.GetString(DrSql.GetOrdinal("NomCliente"));
                    oLista.Add(oEnt_Producto);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListProducto", "Web");
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




        public List<ENT_Producto> ListarProductoXLabServicio(string ClienteID)
        {
            List<ENT_Producto> oLista = new List<ENT_Producto>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarProductoXLabServicio";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = Int32.Parse(ClienteID) ;

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
                    ENT_Producto oEnt_Producto = new ENT_Producto();
                    oEnt_Producto.NombreProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));
                    //oEnt_Producto.ProductoID = DrSql.GetInt32(DrSql.GetOrdinal("ProductoID"));
                    //oEnt_Producto.DescProducto = DrSql.GetString(DrSql.GetOrdinal("DescProducto"));
                    //oEnt_Producto.ProdLabID = DrSql.GetInt32(DrSql.GetOrdinal("ProdLabID"));
                    oEnt_Producto.ProdLabCod = DrSql.GetString(DrSql.GetOrdinal("ProdLabCod"));

                    oLista.Add(oEnt_Producto);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarProductoXLabServicio", "Web");
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


        //Metodo Agregado
        public List<ENT_Producto> ListarProductoLab(string LaboratorioCod)
        {
            List<ENT_Producto> oLista = new List<ENT_Producto>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarProductoLab";
            connect.MyCmd.Parameters.Clear();

            connect.MyCmd.Parameters.Add("@LaboratorioCod", SqlDbType.VarChar, 10).Value = LaboratorioCod;

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
                    ENT_Producto oEnt_Producto = new ENT_Producto();
                    oEnt_Producto.NombreProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));
                    oEnt_Producto.DescProducto = DrSql.GetString(DrSql.GetOrdinal("DescProducto"));
                    oLista.Add(oEnt_Producto);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarProductoLab", "Web");
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
