using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Entidades;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace LimsWeb.iAdministrador
{
    public partial class Producto : System.Web.UI.Page
    {
        LN_Producto oLN_Producto = new LN_Producto();
        LN_Parametro oLN_Parametro = new LN_Parametro();
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["ProdLabID"] = "1";
            try
            {
                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
            }
            catch
            {
                Response.Redirect("../iRegistro/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblProducto.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString();

            
            }
            else { }


            List<ENT_ProductoParametro> oLista_Parametro = new List<ENT_ProductoParametro>();
            oLista_Parametro = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());

            int valor = 0;
            foreach (ENT_ProductoParametro oEntidad in oLista_Parametro)
            {
                List<ENT_Parametro> oEnt_Parametro = new List<ENT_Parametro>();
                oEnt_Parametro = oLN_Parametro.ObtenerDatosMuestraParametro(oEntidad.ProdParaCod);

                if(oEnt_Parametro.Count>0 && oEntidad.FlagVgrafico.Equals("1"))
                {
                    switch (valor) 
                    {
                    case 0:
                        generarGrafico(valor, oEnt_Parametro, cMuestra01, oEntidad); break;
                    case 1:
                        generarGrafico(valor, oEnt_Parametro, cMuestra02, oEntidad); break;
                    case 2:
                        generarGrafico(valor, oEnt_Parametro, cMuestra03, oEntidad); break;
                    case 3:
                        generarGrafico(valor, oEnt_Parametro, cMuestra04, oEntidad); break;
                    default:break;
                    }
                    valor++;
                }
            }
            valor = 0;
        }

        private void generarGrafico(int orden, List<ENT_Parametro> oEnt_Parametro, Chart grafico, ENT_ProductoParametro oEntidad)
        {
            grafico.DataSource = oEnt_Parametro;
            grafico.Series[0].XValueMember = "CodigoMuestra";
            grafico.Series[0].YValueMembers = "Resultado";
            grafico.Series[0].IsValueShownAsLabel = true;

            grafico.Series[1].XValueMember = "CodigoMuestra";
            grafico.Series[1].YValueMembers = "Resultado";
            grafico.Series[1].IsValueShownAsLabel = true;

            // Add striplines to Chart
            string minAccion = oEnt_Parametro[0].MinAccion.ToString();
            string minAdvert = oEnt_Parametro[0].MinAdvertencia.ToString();
            string promedio = oEnt_Parametro[0].Promedio.ToString();
            string maxAdvert = oEnt_Parametro[0].MaxAdvertencia.ToString();
            string maxAccion = oEnt_Parametro[0].MaxAccion.ToString();

            //double p = (double)oEnt_Parametro.Min(z => z.Resultado);
            //int roundedpmin = ((int)Math.Round(p / 10.0)) * 10;
            //grafico.ChartAreas[0].AxisY.Minimum = roundedpmin;
            //grafico.ChartAreas[0].RecalculateAxesScale();
            //grafico.ChartAreas[0].AxisY.Minimum = 20;
            grafico.ChartAreas[0].AxisY.IsStartedFromZero = false;

            grafico.ChartAreas[0].AxisY.StripLines.Add(new StripLine()
            {
                StripWidth = 0,
                BorderColor = Color.Red,
                BorderWidth = 2,
                Interval = 0,
                ToolTip = "Min Accion - " + minAccion,
                IntervalOffset = Double.Parse(minAccion)
            });
            grafico.ChartAreas[0].AxisY.StripLines.Add(new StripLine()
            {
                StripWidth = 0,
                BorderColor = Color.OrangeRed,
                BorderWidth = 2,
                Interval = 0,
                ToolTip = "Min Advertencia - " + minAdvert,
                IntervalOffset = Double.Parse(minAdvert)
            });
            grafico.ChartAreas[0].AxisY.StripLines.Add(new StripLine()
            {
                StripWidth = 0,
                BorderColor = Color.Green,
                BorderWidth = 2,
                Interval = 0,
                ToolTip = "Promedio - " + promedio,
                IntervalOffset = Double.Parse(promedio)
            });
            grafico.ChartAreas[0].AxisY.StripLines.Add(new StripLine()
            {
                StripWidth = 0,
                BorderColor = Color.OrangeRed,
                BorderWidth = 2,
                Interval = 0,
                ToolTip = "Max Advertencia - " + maxAdvert,
                IntervalOffset = Double.Parse(maxAdvert)
            });
            grafico.ChartAreas[0].AxisY.StripLines.Add(new StripLine()
            {
                StripWidth = 0,
                BorderColor = Color.Red,
                BorderWidth = 2,
                Interval = 0,
                ToolTip = "Max Accion - " + maxAccion,
                IntervalOffset = Double.Parse(maxAccion)
            });

            grafico.Titles.Add(oEntidad.NomParametro + " (" + oEntidad.UnidadMedida + ")");
            grafico.DataBind();
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("Historial.aspx");
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    
    
    }
}