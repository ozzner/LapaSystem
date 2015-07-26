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
    public class ADNT_RegistroTemporal
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public List<ENT_RegistroTemporal> VerificarSerial(string serial, ref int resultado) 
        {
            List<ENT_RegistroTemporal> oLista = new List<ENT_RegistroTemporal>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_VerificarSerial";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@Serial", SqlDbType.VarChar,36).Value = serial;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.Connection = connect.MyConn;
                SqlDataReader DrSql = default(SqlDataReader);
                DrSql = connect.MyCmd.ExecuteReader();
                ENT_RegistroTemporal oEnt_RegTemp = new ENT_RegistroTemporal();
                while (DrSql.Read())
                {
                    oEnt_RegTemp.RazonSocial = DrSql.GetString(DrSql.GetOrdinal("RazonSocial"));
                    oEnt_RegTemp.Dominio = DrSql.GetString(DrSql.GetOrdinal("Dominio"));
                    oEnt_RegTemp.Correo = DrSql.GetString(DrSql.GetOrdinal("Correo"));
                    oLista.Add(oEnt_RegTemp);
                }
                
                DrSql.Close();
                resultado = 0;
                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "InsertarRegistroTemporal", "Web");
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

        public int VerificarCorreo(string regcorreo, ref int resultado)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ValidarCorreo";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RegCorreo", SqlDbType.VarChar, 36).Value = regcorreo;
            connect.MyCmd.Parameters.Add("@existe", SqlDbType.Int, 36).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                string p = connect.MyCmd.Parameters["@existe"].Value.ToString();
                resultado = Int32.Parse(p);
                TransSql.Commit();
                return resultado;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "VerificarCorreo", "Web");
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
