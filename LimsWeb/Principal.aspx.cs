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
    public partial class Principal : System.Web.UI.Page
    {
        protected string title;
        protected string register;
        protected string rz;
        protected string email;
        protected string aviso;
        protected string msj_emailregister;
        protected string msj_incompletdata;
        protected string msj_domainregister;
        protected string msj_confregister;
        protected string msj_sendcode_1;
        protected string msj_sendcode_2;
        protected string msj_error;

        public string lang;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.UserLanguages[0];
            if (lang.Contains("es"))
            {
                title = "L.A.P.A. REGISTRO";
                register = "REGISTRO";
                rz = "Razón Social";
                chkDominio.Text = "Dominio";
                email = "Correo";
                btnRegistrar.Text = "REGISTRAR";
                aviso = "El sistema LAPA sólo validará correos existentes. En caso ingrese un dominio de correo que no existe, no podremos enviarle el código de validación para que continúe con la secuencia de registro. Por favor revisar la información antes de dar click a registrar.";
                msj_emailregister = "El correo ya se encuentra registrado en el sistema.";
                msj_incompletdata = "Datos incompletos";
                msj_domainregister = "El dominio ya se encuentra registrado en el sistema.";
                msj_confregister = "Confirmación de registro";
                msj_sendcode_1 = "Se ha enviado un codigo de activación a ";
                msj_sendcode_2 = ". Por favor revisar el mensaje enviado.";
                msj_error = "Ocurrio un Error: ";
            }

            if (lang.Contains("en"))
            {
                title = "L.A.P.A. REGISTER";
                register = "REGISTER";
                rz = "Name Company";
                chkDominio.Text = "Domain";
                email = "Email";
                btnRegistrar.Text = "REGISTER";
                aviso = "The system will only validate existing LAPA post . If enter a mail domain that does not exist , we can not send the validation code to continue with the log sequence . Please review the information before giving click to register.";
                msj_emailregister = "Mail already registered in the system.";
                msj_incompletdata = "Incomplete data";
                msj_domainregister = "The domain is already registered in the system.";
                msj_confregister = "Registration Confirmation";
                msj_sendcode_1 = "He sent an activation code to ";
                msj_sendcode_2 = ". Please check the sent message.";
                msj_error = "An error occurred: ";
            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {



            if (txtRazonSocial.Text.Length == 0
                || txtCorreo.Text.Length == 0
                || txtDominioCorreo.Text.Length == 0) 
            {
                string msj = msj_incompletdata;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                chkDominio.Checked = false;
                    return;
            }

            ENT_RegistroTemporal oENT_RegTemp = new ENT_RegistroTemporal();
            LN_RegistroTemporal oLN_RegTemp = new LN_RegistroTemporal();
            bool result = false;
            bool Enviado = false;
            string Serial = string.Empty;
            int ExisteDominio = -1;
            int existeCorreo = -1;
            oENT_RegTemp.RazonSocial = txtRazonSocial.Text.Trim();
            oENT_RegTemp.Dominio = txtDominio.Text.Trim();
            oENT_RegTemp.Correo = txtCorreo.Text.Trim()+"@"+txtDominioCorreo.Text.Trim();

            oLN_RegTemp.VerificarCorreo(oENT_RegTemp.Correo, ref existeCorreo);
            if(existeCorreo != 0)
            {
                string msj = msj_emailregister;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                
                return;
            }

            result = oLN_RegTemp.InsertarRegistroTemporal(oENT_RegTemp, ref Serial, ref ExisteDominio);

            if (ExisteDominio != 0)
            {
                string msj = msj_domainregister;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);

                return;
            }

            if (result)
            {

                try
                {
                    Correo Cr = new Correo();
                    MailMessage mnsj = new MailMessage();

                    mnsj.Subject = msj_confregister;

                    mnsj.To.Add(new MailAddress(oENT_RegTemp.Correo));

                    //mnsj.From = new MailAddress("lapa@wasitec.net", "Estimado Usuario");
                    //mnsj.From = new MailAddress("cchigne@imptec.com.pe", "Binvenid@"+ "\n\nGracias por elegirnos");
                    mnsj.From = new MailAddress("lapa@wasitec.net", "Sistema LAPA");

                    /* Si deseamos Adjuntar algún archivo*/
                    //mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                    if (lang.Contains("es"))
                    {
                        mnsj.Body = "<html><head></head><body><div style='width:400px;background:; padding:20px 40px; margin:50px auto; background:#eee;border-radius:4px'><div style='font-size:large;font-weight:bolder'>Estimado Usuario</div>" +
                                    "<br>Gracias por elegir el sistema Lapa de Wasitec SAC. <br>" +
                                    "Para terminar el registro por favor ingrese el código mostrado en el enlace siguiente:<br><br>" +
                                    "Código de registro: " + Serial +
                                    "<br>Enlace de registro: https://lapa-tec.com/iRegistro/Confirmacion.aspx" +
                                    "<br><br>Si tuviera algún inconveniente para ingresar al servicio, por favor enviar un correo a:" + "<br>lapa@wasitec.net" +
                                    "<br><br>Saludos Cordiales" + "<br>TEAM LAPA" +
                                    " </div><br></div>	</body></html>";
                    }
                    if (lang.Contains("en"))
                    {
                        mnsj.Body = "<html><head></head><body><div style='width:400px;background:; padding:20px 40px; margin:50px auto; background:#eee;border-radius:4px'><div style='font-size:large;font-weight:bolder'>Dear User</div>" +
                                    "<br>Thank you for choosing Wasitec Lapa SAC system. <br>" +
                                    "To complete the registration please enter the code shown in the following link: <br><br>" +
                                    "Registration code: " + Serial +
                                    "<br>Registration link : https://lapa-tec.com/iRegistro/Confirmacion.aspx" +
                                    "<br><br>If I had any objection to enter service, please send an email to :" + "<br>lapa@wasitec.net" +
                                    "<br><br>Best Regards" + "<br>TEAM LAPA" +
                                    " </div><br></div>	</body></html>";
                    }

                    
                    mnsj.IsBodyHtml = true;
                    /* Enviar */
                    Cr.MandarCorreo(mnsj);
                    Enviado = true;

                    string msj = msj_sendcode_1 + oENT_RegTemp.Correo + msj_sendcode_2;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                    // MessageBox.Show("El Mail se ha Enviado Correctamente", "Listo!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    txtRazonSocial.Text = "";
                    txtDominioCorreo.Text = "";
                    txtDominio.Text = "";
                    txtCorreo.Text = "";
                }
                catch (Exception ex)
                {
                    string msj = msj_error + ex.Message.ToString();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                }

            }
            else
            {
                //MENSAJE 
                return;
            }

        }


    
    }
}