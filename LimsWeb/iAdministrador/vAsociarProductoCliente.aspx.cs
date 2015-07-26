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
    public partial class vAsociarProductoCliente : System.Web.UI.Page
    {
        LN_Producto oLN_Producto = new LN_Producto();
        LN_Cliente oLN_Cliente = new LN_Cliente();
        LN_Empresa oLn_Empresa = new LN_Empresa();

        ENT_Producto oEnt_Producto = new ENT_Producto();
        ENT_Cliente oEnt_Cliente = new ENT_Cliente();

        List<ENT_Producto> oLista_Producto = new List<ENT_Producto>();
        List<ENT_Producto> oLista_ProLab = new List<ENT_Producto>();
        List<ENT_Cliente> oLista_Cliente = new List<ENT_Cliente>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oLista_Producto = oLN_Producto.ListarProducto(Int32.Parse(Session["UsuarioID"].ToString()));
                ddlProducto.DataSource = oLista_Producto;
                ddlProducto.DataTextField = "NombreProducto";
                ddlProducto.DataValueField = "ProductoID";
                ddlProducto.DataBind();

                oLista_Cliente = oLN_Cliente.ListarClientesXEmpresa(Int32.Parse(Session["UsuarioID"].ToString()));
                ddlCliente.DataSource = oLista_Cliente;
                ddlCliente.DataTextField = "NombreCliente";
                ddlCliente.DataValueField = "ClienteID";
                ddlCliente.DataBind();

                oLista_ProLab = oLN_Producto.ListarProductoXLab(Session["LaboratorioCod"].ToString());
                gvProdLab.DataSource = oLista_ProLab;
                gvProdLab.DataBind();
            }

        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');

                bool resul = false;

                resul = oLN_Producto.QuitarProdLab(Int32.Parse(datos[0].ToString().Trim()));

                if (resul)
                {

                }
                else
                {
                    Response.Write("<script>alert('No se puede eliminar el producto porque esta siendo usado en otros procesos');</script>");
                    return;
                }


                oLista_ProLab = oLN_Producto.ListarProductoXLab(Session["LaboratorioCod"].ToString());
                gvProdLab.DataSource = oLista_ProLab;
                gvProdLab.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            bool resul = false;
            int clienteid = Int32.Parse(ddlCliente.SelectedValue.ToString());

            int total = oLn_Empresa.VerificarRestriccion(Int32.Parse(Session["UsuarioID"].ToString()), "prodcli", clienteid);
            if (total >= 5)
            {
                Response.Write("<script>alert('Ya llegó al límite de productos por cliente permitidos en la licencia gratuita.');</script>");
            }
            else
            {
                resul = oLN_Producto.AsociarProductoCliente(Int32.Parse(ddlProducto.SelectedValue.ToString()), clienteid, Session["LaboratorioCod"].ToString());
                if (!resul)
                {
                    Response.Write("<script>alert('El producto " + ddlProducto.SelectedItem.ToString() + " ya existe en " + ddlCliente.SelectedItem.ToString() + "');</script>");
                    return;
                }
            }

            oLista_ProLab = oLN_Producto.ListarProductoXLab(Session["LaboratorioCod"].ToString());
            gvProdLab.DataSource = oLista_ProLab;
            gvProdLab.DataBind();
        }





    }
}