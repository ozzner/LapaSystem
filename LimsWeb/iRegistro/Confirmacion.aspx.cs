using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;

namespace LimsWeb
{
    public partial class Confirmacion : System.Web.UI.Page
    {
        LN_RegistroTemporal oLN_RegTemp = new LN_RegistroTemporal();
        ENT_RegistroTemporal oEnt_RegTemp = new ENT_RegistroTemporal();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            List<ENT_RegistroTemporal> oLista = new List<ENT_RegistroTemporal>();
           // oEnt_RegTemp.Serial = txtSerial.Text.Trim();
            string serial = txtSerial.Text.Trim();
            int resultado = -1;
            oLista = oLN_RegTemp.VerificarSerial(serial, ref resultado);


            if (oLista.Count == 0)
            {
                txtSerial.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff2d00");
                string msj = "Codigo de activación inválido.";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
               
            }
            else 
            {
                txtSerial.BackColor = System.Drawing.ColorTranslator.FromHtml("#20d02d");
                string msj = "Codigo Correcto";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                Session["serial"] = txtSerial.Text;
                Response.Redirect("Registro.aspx");
            }

        }
    }
}