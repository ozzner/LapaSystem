using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Entidades;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace LimsWeb.iAdministrador
{
    public partial class vUsuarios : System.Web.UI.Page
    {
        LN_Usuario oLn_Usuario = new LN_Usuario();
        List<ENT_Usuario> oList_Usuario = new List<ENT_Usuario>();
        LN_PerfilUsuario oLn_PerfilUsuario = new LN_PerfilUsuario();
        LN_Laboratorio oLn_Laboratorio = new LN_Laboratorio();
        LN_Empresa oLn_Empresa = new LN_Empresa();
        ENT_Empresa oEnt_Empresa = new ENT_Empresa();

       
        protected void Page_Load(object sender, EventArgs e)
        {

         //   Session["UsuarioID"] = 13;

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
                oList_Usuario = oLn_Usuario.ListarUsuario(Int32.Parse(Session["UsuarioID"].ToString()), Int32.Parse(Session["PerfilUsuarioID"].ToString()));
                gvUsuarios.DataSource = oList_Usuario;
                gvUsuarios.DataBind();
            }

            if (!Page.IsPostBack)
            {
                CargarCombo(1, 0); //Cargar Lista PerfilUsuario
                CargarCombo(2, Int32.Parse(Session["UsuarioID"].ToString())); //Cargar Lista Laboratorio
            }

        }


        protected void CargarCombo(int tipo, int filtro)
        {
            switch (tipo)
            {
                case 1: //CARGAR PerfilUsuario
                    List<ENT_PerfilUsuario> oLista_PerfilUsuario = new List<ENT_PerfilUsuario>();
                    oLista_PerfilUsuario = oLn_PerfilUsuario.ListarPerfilUsuario();
                    ddlPerfilUsuario.DataSource = oLista_PerfilUsuario;
                    ddlPerfilUsuario.DataTextField = "NomPerfilUsuario";
                    ddlPerfilUsuario.DataValueField = "PerfilUsuarioID";
                    ddlPerfilUsuario.Items.Insert(0, new ListItem("Seleccione", "0"));
                    ddlPerfilUsuario.DataBind();
                    break;
                case 2: //CARGAR Laboratorio
                    List<ENT_Laboratorio> oLista_Laboratorio = new List<ENT_Laboratorio>();
                    oLista_Laboratorio = oLn_Laboratorio.ListarLaboratorio(filtro);
                    ddlLaboratorio.DataSource = oLista_Laboratorio;
                    ddlLaboratorio.DataTextField = "NomLaboratorio";
                    ddlLaboratorio.DataValueField = "LaboratorioID";
                    ddlLaboratorio.Items.Insert(0, new ListItem("Seleccione", "0"));
                    ddlLaboratorio.DataBind();
                    break;
            }
        }


        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');

                oLn_Usuario.EliminarUsuario(Int32.Parse(datos[0].ToString().Trim()));

                oList_Usuario = oLn_Usuario.ListarUsuario(Int32.Parse(Session["UsuarioID"].ToString()),Int32.Parse(Session["PerfilUsuarioID"].ToString()));
                gvUsuarios.DataSource = oList_Usuario;
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int resultado = -1;
            ENT_Usuario oEnt_Usuario = new ENT_Usuario();
            oEnt_Usuario.Nombre = txtNombre.Text.Trim();
            int perfilUsuario = 0;
            if (ddlPerfil.Value == "0")
            {
                perfilUsuario = 1;
                oEnt_Usuario.LaboratorioID = 0;
            }
            else
            {
                perfilUsuario = Int32.Parse(ddlPerfilUsuario.SelectedValue.ToString());
                oEnt_Usuario.LaboratorioID = Int32.Parse(ddlLaboratorio.SelectedValue.ToString());
            }
            oEnt_Usuario.PerfilUsuarioID = perfilUsuario;
            oEnt_Usuario.Correo = txtCorreo.Text.Trim();

            if (rbHabilitado.Checked) {
                oEnt_Usuario.Estado = 1;
            }
            else
            {
                oEnt_Usuario.Estado = 2;
            }

            if (rbIpNo.Checked)
            {
                oEnt_Usuario.RestriccionIP = 0;
            }
            else
            {
                oEnt_Usuario.RestriccionIP = 1;
            }

            string dominio = string.Empty;

            dominio = txtCorreo.Text.Trim();

            string[] split = dominio.Split(new Char[] { '@' });

            foreach (string s in split)
            {
                dominio = s;
            }

            if (dominio.ToString().Length == 0)
            {
                dominio = "adads";
            }
            
            oEnt_Usuario.Dominio = dominio;
            

            if (txtUsuarioID.Text.Length == 0)
            {
                resultado = -1;
                oEnt_Usuario.Clave = txtClave.Text.Trim();
                int existeSupervisor = -1;

                LN_RegistroTemporal oLN_RegTemp = new LN_RegistroTemporal();
                int existeCorreo = -1;



                oLN_RegTemp.VerificarCorreo(oEnt_Usuario.Correo, ref existeCorreo);
                if (existeCorreo != 0)
                {
                    Response.Write("<script>alert('El correo ya se encuentra registrado');</script>");
                }
                else
                {
                    // RESTRICCION USUARIOS 
                    int total = oLn_Empresa.VerificarRestriccion(Int32.Parse(Session["UsuarioID"].ToString()), "user", perfilUsuario);

                    //OBTENER VALOR DE PAQUETE
                    int paquete = Int32.Parse(Session["Paquete"].ToString());

                    
                    switch(paquete)
                    {
                        case 0: // Restricción paquete gratuito
                            if (perfilUsuario == 2 && total >= 1)
                            {
                                //Response.Write("<script>alert('No puede crear más usuarios de tipo supervisor con la licencia gratuita.\n Para suscribirse ingrese al menú ayuda, suscripción');</script>");
                                Response.Write("<script>alert('"+ ((Dictionary<string, string>)Session["Etiquetas"])["MU02"] +"');</script>");
                            }
                            else if (perfilUsuario == 3 && total >= 2)
                            {
                                Response.Write("<script>alert('" + ((Dictionary<string, string>)Session["Etiquetas"])["MU02"] + "');</script>");
                                //Response.Write("<script>alert('No puede crear más usuarios de tipo analista con la licencia gratuita.');</script>");
                            }
                            else
                            {
                                oLn_Usuario.InsertarUsuario(oEnt_Usuario, ref resultado, Int32.Parse(Session["UsuarioID"].ToString()), ref existeSupervisor);
                                if (existeSupervisor == 0)
                                {
                                    if (resultado == 0)
                                    {
                                        Response.Write("<script>alert('El correo debe pertenecer al dominio de la empresa');</script>");
                                    }
                                    bool Enviado = false;

                                    try
                                    {
                                        Correo Cr = new Correo();
                                        MailMessage mnsj = new MailMessage();

                                        mnsj.Subject = "Nuevo usuario";

                                        mnsj.To.Add(new MailAddress(txtCorreo.Text.Trim()));

                                        mnsj.From = new MailAddress("lapa@wasitec.net", "Sistema LAPA");

                                        /* Si deseamos Adjuntar algún archivo*/
                                        //mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                                        mnsj.Body = "Estimad@ " + txtNombre.Text.Trim() +
                                                    "\nBienvenido al Sistema LAPA de Wasitec SAC." +
                                                    "\n\nEl administrador del entorno de la empresa creó un usuario y contraseña para usted." +
                                                    "\nPor favor ingresar al siguiente enlace consus datos registrado:" +
                                                    "\n\nEnlace: https://lapa-tec.com/iRegistro/Login.aspx" +
                                                    "\n\nUsuario: " + txtCorreo.Text.Trim() + "\nContraseña: " + txtClave.Text.Trim() +
                                                    "\nSi tuviera algún inconveniente para ingresar al servicio, por favor contactar a su administrador: " + oEnt_Empresa.Correo +
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
                                else
                                {
                                    Response.Write("<script>alert('Ya existe un supervisor para este laboratorio');</script>");
                                }
                            } break;

                        case 1: // Restricción paquete básico
                            if (perfilUsuario == 2 && total >= 1)
                            {
                                //Response.Write("<script>alert('No puede crear más usuarios de tipo supervisor con la licencia básica.');</script>");
                                Response.Write("<script>alert('" + ((Dictionary<string, string>)Session["Etiquetas"])["MU03"] + "');</script>");
                            } 
                            else 
                            {
                                oLn_Usuario.InsertarUsuario(oEnt_Usuario, ref resultado, Int32.Parse(Session["UsuarioID"].ToString()), ref existeSupervisor);
                                if (existeSupervisor == 0)
                                {
                                    if (resultado == 0)
                                    {
                                        Response.Write("<script>alert('El correo debe pertenecer al dominio de la empresa');</script>");
                                    }
                                    bool Enviado = false;

                                    try
                                    {
                                        Correo Cr = new Correo();
                                        MailMessage mnsj = new MailMessage();

                                        mnsj.Subject = "Nuevo usuario";

                                        mnsj.To.Add(new MailAddress(txtCorreo.Text.Trim()));

                                        mnsj.From = new MailAddress("lapa@wasitec.net", "Sistema LAPA");

                                        /* Si deseamos Adjuntar algún archivo*/
                                        //mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                                        mnsj.Body = "Estimad@ " + txtNombre.Text.Trim() +
                                                    "\nBienvenido al Sistema LAPA de Wasitec SAC." +
                                                    "\n\nEl administrador del entorno de la empresa creó un usuario y contraseña para usted." +
                                                    "\nPor favor ingresar al siguiente enlace consus datos registrado:" +
                                                    "\n\nEnlace: https://lapa-tec.com/iRegistro/Login.aspx" +
                                                    "\n\nUsuario: " + txtCorreo.Text.Trim() + "\nContraseña: " + txtClave.Text.Trim() +
                                                    "Si tuviera algún inconveniente para ingresar al servicio, por favor contactar a su administrador: " + oEnt_Empresa.Correo +
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
                                else
                                {
                                    Response.Write("<script>alert('Ya existe un supervisor para este laboratorio');</script>");
                                }
                            } break;

                        case 2: // Restricción paquete corporativo
                            oLn_Usuario.InsertarUsuario(oEnt_Usuario, ref resultado, Int32.Parse(Session["UsuarioID"].ToString()), ref existeSupervisor);
                            if (existeSupervisor == 0)
                            {
                                if (resultado == 0)
                                {
                                    Response.Write("<script>alert('El correo debe pertenecer al dominio de la empresa');</script>");
                                }
                                else
                                {
                                    bool Enviado = false;

                                    try
                                    {
                                        Correo Cr = new Correo();
                                        MailMessage mnsj = new MailMessage();

                                        mnsj.Subject = "Nuevo usuario";

                                        mnsj.To.Add(new MailAddress(txtCorreo.Text.Trim()));

                                        mnsj.From = new MailAddress("lapa@wasitec.net", "Sistema LAPA");

                                        /* Si deseamos Adjuntar algún archivo*/
                                        //mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                                        mnsj.Body = "Estimad@ " + txtNombre.Text.Trim() +
                                                    "\nBienvenido al Sistema LAPA de Wasitec SAC." +
                                                    "\n\nEl administrador del entorno de la empresa creó un usuario y contraseña para usted." +
                                                    "\nPor favor ingresar al siguiente enlace consus datos registrado:" +
                                                    "\n\nEnlace: https://lapa-tec.com/iRegistro/Login.aspx" +
                                                    "\n\nUsuario: " + txtCorreo.Text.Trim() + "\nContraseña: " + txtClave.Text.Trim() +
                                                    "Si tuviera algún inconveniente para ingresar al servicio, por favor contactar a su administrador: " + oEnt_Empresa.Correo +
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
                            else
                            {
                                Response.Write("<script>alert('Ya existe un supervisor para este laboratorio');</script>");
                            } break;
                    }
                    
                }
            }
            else
            {

                oEnt_Usuario.UsuarioID = Int32.Parse(txtUsuarioID.Text.Trim());

                if (chkCambiarClave.Checked)
                {
                    oEnt_Usuario.Clave = txtClave.Text;
                    oLn_Usuario.ActualizarUsuario(oEnt_Usuario,2);
                }
                else {

                    oEnt_Usuario.Clave = " ";
                    oLn_Usuario.ActualizarUsuario(oEnt_Usuario,1);
                }
              
                //   Response.Write("<script>alert('Producto actualizado correctamente');</script>");

            }

            oList_Usuario = oLn_Usuario.ListarUsuario(Int32.Parse(Session["UsuarioID"].ToString()), Int32.Parse(Session["PerfilUsuarioID"].ToString()));
            gvUsuarios.DataSource = oList_Usuario;
            gvUsuarios.DataBind();
        }

        protected void btnActualizaIP_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string ipAddress = wc.DownloadString("http://icanhazip.com/");
            int sizecadena = ipAddress.Length;
            string nuevaip = ipAddress.Substring(0, sizecadena - 1);
            string mensaje = (oLn_Empresa.ActualizarIPEmpresa(nuevaip, Session["Ruc"].ToString())) ? 
                             "Se actualizó la IP con éxito" : "Ocurrió un error al actualizar la IP.";
            Response.Write("<script>alert('"+mensaje+"');</script>");
        }

        
    }
}