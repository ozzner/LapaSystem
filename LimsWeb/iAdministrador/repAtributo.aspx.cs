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
using System.Reflection;

namespace LimsWeb.iAdministrador
{
    public partial class repAtributo : System.Web.UI.Page
    {
        LN_Atributo oLN_Atri = new LN_Atributo();
        List<ENT_Atributo> oLista_Atri = new List<ENT_Atributo>();
        LN_Parametro oLN_Parametro = new LN_Parametro();
        List<ENT_ProductoAtributo> oLista_ProdAtriAtri = new List<ENT_ProductoAtributo>();

        ENT_Empresa oEnt_Emp = new ENT_Empresa();
        LN_Empresa oLN_Emp = new LN_Empresa();
        protected string url_5;
        protected string enlace_5;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblProducto.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString() + "/ REPORTES / Reporte de Atributo(Estadístico)";


            string ruc = Session["RUC"].ToString();

            //PUBLICIDAD REPORTE ATRIBUTO EST
            oEnt_Emp = oLN_Emp.ListarPubRepAtribEst(ruc);
            string imagen = oEnt_Emp.imagen;

            if (imagen == null || imagen.Equals(""))
            {
                url_5 = "http://lapa-tec.com/backend/img_publicidad/default/img_5.jpg";
                enlace_5 = "https://play.google.com/store/apps/details?id=net.wasitec.activity";
            }
            else
            {
                url_5 = "http://lapa-tec.com/backend/img_publicidad/" + imagen;
                enlace_5 = oEnt_Emp.enlace;
            }



            if (!IsPostBack)
            {
                try
                {
                    oLista_Atri = oLN_Atri.ListarAtributoXLab(Session["ProdLabCod"].ToString());
                    cblAtributos.DataSource = oLista_Atri;
                    cblAtributos.DataTextField = "NomAtributo";
                    cblAtributos.DataValueField = "AtributoID";
                    cblAtributos.DataBind();
                    cblAtributos.SelectedIndex = 0;
                }
                catch
                {
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
            string query = " select M.CodigoMuestra	,M.MuestraID	,PA.AtributoID	,A.NomAtributo	,MD.Resultado ,MD.UsuarioID	,U.Nombre	,MD.FechaInicio	,MD.FechaFin  	,(Select cast((MD.FechaFin-MD.FechaInicio) as time(0))) as 'Tiempo' from Muestra_Detalle MD inner join Muestra M on M.MuestraID=MD.MuestraID inner join Producto_Atributo PA ON PA.ProdAtriID = MD.ProdAtriID  inner join Atributo A on A.AtributoID=PA.AtributoID left join Usuario U on U.UsuarioID=MD.UsuarioID " + strWhere + "  order by MD.FechaFin desC";

            SqlCommand cmd = new SqlCommand(query, objCon);
            dta.SelectCommand = cmd;
            dta.SelectCommand.Connection = objCon;
            dta.Fill(ds, "dsParamS");
            return ds.Tables[0];
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


        private void runRptViewerParametro(string strWhere)
        {
            this.repvParametro.Reset();
            this.repvParametro.LocalReport.ReportPath = Server.MapPath("repAtributos.rdlc");
            ReportDataSource rds = new ReportDataSource("dsAtributos", getData(strWhere));


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
            // string nuevoFormatoFin = mesFin + "/" + diaFin + "/" + anioFin;
            // DateTime dFin = DateTime.ParseExact(nuevoFormatoFin, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            ReportParameter[] allPar = new ReportParameter[2]; // create parameters array
            //ReportParameter paramFecIni = new ReportParameter("paramFecIni", dIni.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            //ReportParameter paramFecFin = new ReportParameter("paramFecFin", dFin.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            ReportParameter paramFecIni = new ReportParameter("paramFecIni", nuevoFormatoIni);
            ReportParameter paramFecFin = new ReportParameter("paramFecFin", nuevoFormatoFin);

            allPar[0] = paramFecIni; //assign parameters to parameter array
            allPar[1] = paramFecFin;

            repvParametro.LocalReport.SetParameters(allPar); // set parameter array
            this.repvParametro.LocalReport.Refresh();
            this.repvParametro.LocalReport.DataSources.Clear();
            this.repvParametro.LocalReport.DataSources.Add(rds);
            this.repvParametro.DataBind();
            this.repvParametro.LocalReport.Refresh();

            //OBTENER VALOR DE PAQUETE
            int paquete = Int32.Parse(Session["Paquete"].ToString());

            if (paquete == 0)
            {
                repvParametro.ShowExportControls = false; 
            }
            else
            {
                repvParametro.ShowExportControls = true;
                //DeshabilitarFormatoExportacion(repvParametro, "EXCELOPENXML");
                //DeshabilitarFormatoExportacion(repvParametro, "WORDOPENXML");
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
                    info = extension.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.NonPublic);
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

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            string strWhere = string.Empty;


            //int seleccionado = -1;
            //foreach (ListItem item in rbPendientes.Items)
            //{
            //    if (item.Selected)
            //    {
            //        seleccionado = Int32.Parse(item.Value);
            //    }
            //}

            strWhere = " where PA.ProdAtriID=" + cblAtributos.SelectedValue.ToString();

            //if (rbPendientes.SelectedValue == "1")
            //{
            //    strWhere = strWhere + " and MD.EstadoMuestraID=" + seleccionado.ToString();
            //}
            //else {


            string fecIni = txtFecInicio.Text.ToString();

            string[] datos = fecIni.Split('/');

            string diaIni = datos[0].ToString();
            string mesIni = datos[1].ToString();
            string anioIni = datos[2].ToString();
            //string nuevoFormatoIni = mesIni + "/" + diaIni + "/" + anioIni;
            string nuevoFormatoIni = anioIni + mesIni + diaIni;

            string fecFin = txtFecFin.Text.ToString();

            string[] datosF = fecFin.Split('/');

            string diaFin = datosF[0].ToString();
            string mesFin = datosF[1].ToString();
            string anioFin = datosF[2].ToString();
            //string nuevoFormatoFin = mesFin + "/" + diaFin + "/" + anioFin;
            string nuevoFormatoFin = anioFin + mesFin + diaFin;



            strWhere = strWhere + " and MD.EstadoMuestraID= 3 and cast(MD.FechaInicio as date) between cast('" + nuevoFormatoIni + "' as date) and  cast('" + nuevoFormatoFin + "' as date) ";

            //}

            runRptViewerParametro(strWhere);
        }


    }
}