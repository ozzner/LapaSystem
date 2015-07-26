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
    public partial class vParametro : System.Web.UI.Page
    {
        LN_Parametro oLN_Parametro = new LN_Parametro();
        List<ENT_Parametro> oList_Parametro = new List<ENT_Parametro>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Harcodeando variable que simula autentificacion en el login
           // Session["UsuarioID"] = 13;

            try
            {
                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
            }
            catch
            {
                Response.Redirect("../iRegistro/Login.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {
                oList_Parametro = oLN_Parametro.ListarParametro(Int32.Parse(Session["UsuarioID"].ToString()));
                gvParametros.DataSource = oList_Parametro;
                gvParametros.DataBind();
            }
        }


        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');
                txtParametroID.Text = datos[0].ToString().Trim();
                txtNombreParametro.Text = datos[1].ToString().Trim();
                txtMetodologia.Text = datos[2].ToString().Trim();
                txtDescripcion.Text = datos[3].ToString().Trim();



                //   ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "MostrarPopUpProducto(); return false;", true);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al cargar datos..." + ex.Message + "');</script>");
            }

        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');

                oLN_Parametro.EliminarParametro(datos[0].ToString().Trim());

                oList_Parametro = oLN_Parametro.ListarParametro(Int32.Parse(Session["UsuarioID"].ToString()));
                gvParametros.DataSource = oList_Parametro;
                gvParametros.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ENT_Parametro oEnt_Parametro = new ENT_Parametro();
        
            oEnt_Parametro.NomParametro= txtNombreParametro.Text.Trim();
            oEnt_Parametro.Metodologia= txtMetodologia.Text.Trim();
            oEnt_Parametro.Descripcion = txtDescripcion.Text.Trim();
            oEnt_Parametro.UsuarioID =Int32.Parse(Session["UsuarioID"].ToString());

            if (txtParametroID.Text.Length == 0)
            {
                oLN_Parametro.InsertarParametro(oEnt_Parametro);
             //   Response.Write("<script>alert('Producto creado correctamente');</script>");
            }
            else
            {
                oEnt_Parametro.ParametroID = Int32.Parse(txtParametroID.Text.Trim());
                oLN_Parametro.ActualizarParametro(oEnt_Parametro);
             //   Response.Write("<script>alert('Parametro actualizado correctamente');</script>");
            }

            oList_Parametro = oLN_Parametro.ListarParametro(Int32.Parse(Session["UsuarioID"].ToString()));
            gvParametros.DataSource = oList_Parametro;
            gvParametros.DataBind();
        }


    }
}