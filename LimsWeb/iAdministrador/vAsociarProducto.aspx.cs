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
    public partial class vAsociarProductos : System.Web.UI.Page
    {

        LN_Producto oLN_Producto = new LN_Producto();
        ENT_Producto oEnt_Producto = new ENT_Producto();
        LN_Empresa oLn_Empresa = new LN_Empresa();

        List<ENT_Producto> oLista_Producto = new List<ENT_Producto>();
        List<ENT_Producto> oLista_ProLab = new List<ENT_Producto>();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblLaboratorio.Text = Session["NomLaboratorio"].ToString();


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
                oLista_Producto = oLN_Producto.ListarProducto(Int32.Parse(Session["UsuarioID"].ToString()));
                lbProductos.DataSource = oLista_Producto;
                lbProductos.DataTextField = "NombreProducto";
                lbProductos.DataValueField = "ProductoID";
                lbProductos.DataBind();

                oLista_ProLab = oLN_Producto.ListarProductoXLab(Session["LaboratorioCod"].ToString());
                lbAgregados.DataSource = oLista_ProLab;
                lbAgregados.DataTextField = "NombreProducto";
                lbAgregados.DataValueField = "ProdLabID";
                lbAgregados.DataBind();
            }
            else { }
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            ENT_Producto oEntidad = new ENT_Producto();
            int resultado = -1;
            foreach (ListItem li in lbProductos.Items)
            {
                if (li.Selected)
                {
                    //OBTENER VALOR DE PAQUETE
                    int paquete = Int32.Parse(Session["Paquete"].ToString());

                    int total = oLn_Empresa.VerificarRestriccion(Int32.Parse(Session["UsuarioID"].ToString()), "prodlab", 0);
                    
                    
                    if (paquete==0 && total >= 5)
                    {
                        Response.Write("<script>alert('Ya llegó al límite de productos por laboratorio permitidos en la licencia gratuita.');</script>");
                    }
                    else
                    {
                        oLN_Producto.AsociarProducto(Int32.Parse(li.Value), Session["LaboratorioCod"].ToString(), 1, ref resultado);

                        if (resultado == 1)
                        {
                            Response.Write("<script>alert('El producto ya se encuentra agregado');</script>");
                            return;
                        }
                        else
                        {
                            oLista_ProLab = oLN_Producto.ListarProductoXLab(Session["LaboratorioCod"].ToString());
                            lbAgregados.DataSource = oLista_ProLab;
                            lbAgregados.DataTextField = "NombreProducto";
                            lbAgregados.DataValueField = "ProdLabID";
                            lbAgregados.DataBind();

                            //       ((MasterPages.Principal)this.Master).CargarTreeView();
                        }
                    }
                }
            }
        }



        protected void btnQuitar_Click(object sender, ImageClickEventArgs e)
        {
            ENT_Producto oEntidad = new ENT_Producto();

            foreach (ListItem li in lbAgregados.Items)
            {
                if (li.Selected)
                {
                    bool resul = false;
                        resul = oLN_Producto.QuitarProdLab(Int32.Parse(li.Value));

                        if (resul)
                        {
                            Response.Write("<script>alert('Se eliminó el producto correctamente');</script>");
                     
                        }
                        else {
                            Response.Write("<script>alert('No se puedo eliminar el producto. El producto está asociado a un parámetro y/o muestra');</script>");
                     
                        }

                    
                }
            }

            oLista_ProLab = oLN_Producto.ListarProductoXLab(Session["LaboratorioCod"].ToString());
            lbAgregados.DataSource = oLista_ProLab;
            lbAgregados.DataTextField = "NombreProducto";
            lbAgregados.DataValueField = "ProdLabID";
            lbAgregados.DataBind();

       //     ((MasterPages.Principal)this.Master).CargarTreeView();
        }




    }
}