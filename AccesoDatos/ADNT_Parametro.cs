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
    public class ADNT_Parametro
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;



        public ENT_ProductoParametro ObtenerDatosParametro(string ProdParaCod)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerDatosParametro";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdParaCod", SqlDbType.VarChar).Value = ProdParaCod;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_ProductoParametro oEnt_Parametro = new ENT_ProductoParametro();
                while (DrSql.Read())
                {
                    oEnt_Parametro.TiempoEstimado = DrSql.GetString(DrSql.GetOrdinal("TiempoEstimado"));
                    oEnt_Parametro.UnidadMedidaID = DrSql.GetInt32(DrSql.GetOrdinal("UnidadMedidaID"));
                    oEnt_Parametro.TipoParametroID = DrSql.GetInt32(DrSql.GetOrdinal("TipoParametroID"));
                    oEnt_Parametro.FormulaID = DrSql.GetInt32(DrSql.GetOrdinal("FormulaID"));
                    oEnt_Parametro.Calculado = DrSql.GetString(DrSql.GetOrdinal("Calculado"));
                    oEnt_Parametro.MinAdvertencia = DrSql.GetDecimal(DrSql.GetOrdinal("MinAdvertencia"));
                    oEnt_Parametro.MaxAdvertencia = DrSql.GetDecimal(DrSql.GetOrdinal("MaxAdvertencia"));
                    oEnt_Parametro.Promedio = DrSql.GetDecimal(DrSql.GetOrdinal("Promedio"));
                    oEnt_Parametro.MinAccion = DrSql.GetDecimal(DrSql.GetOrdinal("MinAccion"));
                    oEnt_Parametro.MaxAccion = DrSql.GetDecimal(DrSql.GetOrdinal("MaxAccion"));
                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Parametro;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerDatosParametro", "Web");
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

        public List<ENT_Parametro> ListarParametroXEquipo(int EquipoID)
        {
            List<ENT_Parametro> oListaa = new List<ENT_Parametro>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarParametroXEquipo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@EquipoID", SqlDbType.VarChar).Value = EquipoID;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                int posNomParametro = DrSql.GetOrdinal("NomParametro");
                int posNomParEqpID = DrSql.GetOrdinal("ParEqpID");

                while (DrSql.Read())
                {
                    ENT_Parametro oEnt_Parametro = new ENT_Parametro();
                    oEnt_Parametro.NomParametro = DrSql.GetString(posNomParametro);
                    oEnt_Parametro.ParEqpID = DrSql.GetInt32(posNomParEqpID);

                    oListaa.Add(oEnt_Parametro);
                }

                DrSql.Close();

                TransSql.Commit();
                return oListaa;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerDatosParametro", "Web");
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









        public ENT_ProductoParametro ObtenerDatosParam(int ProdParaID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerDatosParam";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdParaID", SqlDbType.Int).Value = ProdParaID;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_ProductoParametro oEnt_Parametro = new ENT_ProductoParametro();
                while (DrSql.Read())
                {
                    oEnt_Parametro.TiempoEstimado = DrSql.GetString(DrSql.GetOrdinal("TiempoEstimado"));
                    oEnt_Parametro.UnidadMedida = DrSql.GetString(DrSql.GetOrdinal("UnidadMedida"));
                    oEnt_Parametro.UnidadMedidaID = DrSql.GetInt32(DrSql.GetOrdinal("UnidadMedidaID"));
                    oEnt_Parametro.TipoParametroID = DrSql.GetInt32(DrSql.GetOrdinal("TipoParametroID"));
                    oEnt_Parametro.FormulaID = DrSql.GetInt32(DrSql.GetOrdinal("FormulaID"));
                    oEnt_Parametro.Calculado = DrSql.GetString(DrSql.GetOrdinal("Calculado"));
                    oEnt_Parametro.MinAdvertencia = DrSql.GetDecimal(DrSql.GetOrdinal("MinAdvertencia"));
                    oEnt_Parametro.MaxAdvertencia = DrSql.GetDecimal(DrSql.GetOrdinal("MaxAdvertencia"));
                    oEnt_Parametro.Promedio = DrSql.GetDecimal(DrSql.GetOrdinal("Promedio"));
                    oEnt_Parametro.MinAccion = DrSql.GetDecimal(DrSql.GetOrdinal("MinAccion"));
                    oEnt_Parametro.MaxAccion = DrSql.GetDecimal(DrSql.GetOrdinal("MaxAccion"));
                    oEnt_Parametro.NumDecimales = DrSql.GetInt32(DrSql.GetOrdinal("NumDecimales"));
                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Parametro;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerDatosParam", "Web");
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




        public List<ENT_Parametro> ObtenerDatosMuestraParametro(string ProdParaCod)
        {
            List<ENT_Parametro> oLista = new List<ENT_Parametro>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerDatosMuestraParametro";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdParaCod", SqlDbType.VarChar).Value = ProdParaCod;
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
                    ENT_Parametro oEnt_Parametro = new ENT_Parametro();
                    oEnt_Parametro.CodigoMuestra = DrSql.GetString(DrSql.GetOrdinal("CodigoMuestra"));
                    string resultadoStr = DrSql.GetString(DrSql.GetOrdinal("Resultado"));
                    var separator = new NumberFormatInfo();
                    separator.NumberDecimalSeparator = ".";
                    oEnt_Parametro.Resultado = decimal.Parse(resultadoStr, separator);
                    oEnt_Parametro.MaxAdvertencia = DrSql.GetDecimal(DrSql.GetOrdinal("MaxAdvertencia"));
                    oEnt_Parametro.MaxAccion = DrSql.GetDecimal(DrSql.GetOrdinal("MaxAccion"));
                    oEnt_Parametro.Promedio = DrSql.GetDecimal(DrSql.GetOrdinal("Promedio"));
                    oEnt_Parametro.MinAdvertencia = DrSql.GetDecimal(DrSql.GetOrdinal("MinAdvertencia"));
                    oEnt_Parametro.MinAccion = DrSql.GetDecimal(DrSql.GetOrdinal("MinAccion"));
                    //      oEnt_Parametro.Valor = 20;
                    oLista.Add(oEnt_Parametro);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerDatosParametro", "Web");
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

        public ENT_Parametro ObtenerLab(string ProdParaCod)
        {

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ObtenerHerenciaParametro";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdParaCod", SqlDbType.VarChar).Value = ProdParaCod;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_Parametro oEnt_Laboratorio = new ENT_Parametro();
                while (DrSql.Read())
                {
                    oEnt_Laboratorio.NomProducto = DrSql.GetString(DrSql.GetOrdinal("NomProducto"));
                    oEnt_Laboratorio.NomLaboratorio = DrSql.GetString(DrSql.GetOrdinal("NomLaboratorio"));
                }

                DrSql.Close();

                TransSql.Commit();
                return oEnt_Laboratorio;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ObtenerHerenciaParametro", "Web");
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

        public List<ENT_Parametro> ListarParametro(int UsuarioID)
        {
            List<ENT_Parametro> oLista = new List<ENT_Parametro>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarParametro";
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
                    ENT_Parametro oEnt_Parametro = new ENT_Parametro();
                    oEnt_Parametro.ParametroID = DrSql.GetInt32(DrSql.GetOrdinal("ParametroID"));
                    oEnt_Parametro.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomParametro"));
                    oEnt_Parametro.Metodologia = DrSql.GetString(DrSql.GetOrdinal("Metodologia"));
                    oEnt_Parametro.Descripcion = DrSql.GetString(DrSql.GetOrdinal("Descripcion"));
                    oLista.Add(oEnt_Parametro);
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



        public List<ENT_ProductoParametro> ListarParametroXLab(string ProdLabCod)
        {
            List<ENT_ProductoParametro> oLista = new List<ENT_ProductoParametro>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarProdPara";
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
                    ENT_ProductoParametro oEnt_ProductoParametro = new ENT_ProductoParametro();
                    oEnt_ProductoParametro.ProdParaID = DrSql.GetInt32(DrSql.GetOrdinal("ProdParaID"));
                    oEnt_ProductoParametro.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomParametro"));
                    oEnt_ProductoParametro.ProdParaCod = DrSql.GetString(DrSql.GetOrdinal("ProdParaCod"));
                    oEnt_ProductoParametro.FlagVgrafico = DrSql.GetString(DrSql.GetOrdinal("FlagVgrafico"));
                    oEnt_ProductoParametro.UnidadMedida = (DrSql.GetValue(DrSql.GetOrdinal("UnidadMedida")).Equals(null) || DrSql.GetValue(DrSql.GetOrdinal("UnidadMedida")).Equals(DBNull.Value))?"":DrSql.GetString(DrSql.GetOrdinal("UnidadMedida"));
                    oLista.Add(oEnt_ProductoParametro);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarProdPara", "Web");
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



        public List<ENT_ProductoAtributo> ListarAtributoXLab(string ProdLabCod)
        {
            List<ENT_ProductoAtributo> oLista = new List<ENT_ProductoAtributo>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarAtributoXLab";
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
                    ENT_ProductoAtributo oEnt_ProductoAtributo = new ENT_ProductoAtributo();
                    oEnt_ProductoAtributo.NomAtributo = DrSql.GetString(DrSql.GetOrdinal("NomAtributo"));
                    oLista.Add(oEnt_ProductoAtributo);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarProdPara", "Web");
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





        public List<ENT_Cliente> ListarClientesLab(string LaboratorioCod)
        {
            List<ENT_Cliente> oLista = new List<ENT_Cliente>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarClientesLab";
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

                int posNomCliente = DrSql.GetOrdinal("NombreCliente");
                int posRazonSocial = DrSql.GetOrdinal("RazonSocial");
                int posRuc = DrSql.GetOrdinal("Ruc");
                int posNombrePais = DrSql.GetOrdinal("NombrePais");
                int posNombreCiudad = DrSql.GetOrdinal("NombreCiudad");

                while (DrSql.Read())
                {
                    ENT_Cliente oEnt_Cliente = new ENT_Cliente();
                    oEnt_Cliente.NombreCliente = DrSql.GetString(posNomCliente);
                    oEnt_Cliente.RazonSocial = DrSql.GetString(posRazonSocial);
                    oEnt_Cliente.Ruc = DrSql.GetString(posRuc);
                    oEnt_Cliente.NombrePais = DrSql.GetString(posNombrePais);
                    oEnt_Cliente.NombreCiudad = DrSql.GetString(posNombreCiudad);
                    oLista.Add(oEnt_Cliente);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarProdPara", "Web");
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





        public List<ENT_ProductoParametro> ListarParametrosLab(string LaboratorioCod)
        {
            List<ENT_ProductoParametro> oLista = new List<ENT_ProductoParametro>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarParametrosLab";
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
                    ENT_ProductoParametro oEnt_ProductoParametro = new ENT_ProductoParametro();
                    oEnt_ProductoParametro.NomParametro = DrSql.GetString(DrSql.GetOrdinal("NomParametro"));
                    oEnt_ProductoParametro.NomUM = (DrSql.GetValue(DrSql.GetOrdinal("UnidadMedida")).Equals(null) || DrSql.GetValue(DrSql.GetOrdinal("UnidadMedida")).Equals(DBNull.Value)) ? "" : DrSql.GetString(DrSql.GetOrdinal("UnidadMedida"));
                    oEnt_ProductoParametro.NomProducto = DrSql.GetString(DrSql.GetOrdinal("NombreProducto"));

                    oLista.Add(oEnt_ProductoParametro);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarProdPara", "Web");
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
