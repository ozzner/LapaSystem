using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AccesoDatos
{
    public class Conexion
    {
        private SqlConnection _myConn;
        private SqlCommand _myCmd;

        public SqlConnection MyConn
        {
            get { return _myConn; }
            set { _myConn = value; }
        }

        public SqlCommand MyCmd
        {
            get { return _myCmd; }
            set { _myCmd = value; }
        }

        public string strCxn()
        {
            string cxn = "Data Source='JULIO-PC\\SQLEXPRESS';Initial Catalog=SistemaWeb;User ID=sa;Password=Wasitec2014";// ConnectionString.ConnectionStrings["conexionLocal"].ConnectionString;
            //string cxn = "Data Source='RSANTILLANC-PC\\SQLEXPRESS';Initial Catalog=SistemaWeb;User ID=sa;password=b14nc4";// ConnectionString.ConnectionStrings["conexionLocal"].ConnectionString;
            return cxn;


        }

        public Conexion()
        {
            Parametros();
        }

        private void Parametros()
        {
            try
            {
                MyConn = new SqlConnection(strCxn());
                MyConn.Open();
                MyCmd = MyConn.CreateCommand();
                MyCmd.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (MyConn.State != ConnectionState.Closed)
                {
                    MyConn.Close();
                }
                MyCmd.Dispose();
                MyConn.Dispose();
            }
        }
    }
}
