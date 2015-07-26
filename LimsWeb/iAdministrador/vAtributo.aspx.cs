using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Entidades;

namespace LimsWeb
{
    public partial class Atributo : System.Web.UI.Page
    {
        LN_Atributo oLN_Atributo = new LN_Atributo();
        List<ENT_Atributo> oLista_Atributo = new List<ENT_Atributo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                oLista_Atributo = oLN_Atributo.ListarAtributo(Int32.Parse(Session["UsuarioID"].ToString()));
                gvAtributo.DataSource = oLista_Atributo;
                gvAtributo.DataBind();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ENT_Atributo oEnt_Atributo = new ENT_Atributo();

           
            oEnt_Atributo.NomAtributo = txtNomAtributo.Text.Trim();
            oEnt_Atributo.UsuarioID = Int32.Parse(Session["UsuarioID"].ToString());

            if (txtAtributoID.Text.Length == 0)
            {
                oLN_Atributo.InsertarAtributo(oEnt_Atributo);

                oLista_Atributo = oLN_Atributo.ListarAtributo(Int32.Parse(Session["UsuarioID"].ToString()));
                gvAtributo.DataSource = oLista_Atributo;
                gvAtributo.DataBind();
            }
            else
            {
                oEnt_Atributo.AtributoID = Int32.Parse(txtAtributoID.Text.Trim());
                oLN_Atributo.ActualizarAtributo(oEnt_Atributo);
                oLista_Atributo = oLN_Atributo.ListarAtributo(Int32.Parse(Session["UsuarioID"].ToString()));
                gvAtributo.DataSource = oLista_Atributo;
                gvAtributo.DataBind();
                Response.Write("<script>alert('Atributo actualizado correctamente');</script>");
            }
        }




        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            ENT_Atributo oEnt_Atributo = new ENT_Atributo();

            string strID = e.CommandArgument.ToString();
            string[] datos = strID.Split('{');


                oLN_Atributo.EliminarAtributo(Int32.Parse(datos[0].ToString().Trim()));
                oLista_Atributo = oLN_Atributo.ListarAtributo(Int32.Parse(Session["UsuarioID"].ToString()));
                gvAtributo.DataSource = oLista_Atributo;
                gvAtributo.DataBind();
            }
        
    }
}