using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.Net.Mail;

namespace LimsWeb
{
    public partial class olvidoclave : System.Web.UI.Page
    {
        ENT_Usuario oEnt_Usuario = new ENT_Usuario();
        LN_Usuario oLN_Usuario=new LN_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            oEnt_Usuario=oLN_Usuario.obtenerCredenciales(txtCorreo.Text.Trim());


            bool Enviado = false;

            try
            {
                Correo Cr = new Correo();
                MailMessage mnsj = new MailMessage();

                mnsj.Subject = "Credenciales para el ingreso al sistema";

                mnsj.To.Add(new MailAddress(txtCorreo.Text.Trim()));

                mnsj.From = new MailAddress("lapa@wasitec.net", "Sistema LAPA");

                /* Si deseamos Adjuntar algún archivo*/
                //mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                mnsj.Body = "Estimad@ "  +
                            "\n\nPara ingresar al sistema LAPA de Wasitec SAC, deberás ingresar con los datos siguientes: " +

                            "\n\nUsuario: " + oEnt_Usuario.Correo + "\nContraseña: " + oEnt_Usuario.Clave +
                            "\n\nSi tuviera algún inconveniente para ingresar al servicio, por favor contactar a su administrador: (Correo del administrador)." +
                            "\n\nSaludos Cordiales\nTEAM LAPA";

                /* Enviar */
                Cr.MandarCorreo(mnsj);
                Enviado = true;

                string msj = "Se envió un mensaje a: " + txtCorreo.Text.Trim() + " indicando su contraseña para que pueda acceder al sistema LAPA";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                // MessageBox.Show("El Mail se ha Enviado Correctamente", "Listo!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                txtCorreo.Text = "";
            }
            catch (Exception ex)
            {
                string msj = "Ocurrio un Error: " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
            }


        }
    }
}