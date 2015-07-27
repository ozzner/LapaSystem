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
        protected string validate;
        protected string please_insert;
        protected string confirm;
        protected string code_validate;
        public string lang;
        public static string code_inval;
        public static string code_true;

        protected void Page_Load(object sender, EventArgs e)
        {

            lang = Request.UserLanguages[0];
            if (lang.Contains("es"))
            {
                confirm = "Confirmación";
                validate = "VALIDACIÓN";
                code_validate = "Código de validación:";
                please_insert = "Porfavor ingrese el codigo de activación para poder continuar con el registro.";
                btnVerificar.Text = "Verificar";
                code_inval = "Código de activación inválido.";
                code_true = "Código correcto";
                
            }

            if (lang.Contains("en"))
            {
                confirm = "Confirmation";
                validate = "VALIDATION";
                code_validate = "Validation code:";
                please_insert = "Please enter the activation code to continue registration ";
                btnVerificar.Text = "Check";
                code_inval = "Invalid activation code.";
                code_true = "Correct code";
            }

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
                string msj = code_inval;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
               
            }
            else 
            {
                txtSerial.BackColor = System.Drawing.ColorTranslator.FromHtml("#20d02d");
                string msj = code_true;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                Session["serial"] = txtSerial.Text;
                Response.Redirect("Registro.aspx");
            }

        }
    }
}