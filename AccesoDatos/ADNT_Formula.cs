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
    public class ADNT_Formula
    {
        public Conexion connect = new Conexion();
        public ENT_Error enterror;


        public List<ENT_Formula> ListarFormula()
        {
            List<ENT_Formula> oLista = new List<ENT_Formula>();

            SqlTransaction TransSql = default(SqlTransaction);
            connect.MyConn = new SqlConnection(connect.strCxn());
            connect.MyCmd.CommandType = CommandType.StoredProcedure;
            connect.MyCmd.CommandText = "SLW_SP_ListarFormula";
            connect.MyCmd.Parameters.Clear();

            //  connect.MyCmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = UsuarioID;


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
                    ENT_Formula oEnt_Formula = new ENT_Formula();
                    oEnt_Formula.FormulaID = DrSql.GetInt32(DrSql.GetOrdinal("FormulaID"));
                    oEnt_Formula.NombreFormula = DrSql.GetString(DrSql.GetOrdinal("NombreFormula"));
                    oLista.Add(oEnt_Formula);
                }

                DrSql.Close();

                TransSql.Commit();
                return oLista;
            }
            catch (Exception ex)
            {
                enterror = new ENT_Error(ex.Message, "ListarFormula", "Web");
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
