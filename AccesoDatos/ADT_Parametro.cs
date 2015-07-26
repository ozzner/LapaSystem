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
    public class ADT_Parametro
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public bool CompletarDatosParametro(ENT_ProductoParametro oEnt_Parametro)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_CompletarDatosParametro";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@TiempoEstimado", SqlDbType.VarChar).Value = oEnt_Parametro.TiempoEstimado;
            connect.MyCmd.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = oEnt_Parametro.UnidadMedida;
            connect.MyCmd.Parameters.Add("@UnidadMedidaID", SqlDbType.Int).Value = oEnt_Parametro.UnidadMedidaID;
            connect.MyCmd.Parameters.Add("@TipoParametroID", SqlDbType.Int).Value = oEnt_Parametro.TipoParametroID;

            switch (oEnt_Parametro.TipoParametroID)
            {
                case 1: //Manual
                    connect.MyCmd.Parameters.Add("@FormulaID", SqlDbType.Int).Value = 1;
                    connect.MyCmd.Parameters.Add("@Calculado", SqlDbType.VarChar).Value = "";
                    break;
                case 2: //Calculado
                    connect.MyCmd.Parameters.Add("@FormulaID", SqlDbType.Int).Value = 1;
                    connect.MyCmd.Parameters.Add("@Calculado", SqlDbType.VarChar).Value = oEnt_Parametro.Calculado;
                    break;
                case 3: //Formula Definida
                    connect.MyCmd.Parameters.Add("@FormulaID", SqlDbType.Int).Value = oEnt_Parametro.FormulaID;
                    connect.MyCmd.Parameters.Add("@Calculado", SqlDbType.VarChar).Value = "";
                    break;
            }

            //connect.MyCmd.Parameters.Add("@FormulaID", SqlDbType.Int).Value = oEnt_Parametro.FormulaID;
            //connect.MyCmd.Parameters.Add("@Calculado", SqlDbType.VarChar).Value = oEnt_Parametro.Calculado;
            connect.MyCmd.Parameters.Add("@MinAdvertencia", SqlDbType.Decimal).Value = oEnt_Parametro.MinAdvertencia;
            connect.MyCmd.Parameters.Add("@MaxAdvertencia", SqlDbType.Decimal).Value = oEnt_Parametro.MaxAdvertencia;
            connect.MyCmd.Parameters.Add("@Promedio", SqlDbType.Decimal).Value = oEnt_Parametro.Promedio;
            connect.MyCmd.Parameters.Add("@MinAccion", SqlDbType.Decimal).Value = oEnt_Parametro.MinAccion;
            connect.MyCmd.Parameters.Add("@MaxAccion", SqlDbType.Decimal).Value = oEnt_Parametro.MaxAccion;
            connect.MyCmd.Parameters.Add("@ProdParaID", SqlDbType.VarChar).Value = oEnt_Parametro.ProdParaID;
            connect.MyCmd.Parameters.Add("@NumDecimales", SqlDbType.VarChar).Value = oEnt_Parametro.NumDecimales;

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
                enterror = new ENT_Error(ex.Message, "CompletarDatosParametro", "Web");
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


        public bool InsertarParametroEquipo(int ParametroID, int EquipoID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarParametroEquipo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ParametroID", SqlDbType.Int).Value = ParametroID;
            connect.MyCmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = EquipoID;

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
                enterror = new ENT_Error(ex.Message, "CompletarDatosParametro", "Web");
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
        public bool InsertarParametro(ENT_Parametro oEnt_Parametro)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarParametro";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@NomParametro", SqlDbType.VarChar).Value = oEnt_Parametro.NomParametro;
            connect.MyCmd.Parameters.Add("@Metodologia", SqlDbType.VarChar).Value = oEnt_Parametro.Metodologia;
            connect.MyCmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oEnt_Parametro.Descripcion;
            connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = oEnt_Parametro.UsuarioID;
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
                enterror = new ENT_Error(ex.Message, "InsertarParametro", "Web");
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

        public bool QuitarParametroEquipo(int ParEqpID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_QuitarParametroEquipo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ParEqpID", SqlDbType.VarChar).Value = ParEqpID;
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
                enterror = new ENT_Error(ex.Message, "QuitarParametroEquipo", "Web");
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
        public bool AsociarParametro(int ParametroID, string ProdLabID, int Tipo, ref int resultado)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_AsociarParametro";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ParametroID", SqlDbType.Int).Value = ParametroID;
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
                enterror = new ENT_Error(ex.Message, "AsociarParametro", "Web");
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



        public bool QuitarProdPara(int ProdParaID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_QuitarProdPara";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ProdParaID", SqlDbType.VarChar).Value = ProdParaID;
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
                enterror = new ENT_Error(ex.Message, "QuitarProdPara", "Web");
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

        public bool ActualizarParametro(ENT_Parametro oEnt_Parametro)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ActualizarParametro";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ParametroID", SqlDbType.Int).Value = oEnt_Parametro.ParametroID;
            connect.MyCmd.Parameters.Add("@NomParametro", SqlDbType.VarChar).Value = oEnt_Parametro.NomParametro;
            connect.MyCmd.Parameters.Add("@Metodologia", SqlDbType.VarChar).Value = oEnt_Parametro.Metodologia;
            connect.MyCmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oEnt_Parametro.Descripcion;

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
                enterror = new ENT_Error(ex.Message, "ActualizarParametro", "Web");
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



        public bool EliminarParametro(string ParametroID)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_EliminarParametro";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@ParametroID", SqlDbType.Int).Value = ParametroID;
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
                enterror = new ENT_Error(ex.Message, "EliminarParametro", "Web");
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

        public bool DeshabilitaFlProdParam(string ProdLabCod)
        {
            {
                SqlTransaction TransSql = default(SqlTransaction);
                connect.MyConn = new SqlConnection(connect.strCxn());
                connect.MyCmd.CommandType = CommandType.StoredProcedure;
                connect.MyCmd.CommandText = "SLW_SP_DeshabilitaFlProdParam";
                connect.MyCmd.Parameters.Clear();
                connect.MyCmd.Parameters.Add("@ProdLabCod", SqlDbType.VarChar).Value = ProdLabCod;

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
                    enterror = new ENT_Error(ex.Message, "DeshabilitaFlProdParam", "Web");
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

        public bool ActualizarProdParam(string ProdLabCod, string param)
        {
            {
                SqlTransaction TransSql = default(SqlTransaction);
                connect.MyConn = new SqlConnection(connect.strCxn());
                connect.MyCmd.CommandType = CommandType.StoredProcedure;
                connect.MyCmd.CommandText = "SLW_SP_ActualizarProdParam";
                connect.MyCmd.Parameters.Clear();
                connect.MyCmd.Parameters.Add("@ProdLabCod", SqlDbType.VarChar).Value = ProdLabCod;
                connect.MyCmd.Parameters.Add("@Param", SqlDbType.VarChar).Value = param;

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
                    enterror = new ENT_Error(ex.Message, "ActualizarProdParam", "Web");
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
}
