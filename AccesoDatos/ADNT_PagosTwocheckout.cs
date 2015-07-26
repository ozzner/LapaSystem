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
    public class ADNT_PagosTwocheckout
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;

        public int storePaymentTwocheckout(ENT_PagosTwocheckout twocheckout, int userId, int plan, ref int process)
        {
            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "LAPA_SP_GrabarPagoTwoCheckOut";

            connect.MyCmd.Parameters.Clear();
            connect.MyCmd.Parameters.Add("@LicenciaID", SqlDbType.Int).Value = twocheckout.invoiceId;
            connect.MyCmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = twocheckout.quantity;
            connect.MyCmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = twocheckout.amount;
            connect.MyCmd.Parameters.Add("@NumberOrder", SqlDbType.BigInt).Value = twocheckout.numberOrder;
            connect.MyCmd.Parameters.Add("@CodPaquete", SqlDbType.VarChar, 100).Value = twocheckout.packageCod;
            connect.MyCmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = twocheckout.description;
            connect.MyCmd.Parameters.Add("@usuarioID", SqlDbType.Int).Value = userId;
            connect.MyCmd.Parameters.Add("@paquete", SqlDbType.Int).Value = plan;
            connect.MyCmd.Parameters.Add("@process", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                if (connect.MyConn.State == ConnectionState.Closed)
                    connect.MyConn.Open();

                connect.MyCmd.Connection = connect.MyConn;
                TransSql = connect.MyConn.BeginTransaction();
                connect.MyCmd.Transaction = TransSql;
                connect.MyCmd.ExecuteNonQuery();

                string p = connect.MyCmd.Parameters["@process"].Value.ToString();
                process = Int32.Parse(p);
                TransSql.Commit();
                return process;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "GuardarPago", "Web");
                enterror.RegisterLog();
                TransSql.Rollback();
                return -1;
            }
            finally
            {
                TransSql.Dispose();
            }
        }
    }
}