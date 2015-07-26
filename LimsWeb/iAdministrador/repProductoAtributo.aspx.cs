﻿using System;
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
using System.Globalization;

namespace LimsWeb.iAdministrador
{
    public partial class repProductoAtributo : System.Web.UI.Page
    {
        LN_Parametro oLN_Parametro = new LN_Parametro();
        List<ENT_Parametro> oLista_Parametro = new List<ENT_Parametro>();

        List<ENT_ProductoParametro> oLista_ProdPara = new List<ENT_ProductoParametro>();

        ENT_Empresa oEnt_Emp = new ENT_Empresa();
        LN_Empresa oLN_Emp = new LN_Empresa();
        protected string url_7;
        protected string enlace_7;

        LN_Atributo oLN_Atri = new LN_Atributo();
        List<ENT_Atributo> oLista_Atri = new List<ENT_Atributo>();

        List<ENT_ProductoAtributo> oLista_ProdAtriAtri = new List<ENT_ProductoAtributo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblProducto.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString() + "/ REPORTES / Reporte de Atributo(Status)";

            string ruc = Session["RUC"].ToString();

            //PUBLICIDAD REPORTE ATRIB STAT
            oEnt_Emp = oLN_Emp.ListarPubRepAtribStat(ruc);
            string imagen = oEnt_Emp.imagen;

            if (imagen == null || imagen.Equals(""))
            {
                url_7 = "http://lapa-tec.com/backend/img_publicidad/default/img_7.jpg";
                enlace_7 = "http://wasitec.com";
            }
            else
            {
                url_7 = "http://lapa-tec.com/backend/img_publicidad/" + imagen;
                enlace_7 = oEnt_Emp.enlace;
            }

            if (!IsPostBack)
            {
                //runRptViewerParametro();
                if (!IsPostBack)
                {
                    oLista_Atri = oLN_Atri.ListarAtributoXLab(Session["ProdLabCod"].ToString());
                    cblAtributoos.DataSource = oLista_Atri;
                    cblAtributoos.DataTextField = "NomAtributo";
                    cblAtributoos.DataValueField = "AtributoID";
                    cblAtributoos.DataBind();
                    try
                    {
                        cblAtributoos.SelectedIndex = 0;
                    }
                    catch
                    {

                    }


                }
            }

        }


        protected void btnInforme_Click(object sender, EventArgs e)
        {
            List<ENT_ProductoParametro> oLista_Parametro = new List<ENT_ProductoParametro>();
            oLista_Parametro = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());
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
                    if (oEnt_Parametro.Count <= 0)
                    {
                        Response.Write("<script>alert('No existen resultados para los parametros asociados al producto.');</script>");
                    }
                    else
                    {
                        Response.Redirect("Producto.aspx");
                    }
                }
            }
        }


        SqlConnection objCon;
        public DataTable getData(string strWhere)
        {
            #region open connection
            //string strConn = "Data Source=JOSEQP-PC\\SERVIDORSQL;Initial Catalog=SistemaWeb;User ID=sa;password=Spktrowo2";
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
            string query = " select M.CodigoMuestra	,M.MuestraID	,PA.AtributoID	,A.NomAtributo	,MD.Resultado	,MD.UsuarioID	,U.Nombre	,MD.FechaInicio	,MD.FechaFin  	,(Select cast((MD.FechaFin-MD.FechaInicio) as time(0))) as 'Tiempo' from Muestra_Detalle MD inner join Muestra M on M.MuestraID=MD.MuestraID inner join Producto_Atributo PA ON PA.ProdAtriID = MD.ProdAtriID  inner join Atributo A on A.AtributoID=PA.AtributoID left join Usuario U on U.UsuarioID=MD.UsuarioID " + strWhere + "  order by MD.FechaFin desC";

            //" where cast(MD.FechaInicio as date) between cast('" + txtFecInicio.Text.Trim() + "' as date) and  cast('" + txtFecFin.Text.Trim() + "' as date) ";

            SqlCommand cmd = new SqlCommand(query, objCon);
            dta.SelectCommand = cmd;
            dta.SelectCommand.Connection = objCon;
            dta.Fill(ds, "dsAtributo");
            return ds.Tables[0];
        }
        private void runRptViewerParametro(string strWhere)
        {
            this.repvProducto.Reset();
            this.repvProducto.LocalReport.ReportPath = Server.MapPath("repProductoAttr.rdlc");
            ReportDataSource rds = new ReportDataSource("dsAtributo", getData(strWhere));



            string fecIni = txtFecInicio.Text.ToString();

            string[] datos = fecIni.Split('/');

            string diaIni = datos[0].ToString();
            string mesIni = datos[1].ToString();
            string anioIni = datos[2].ToString();
            string nuevoFormatoIni = anioIni + "-" + mesIni + "-" + diaIni;
            //string nuevoFormatoIni = mesIni + "/" + diaIni + "/" + anioIni;
            //DateTime dIni = DateTime.ParseExact(nuevoFormatoIni, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            string fecFin = txtFecFin.Text.ToString();

            string[] datosF = fecFin.Split('/');

            string diaFin = datosF[0].ToString();
            string mesFin = datosF[1].ToString();
            string anioFin = datosF[2].ToString();
            string nuevoFormatoFin = anioFin + "-" + mesFin + "-" + diaFin;
            //string nuevoFormatoFin = mesFin + "/" + diaFin + "/" + anioFin;
            //DateTime dFin = DateTime.ParseExact(nuevoFormatoFin, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            ReportParameter[] allPar = new ReportParameter[2]; // create parameters array
            //ReportParameter paramFecIni = new ReportParameter("paramFecIni", dIni.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            //ReportParameter paramFecFin = new ReportParameter("paramFecFin", dFin.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            ReportParameter paramFecIni = new ReportParameter("paramFecIni", nuevoFormatoIni);
            ReportParameter paramFecFin = new ReportParameter("paramFecFin", nuevoFormatoFin);

            allPar[0] = paramFecIni; //assign parameters to parameter array
            allPar[1] = paramFecFin;

            repvProducto.LocalReport.SetParameters(allPar); // set parameter array
            this.repvProducto.LocalReport.Refresh();

            this.repvProducto.LocalReport.DataSources.Clear();
            this.repvProducto.LocalReport.DataSources.Add(rds);
            this.repvProducto.DataBind();
            this.repvProducto.LocalReport.Refresh();

            //OBTENER VALOR DE PAQUETE
            int paquete = Int32.Parse(Session["Paquete"].ToString());

            if (paquete == 0)
            {
                repvProducto.ShowExportControls = false; 
            }
            else
            {
                repvProducto.ShowExportControls = true;
                //DeshabilitarFormatoExportacion(repvProducto, "EXCELOPENXML");
                //DeshabilitarFormatoExportacion(repvProducto, "WORDOPENXML");
            }
            objCon.Close();
            objCon.Dispose();
        }

        private void DeshabilitarFormatoExportacion(ReportViewer report, string strFormatName)
        {
            System.Reflection.FieldInfo info;
            foreach (RenderingExtension extension in report.LocalReport.ListRenderingExtensions())
            {
                if (extension.Name == strFormatName)
                {
                    info = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    info.SetValue(extension, false);
                }
            }
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("Historial.aspx");
        }

        protected void btnIrGenerarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }

        protected void btnGrafico_Click(object sender, EventArgs e)
        {
            Response.Redirect("Producto.aspx");
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            string strWhere = string.Empty;



            string fecIni = txtFecInicio.Text.ToString();

            string[] datos = fecIni.Split('/');

            string diaIni = datos[0].ToString();
            string mesIni = datos[1].ToString();
            string anioIni = datos[2].ToString();
            string nuevoFormatoIni = anioIni + mesIni + diaIni;

            string fecFin = txtFecFin.Text.ToString();

            string[] datosF = fecFin.Split('/');

            string diaFin = datosF[0].ToString();
            string mesFin = datosF[1].ToString();
            string anioFin = datosF[2].ToString();
            string nuevoFormatoFin = anioFin + mesFin + diaFin;

            strWhere = " where PA.ProdAtriID=" + cblAtributoos.SelectedValue.ToString();

            strWhere = strWhere + " and MD.EstadoMuestraID=" + rbPendientes.SelectedValue + " and cast(MD.FechaInicio as date) between cast('" + nuevoFormatoIni + "' as date) and  cast('" + nuevoFormatoFin + "' as date) ";



            runRptViewerParametro(strWhere);
        }


    }
}