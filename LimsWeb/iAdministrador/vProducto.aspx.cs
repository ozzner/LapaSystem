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
    public partial class vProducto : System.Web.UI.Page
    {
        LN_Producto oLn_Producto = new LN_Producto();
        List<ENT_Producto> oList_Producto = new List<ENT_Producto>();
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
                oList_Producto = oLn_Producto.ListarProducto(Int32.Parse(Session["UsuarioID"].ToString()));
                gvProductos.DataSource = oList_Producto;
                gvProductos.DataBind();
            }
        }

        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');
                txtProducto.Text = datos[0].ToString().Trim();
                //txtDescProducto.Text = datos[1].ToString().Trim();
                //txtProductoID.Text = datos[2].ToString().Trim();
         
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
                
                oLn_Producto.EliminarProducto(datos[0].ToString().Trim());

                oList_Producto = oLn_Producto.ListarProducto(Int32.Parse(Session["UsuarioID"].ToString()));
                gvProductos.DataSource = oList_Producto;
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ENT_Producto oEnt_Producto = new ENT_Producto();
            oEnt_Producto.NombreProducto = txtProducto.Text.Trim();
            oEnt_Producto.DescProducto = txtDescProducto.Text.Trim();
            oEnt_Producto.UsuarioID = Int32.Parse(Session["UsuarioID"].ToString());

            if (txtProductoID.Text.Length == 0) 
            {
                oLn_Producto.InsertarProducto(oEnt_Producto);
             //   Response.Write("<script>alert('Producto creado correctamente');</script>");
            }
            else {

                oEnt_Producto.ProductoID = Int32.Parse(txtProductoID.Text.Trim());
                oLn_Producto.ActualizarProducto(oEnt_Producto);
             //   Response.Write("<script>alert('Producto actualizado correctamente');</script>");
            
            }

            oList_Producto = oLn_Producto.ListarProducto(Int32.Parse(Session["UsuarioID"].ToString()));
            gvProductos.DataSource = oList_Producto;
            gvProductos.DataBind();
        }
    }
}