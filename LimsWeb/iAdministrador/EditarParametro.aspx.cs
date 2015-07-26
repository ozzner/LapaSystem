using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using Entidades;
using LogicaNegocio;

namespace LimsWeb.iAdministrador
{
    public partial class EditarParametro : System.Web.UI.Page
    {
        LN_UnidadMedida oLN_UM = new LN_UnidadMedida();
        LN_TipoParametro oLN_TipoParametro = new LN_TipoParametro();
        LN_Formula oLN_Formula = new LN_Formula();
        LN_Parametro oLN_Parametro = new LN_Parametro();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblParametro.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString() + "/" + Session["NomParametro"].ToString();
             
                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
            }
            catch
            {
                Response.Redirect("../iRegistro/Login.aspx");
                return;
            }

            //FillData();

            //cMuestras.Series["Series1"].ChartType = SeriesChartType.Line;
            //cMuestras.Series["Series2"].ChartType = SeriesChartType.Line;

               List<ENT_Parametro> oEnt_Parametro = new List<ENT_Parametro>();
               oEnt_Parametro=oLN_Parametro.ObtenerDatosMuestraParametro(Session["ProdParaCod"].ToString());

               cMuestras.DataSource = oEnt_Parametro;
               cMuestras.Series[0].XValueMember = "CodigoMuestra";
               cMuestras.Series[0].YValueMembers = "Resultado";


               cMuestras.Series[1].XValueMember = "CodigoMuestra";
               cMuestras.Series[1].YValueMembers = "Resultado";
               cMuestras.Series[1].IsValueShownAsLabel = true;
               cMuestras.Titles.Add(Session["NomParametro"].ToString());
               
               cMuestras.DataBind();
        }

        //private void FillData()
        //{
        //    double plotY = 50.0;
        //    double plotY2 = 200.0;
        //    if (cMuestras.Series["Series1"].Points.Count > 0)
        //    {
        //        plotY = cMuestras.Series["Series1"].Points[cMuestras.Series["Series1"].Points.Count - 1].YValues[0];
        //        plotY2 = cMuestras.Series["Series2"].Points[cMuestras.Series["Series1"].Points.Count - 1].YValues[0];
        //    }
        //    Random random = new Random();
        //    for (int pointIndex = 0; pointIndex < 20000; pointIndex++)
        //    {
        //        plotY = plotY + (float)(random.NextDouble() * 10.0 - 5.0);
        //        cMuestras.Series["Series1"].Points.AddY(plotY);

        //        plotY2 = plotY2 + (float)(random.NextDouble() * 10.0 - 5.0);
        //        cMuestras.Series["Series2"].Points.AddY(plotY2);

        //    }
        //}
    }
}



