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
    public class ADT_RegistroTemporal
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public bool InsertarRegistroTemporal(ENT_RegistroTemporal oEntidad, ref string Serial, ref int ExisteDominio)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_InsertarRegistroTemporal";
            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = oEntidad.RazonSocial;
            connect.MyCmd.Parameters.Add("@Dominio", SqlDbType.VarChar).Value = oEntidad.Dominio;
            connect.MyCmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oEntidad.Correo;
            connect.MyCmd.Parameters.Add("@Serial", SqlDbType.VarChar, 36).Direction = ParameterDirection.Output;
            connect.MyCmd.Parameters.Add("@ExisteDominio", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();
                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();
                Serial = connect.MyCmd.Parameters["@Serial"].Value.ToString();
                string ExisteDominiooo = connect.MyCmd.Parameters["@ExisteDominio"].Value.ToString();
                ExisteDominio = Int32.Parse(ExisteDominiooo);
                TransSql.Commit();
                return true;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "InsertarRegistroTemporal", "Web");
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
