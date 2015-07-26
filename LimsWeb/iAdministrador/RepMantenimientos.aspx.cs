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
    public partial class RepMantenimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblLaboratorio.Text = Session["NomLaboratorio"].ToString();
                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
            }
            catch
            {
                Response.Redirect("../iRegistro/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                runRptViewerParametro();
            }

        }

        SqlConnection objCon;
        public DataTable getData()
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
           // string query = "Select C.CalibracionID ,E.NomEstado ,cast(cast(FechaProgramacion as date) as varchar(40)) as 'FechaProgramacion' ,Operador ,ISO as 'Estandar' ,Eqp.Nombre ,L.NomLaboratorio from Calibracion C inner join Estado E on E.EstadoID=C.EstadoID inner join Equipos Eqp on Eqp.EquipoID = C.EquipoID inner join Laboratorio L on L.LaboratorioID=Eqp.LaboratorioID where LaboratorioCod ='" + Session["LaboratorioCod"].ToString() + "'";
            string query = "Select M.MantenimientoID ,E.NomEstado ,cast(cast(FechaProgramacion as date) as varchar(40)) as 'FechaProgramacion'  ,Operador ,Eqp.Nombre ,L.NomLaboratorio from Mantenimiento M inner join Estado E on E.EstadoID=M.EstadoID inner join Equipos Eqp on Eqp.EquipoID = M.EquipoID inner join Laboratorio L on L.LaboratorioID=Eqp.LaboratorioID where LaboratorioCod ='" + Session["LaboratorioCod"].ToString() + "' and M.EstadoID=1 ORDER BY M.FechaProgramacion DESC";

            SqlCommand cmd = new SqlCommand(query, objCon);
            dta.SelectCommand = cmd;
            dta.SelectCommand.Connection = objCon;
            dta.Fill(ds, "dsMantenimiento");
            return ds.Tables[0];
        }

        private void runRptViewerParametro()
        {
            this.repvMantenimientos.Reset();
            this.repvMantenimientos.LocalReport.ReportPath = Server.MapPath("repMantenimiento.rdlc");
            ReportDataSource rds = new ReportDataSource("dsMantenimiento", getData());
            this.repvMantenimientos.LocalReport.DataSources.Clear();
            this.repvMantenimientos.LocalReport.DataSources.Add(rds);
            this.repvMantenimientos.DataBind();
            this.repvMantenimientos.LocalReport.Refresh();
            if (Int32.Parse(Session["Paquete"].ToString()) == 2)
            {
                repvMantenimientos.ShowExportControls = true;
                DeshabilitarFormatoExportacion(repvMantenimientos, "EXCELOPENXML");
                DeshabilitarFormatoExportacion(repvMantenimientos, "WORDOPENXML");
            }
            else
            {
                repvMantenimientos.ShowExportControls = false;
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

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportesLab.aspx");
        }
    }
}