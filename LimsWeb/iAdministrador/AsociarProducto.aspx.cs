using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;

namespace LimsWeb.iAdministrador
{
    public partial class AsociarProducto : System.Web.UI.Page
    {
        ENT_Producto oEnt_Producto = new ENT_Producto();

        LN_Producto oLN_Producto = new LN_Producto();
        LN_Parametro oLN_Parametro = new LN_Parametro();
        LN_Mantenimiento oLN_Mantenimiento = new LN_Mantenimiento();
        LN_Calibracion oLN_Calibracion = new LN_Calibracion();
        LN_Atributo oLN_Atributo = new LN_Atributo();

        List<ENT_Producto> oLista_Producto = new List<ENT_Producto>();
        List<ENT_ProductoParametro> oLista_Parametro = new List<ENT_ProductoParametro>();
        List<ENT_Atributo> oLista_Atributo = new List<ENT_Atributo>();
        List<ENT_Producto> oLista_ProLab = new List<ENT_Producto>();
        List<ENT_Mantenimiento> oLista_Mantenimiento = new List<ENT_Mantenimiento>();
        List<ENT_Calibracion> oLista_Calibracion = new List<ENT_Calibracion>();
        

        
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
                oLista_Producto = oLN_Producto.ListarProductoLab(Session["LaboratorioCod"].ToString());
                //String xxx = Session["LaboratorioCod"].ToString();
                //int cantProd = oLista_Producto.Count();
                gvProductos.DataSource = oLista_Producto;
                gvProductos.DataBind();

                oLista_Parametro = oLN_Parametro.ListarParametrosLab(Session["LaboratorioCod"].ToString());
                gvParametro.DataSource = oLista_Parametro;
                gvParametro.DataBind();

                oLista_Atributo = oLN_Atributo.ListarAtributosLab(Session["LaboratorioCod"].ToString());
                gvAtributos.DataSource = oLista_Atributo;
                gvAtributos.DataBind();

                oLista_Mantenimiento = oLN_Mantenimiento.ListarMantenimientos(2,Session["LaboratorioCod"].ToString());
                gvManteminiento.DataSource = oLista_Mantenimiento;
                gvManteminiento.DataBind();

                oLista_Calibracion = oLN_Calibracion.ListarCalibraciones(2,Session["LaboratorioCod"].ToString());
                gvCalibracion.DataSource = oLista_Calibracion;
                gvCalibracion.DataBind();


            
            }
            else{ }

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportesLab.aspx");
        }

    }
}

