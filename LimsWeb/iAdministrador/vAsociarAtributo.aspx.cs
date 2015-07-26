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
    public partial class vAsociarAtributo : System.Web.UI.Page
    {
        LN_Parametro oLN_Parametro = new LN_Parametro();
        LN_Atributo oLN_Atributo = new LN_Atributo();
        LN_Cliente oLN_Cliente = new LN_Cliente();
       
        ENT_Parametro oEnt_Producto = new ENT_Parametro();
        ENT_ProductoAtributo oEnt_ProdAttr = new ENT_ProductoAtributo();
        List<ENT_ProductoAtributo> oLista_ProdAttr = new List<ENT_ProductoAtributo>();

        List<ENT_ProductoParametro> oLista_ProdPara = new List<ENT_ProductoParametro>();
        List<ENT_Atributo> oLista_Atributo = new List<ENT_Atributo>();

        LN_UnidadMedida oLN_UM = new LN_UnidadMedida();
        LN_TipoParametro oLN_TipoParametro = new LN_TipoParametro();
        LN_Formula oLN_Formula = new LN_Formula();
        string ProdParaCod = "";


        protected void Page_Load(object sender, EventArgs e)
        {

            lblProducto.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString();
            var cliente = oLN_Cliente.ObtenerCliente(Session["ProdLabCod"].ToString()).NombreCliente;
            lblWinTitle.Text = Session["NomLaboratorio"].ToString() + "/" + cliente + Session["NomProducto"].ToString();

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
                //oLista_Parametro = oLN_Parametro.ListarParametro(Int32.Parse(Session["UsuarioID"].ToString()));
                //lbProductos.DataSource = oLista_Parametro;
                //lbProductos.DataTextField = "NomParametro";
                //lbProductos.DataValueField = "ParametroID";
                //lbProductos.DataBind();
           
                List<ENT_Atributo> oList_Attr = new List<ENT_Atributo>();

                //.ListarParametro(Int32.Parse(Session["UsuarioID"].ToString()))

                oLista_Atributo = oLN_Atributo.ListarAtributo(Int32.Parse(Session["UsuarioID"].ToString()));
                lbProductos.DataSource = oLista_Atributo;
                lbProductos.DataTextField = "NomAtributo";
                lbProductos.DataValueField = "AtributoID";
                lbProductos.DataBind();

                oList_Attr = oLN_Atributo.ListarAtributoXLab(Session["ProdLabCod"].ToString());
                lbAgregados.DataSource = oList_Attr;
                lbAgregados.DataTextField = "NomAtributo";
                lbAgregados.DataValueField = "AtributoID";
                lbAgregados.DataBind();

                    if ((this.ViewState["Opciones"] != null))
                    {
                        oLista_ProdAttr = (List<ENT_ProductoAtributo>)(this.ViewState["Opciones"]);
                        lbOpciones.DataSource = oLista_ProdAttr;
                        lbOpciones.DataBind();
                    }
                    else
                    {
                        this.ViewState.Add("Opciones", oLista_ProdAttr);
                        ViewState["Opciones"] = new List<ENT_ProductoAtributo>();
                    }
            }
            else { }
        }

        protected void lbAgregados_OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
            lbOpciones.DataSource = "";
            lbOpciones.DataTextField = "";
            lbOpciones.DataBind();

            ViewState["Opciones"] = null;
            ViewState["Opciones"] = new List<ENT_ProductoAtributo>();

            List<ENT_ProductoAtributo> oListaa = new List<ENT_ProductoAtributo>();

            lblParametro.Text = "Atributo: "+ lbAgregados.SelectedItem.Text.Trim();
            
           oListaa =  oLN_Atributo.ListarProdAttr(Int32.Parse(lbAgregados.SelectedValue.ToString()));

           string opciones = string.Empty;

           foreach (ENT_ProductoAtributo oEnt in oListaa) {
               opciones=oEnt.Opciones.ToString();
           }
            /* Estructura XML Opciones
             *  <Atributo>
             *      <Opcion>A</Opcion>
             *      <Opcion>B</Opcion>
             *      <Opcion>C</Opcion>
             *      <Opcion>D</Opcion>
             *  </Atributo>
             */
           if (opciones== "") {
               return;
           }

           opciones = opciones.Replace("<Atributo><Opcion>", "");
           opciones = opciones.Replace("<Opcion><Atributo>", "");
           opciones = opciones.Replace("</Atributo>", "");
           opciones = opciones.Replace("</Opcion>", "");
           opciones = opciones.Replace("<Opcion>", "{");
            
            
                string[] datos = opciones.Split('{');

                for (int i = 0; i < datos.Count(); i++) {
                    ENT_ProductoAtributo oEntii = new ENT_ProductoAtributo();
                    oEntii.Opciones = datos[i].ToString().Trim();
                    oLista_ProdAttr.Add(oEntii);
                }
                
            this.ViewState.Add("Opciones", oLista_ProdAttr);
            lbOpciones.DataSource = oLista_ProdAttr;
            lbOpciones.DataTextField = "Opciones";
            lbOpciones.DataBind();
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            LN_Atributo oLN_Atributo = new LN_Atributo();

            List<ENT_Atributo> oList_Attr = new List<ENT_Atributo>();
            int resultado = -1;
            foreach (ListItem li in lbProductos.Items)
            {
                if (li.Selected)
                {
                    oLN_Atributo.AsociarAtributo(Int32.Parse(li.Value), Session["ProdLabCod"].ToString(), 1, ref resultado);

                    if (resultado == 1)
                    {
                        Response.Write("<script>alert('El atributo ya se encuentra agregado');</script>");
                        return;
                    }
                    else
                    {
                        oList_Attr = oLN_Atributo.ListarAtributoXLab(Session["ProdLabCod"].ToString());
                        lbAgregados.DataSource = oList_Attr;
                        lbAgregados.DataTextField = "NomAtributo";
                        lbAgregados.DataValueField = "AtributoID";
                        lbAgregados.DataBind();

                        lbOpciones.DataSource = "";
                        lbOpciones.DataTextField = "";
                        lbOpciones.DataBind();
                        //    ((MasterPages.Principal)this.Master).CargarTreeView();
                    }

                }
            }
        }

        protected void btnQuitar_Click(object sender, ImageClickEventArgs e)
        {

            LN_Atributo oLN_Atributo = new LN_Atributo();
            List<ENT_Atributo> oList_Attr = new List<ENT_Atributo>();

            foreach (ListItem li in lbAgregados.Items)
            {
                if (li.Selected)
                {
                    /* Verifificar si el parametro tiene muestra asociadas.
                     * En caso que las tenga, Mostrar un mensaje informandole
                     * que no se puede eliminar hasta que se eliminen las muestras
                     * */
                    oLN_Atributo.QuitarAtributo(Int32.Parse(li.Value));
                }
            }

            oList_Attr = oLN_Atributo.ListarAtributoXLab(Session["ProdLabCod"].ToString());
            lbAgregados.DataSource = oList_Attr;
            lbAgregados.DataTextField = "NomAtributo";
            lbAgregados.DataValueField = "AtributoID";
            lbAgregados.DataBind();

            //  ((MasterPages.Principal)this.Master).CargarTreeView();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            oLista_ProdAttr = (List<ENT_ProductoAtributo>)(this.ViewState["Opciones"]);
            bool resul = false;

            resul = oLN_Atributo.GuardarCambios(oLista_ProdAttr, Int32.Parse(lbAgregados.SelectedValue.ToString()));

            if (resul) {
                Response.Write("<script>alert('Datos actualizados correctamente.');</script>");
                //lbOpciones.DataSource = "";
                //lbOpciones.DataTextField = "";
                //lbOpciones.DataBind();
            }
        }

        protected void btnQuitarOpt_Click(object sender, EventArgs e)
        {
            oLista_ProdAttr = (List<ENT_ProductoAtributo>)(this.ViewState["Opciones"]);

            //oEnt_ProdAttr.Opciones = lbOpciones.SelectedValue;
            var r =  oLista_ProdAttr.Where(x => x.Opciones.Equals(lbOpciones.SelectedValue));
            oEnt_ProdAttr = r.First();
            oLista_ProdAttr.Remove(oEnt_ProdAttr);

            this.ViewState.Add("Opciones", oLista_ProdAttr);
            lbOpciones.DataSource = oLista_ProdAttr;
            lbOpciones.DataTextField = "Opciones";
            lbOpciones.DataBind();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {


            //this.ViewState["Opciones"] = new List<ENT_ProductoAtributo>();
            oLista_ProdAttr = (List<ENT_ProductoAtributo>)(this.ViewState["Opciones"]);
           
            oEnt_ProdAttr.Opciones = txtOpciones.Text.Trim();
            oLista_ProdAttr.Add(oEnt_ProdAttr);

            this.ViewState.Add("Opciones", oLista_ProdAttr);
            lbOpciones.DataSource = oLista_ProdAttr;
            lbOpciones.DataTextField = "Opciones";
            lbOpciones.DataBind();
            
            txtOpciones.Text = "";
        
        
        }

    }
}