using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LimsWeb.MasterPages
{
    public partial class Analista : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();

            int UsuarioID = -1;

            try
            {
                lblNombreCompleto.Text = Session["NombreCompleto"].ToString();
                UsuarioID = Int32.Parse(Session["UsuarioID"].ToString());
                //** Hay que redireccionar al login cuando capture la exepcion.
            }
            catch {
                Response.Redirect("../iRegistro/Login.aspx");
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../iRegistro/Login.aspx");
        }
    }
}