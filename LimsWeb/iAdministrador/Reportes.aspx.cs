using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using Entidades;
using LogicaNegocio;

using System.Collections.Generic;
using System.Linq;

namespace LimsWeb.iAdministrador
{
    public partial class Reportes : System.Web.UI.Page
    {
        LN_Parametro oLN_Parametro = new LN_Parametro();
        List<ENT_Parametro> oLista_Parametro = new List<ENT_Parametro>();

        List<ENT_ProductoParametro> oLista_ProdPara = new List<ENT_ProductoParametro>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblProducto.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString() + "/ REPORTES";
                //OBTENER VALOR DE PAQUETE
                int paquete = Int32.Parse(Session["Paquete"].ToString());

                if (paquete < 2)
                {
                    cambiarLogo.Visible = false;
                }
                

                //oLista_ProdPara = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());
                //cblParametros.DataSource = oLista_ProdPara;
                //cblParametros.DataTextField = "NomParametro";
                //cblParametros.DataValueField = "ProdParaID";
                //cblParametros.DataBind();        
            }

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }


        protected void btnInforme_Click(object sender, EventArgs e)
        {
            List<ENT_ProductoParametro> oLista_Parametro = new List<ENT_ProductoParametro>();
            oLista_Parametro = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());
            bool existe = false; 
            if (oLista_Parametro.Count <= 0)
            {
                Response.Write("<script>alert('No existen parametros asociados a este producto.');</script>");
            }
            else
            {
                foreach (ENT_ProductoParametro oEntidad in oLista_Parametro)
                {
                    List<ENT_Parametro> oEnt_Parametro = new List<ENT_Parametro>();
                    oEnt_Parametro = oLN_Parametro.ObtenerDatosMuestraParametro(oEntidad.ProdParaCod);
                    if (oEnt_Parametro.Count>0)
                    {
                        existe = true;
                    }
                }
                if (!existe)
                {
                    Response.Write("<script>alert('No existen resultados para los parametros asociados al producto.');</script>");
                }
                else
                {
                    Response.Redirect("Producto.aspx");
                }     
            }
        }
        protected void btnGrafico_Click(object sender, EventArgs e)
        {
            Response.Redirect("Producto.aspx");
        }

        //protected void btnGenerarReport_Click(object sender, EventArgs e)
        //{
        //    ENT_ProductoParametro oEnt_ProdPara = new ENT_ProductoParametro();

        //    List<string> selectedValues = cblParametros.Items.Cast<ListItem>()
        //       .Where(li => li.Selected)
        //       .Select(li => li.Value)
        //       .ToList();

        //    string strWhere = string.Empty;
        //    int max = selectedValues.Count();
        //    for (int i = 0; i < max; i++) { 
        //    strWhere = strWhere+" MD.ProdParaID="+selectedValues[i].ToString()+" ";
        //    if (i == (max - 1))
        //    {

        //    }
        //    else {
        //        strWhere = strWhere + " or ";
        //    }

        //    }



        //    //runRptViewerParametro(strWhere);

        //}

        SqlConnection objCon;
        public DataTable getData(string strWhere)
        {
            #region open connection
            string strConn = "Data Source='JULIO-PC\\SQLEXPRESS';Initial Catalog=SistemaWeb;User ID=sa;password=Wasitec2014";
            objCon = new SqlConnection();
            objCon = new SqlConnection(strConn);
            objCon.Open();
            #endregion
            SqlDataAdapter dta = new SqlDataAdapter();
            //SqlConnection con = new SqlConnection(“Data Source=local;Initial Catalog=master;Integrated Security=True”);
            DataSet ds = new DataSet();
            //   string query = "Select MD.MuestraDetalleID, P.NomParametro, A.NomAtributo, MD.FechaInicio, MD.FechaFin, MD.Resultado From Muestra_Detalle MD left join Producto_Parametro PP on PP.ProdParaID = MD.ProdParaID left join Parametro P on P.ParametroID=PP.ParametroID  left join Producto_Atributo PA on PA.ProdAtriID = MD.ProdAtriID left join Atributo A on A.AtributoID=PA.AtributoID ";
            // string query = "Select MD.MuestraDetalleID,MD.MuestraID, P.NomParametro, A.NomAtributo, MD.FechaInicio, MD.FechaFin, PP.ProdParaID,P.NomParametro, MD.Resultado From Muestra_Detalle MD left join Producto_Parametro PP on PP.ProdParaID = MD.ProdParaID left join Parametro P on P.ParametroID=PP.ParametroID  left join Producto_Atributo PA on PA.ProdAtriID = MD.ProdAtriID left join Atributo A on A.AtributoID=PA.AtributoID where "+strWhere;//where PP.ProdParaID=68 or PP.ProdParaID=69
            string query = "Select MD.MuestraDetalleID , MD.ProdParaID, Prod.NombreProducto, MD.MuestraID, P.NomParametro, A.NomAtributo, MD.FechaInicio, MD.FechaFin, MD.Resultado From Muestra_Detalle MD  left join Producto_Parametro PP on PP.ProdParaID = MD.ProdParaID left join Parametro P on P.ParametroID=PP.ParametroID left join Producto_Atributo PA on PA.ProdAtriID = MD.ProdAtriID left join Atributo A on A.AtributoID=PA.AtributoID left join Producto_Laboratorio PL on PL.ProdLabID = PP.ProdLabID left join Producto Prod on Prod.ProductoID=PL.ProductoID where " + strWhere;


            SqlCommand cmd = new SqlCommand(query, objCon);
            dta.SelectCommand = cmd;
            dta.SelectCommand.Connection = objCon;
            dta.Fill(ds, "dsParamS");
            return ds.Tables[0];
        }
        //private void runRptViewerParametro(string strWhere)
        //{
        //    this.rParametro.Reset();
        //    this.rParametro.LocalReport.ReportPath = Server.MapPath("Report2.rdlc");
        //    ReportDataSource rds = new ReportDataSource("dsParamS", getData(strWhere));
        //    this.rParametro.LocalReport.DataSources.Clear();
        //    this.rParametro.LocalReport.DataSources.Add(rds);
        //    this.rParametro.DataBind();
        //    this.rParametro.LocalReport.Refresh();
        //    objCon.Close();
        //    objCon.Dispose();
        //}

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("Historial.aspx");
        }

        protected void btnIrGenerarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
        protected void btnRepParametro_Click(object sender, EventArgs e)
        {
            Response.Redirect("repParametro.aspx");
        }
        protected void btnRepAtributo_Click(object sender, EventArgs e)
        {
            Response.Redirect("repAtributo.aspx");
        }
        protected void btnRepProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("repProducto.aspx");
        }
        protected void btnRepProductoAttr_Click(object sender, EventArgs e)
        {
            Response.Redirect("repProductoAtributo.aspx");
        }
    }
}