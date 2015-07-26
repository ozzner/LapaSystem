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
    public class ADNT_Atributo
    {

        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_Atributo> ListarAtributo(int UsuarioID)
        {
            List<ENT_Atributo> oLista = new List<ENT_Atributo>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarAtributo";
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
                    ENT_Atributo oEnt_Atributo = new ENT_Atributo();
                    oEnt_Atributo.AtributoID = DrSql.GetInt32(DrSql.GetOrdinal("AtributoID"));
                    oEnt_Atributo.NomAtributo = DrSql.GetString(DrSql.GetOrdinal("NomAtributo"));
                    oEnt_Atributo.UsuarioID = DrSql.GetInt32(DrSql.GetOrdinal("UsuarioID"));
                    oLista.Add(oEnt_Atributo);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListAtributo", "Web");
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

        public List<ENT_Atributo> ListarAtributosLab(string LaboratorioCod)
        {
            List<ENT_Atributo> oLista = new List<ENT_Atributo>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarAtributosLab";
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
                    ENT_Atributo oEnt_Atributo = new ENT_Atributo();
                    //oEnt_Atributo.AtributoID = DrSql.GetInt32(DrSql.GetOrdinal("ProdAtriID"));
                    oEnt_Atributo.NomAtributo = DrSql.GetString(DrSql.GetOrdinal("NomAtributo"));
                    oLista.Add(oEnt_Atributo);
                }

                DrSql.Close();
                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListAtributo", "Web");
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


        public List<ENT_ProductoAtributo> ListarProdAttr(int AtributoID)
        {
            List<ENT_ProductoAtributo> oLista = new List<ENT_ProductoAtributo>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarProdAttr";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdAtriID", SqlDbType.Int).Value = AtributoID;

            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();

                int posOpciones = DrSql.GetOrdinal("Opciones");

                while (DrSql.Read())
                {
                    ENT_ProductoAtributo oEnt_Atributo = new ENT_ProductoAtributo();
                    oEnt_Atributo.Opciones = DrSql.GetString(posOpciones);
                    oLista.Add(oEnt_Atributo);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListAtributo", "Web");
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
        public List<ENT_Atributo> ListarAtributoXLab(string ProdLabCod)
        {
            List<ENT_Atributo> oLista = new List<ENT_Atributo>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarAtributoXLab";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdLabCod", SqlDbType.VarChar,10).Value = ProdLabCod;

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
                    ENT_Atributo oEnt_Atributo = new ENT_Atributo();
                    oEnt_Atributo.AtributoID = DrSql.GetInt32(DrSql.GetOrdinal("ProdAtriID"));
                    oEnt_Atributo.NomAtributo = DrSql.GetString(DrSql.GetOrdinal("NomAtributo"));
                    oLista.Add(oEnt_Atributo);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarAtributoXLab", "Web");
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


        //public List<ENT_Producto> ListarAtributoXLabServicio(string ClienteID)
        //{
        //    List<ENT_Atributo> oLista = new List<ENT_Atributo>();

        //    SqlTransaction TransSql = default(SqlTransaction);
        //    connect.MyConn = new SqlConnection(connect.strCxn());
        //    connect.MyCmd.CommandType = CommandType.StoredProcedure;
        //    connect.MyCmd.CommandText = "SLW_SP_ListarAtributoXLabServicio";
        //    connect.MyCmd.Parameters.Clear();

        //    connect.MyCmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = Int32.Parse(ClienteID);

        //    try
        //    {
        //        if (connect.MyConn.State == ConnectionState.Closed)
        //            connect.MyConn.Open();
        //        TransSql = connect.MyConn.BeginTransaction();
        //        connect.MyCmd.Transaction = TransSql;
        //        connect.MyCmd.Connection = connect.MyConn;
        //        SqlDataReader DrSql = default(SqlDataReader);
        //        DrSql = connect.MyCmd.ExecuteReader();

        //        while (DrSql.Read())
        //        {
        //            ENT_Atributo oEnt_Producto = new ENT_Atributo();
        //            oEnt_Producto.NomAtributo = DrSql.GetString(DrSql.GetOrdinal("NomAtributo"));
        //            //oEnt_Producto.ProductoID = DrSql.GetInt32(DrSql.GetOrdinal("ProductoID"));
        //            //oEnt_Producto.DescProducto = DrSql.GetString(DrSql.GetOrdinal("DescProducto"));
        //            //oEnt_Producto.ProdLabID = DrSql.GetInt32(DrSql.GetOrdinal("ProdLabID"));
        //            oEnt_Producto.AtributoID = DrSql.GetInt32(DrSql.GetOrdinal("AtributoID"));

        //            oLista.Add(oEnt_Producto);
        //        }

        //        DrSql.Close();

        //        TransSql.Commit();
        //        return oLista;
        //    }
        //    catch (Exception ex)
        //    {
        //        enterror = new ENT_Error(ex.Message, "ListarAtributoXLabServicio", "Web");
        //        enterror.RegisterLog();
        //        TransSql.Rollback();

        //        return null;

        //    }
        //    finally
        //    {
        //        TransSql.Dispose();
        //        connect.MyCmd.Dispose();
        //        if (connect.MyConn.State == ConnectionState.Open)
        //            connect.MyConn.Close();
        //        connect.MyConn.Dispose();

        //    }

        //}



       
    }
}
