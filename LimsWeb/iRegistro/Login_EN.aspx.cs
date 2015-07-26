﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Entidades;
using System.Text; //StringBuilder
using System.Drawing; //Graphics, Rectangle, Bitmap, Font, Color, Size
using System.Drawing.Drawing2D; //LinearGradientBrush
using System.Drawing.Imaging; //ImageFormat
using System.IO;
using System.Net; //MemoryStream





namespace LimsWeb.iRegistro
{

    public partial class Login_EN : System.Web.UI.Page
    {
        LN_Usuario oLN_Usuario;
        LN_Idioma oLN_Idiona = new LN_Idioma();
        protected string ingreso;
        public string idioma = string.Empty;

        //Variables


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string lang = Request.UserLanguages[0];
                crearCaptcha();
                ingreso = "ING";
                
            }
        }


        private static char generarCaracterAzar()
        {
            Random oAzar = new Random();
            int n = oAzar.Next(26) + 65;
            System.Threading.Thread.Sleep(15);
            return ((char)n);
        }

        public static beCaptcha crear()
        {
            beCaptcha obeCaptcha = new beCaptcha();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.Append(generarCaracterAzar());
            }
            Bitmap bmp = new Bitmap(200, 80);
            Graphics grafico = Graphics.FromImage(bmp);
            Rectangle rect = new Rectangle(0, 0, 200, 80);
            LinearGradientBrush deg = new LinearGradientBrush
                (rect, Color.Aqua, Color.Blue, LinearGradientMode.BackwardDiagonal);
            grafico.FillRectangle(deg, rect);
            grafico.DrawString(sb.ToString(), new Font("Arial", 35), Brushes.White, 0, 10);
            Point punto1;
            Point punto2;
            Random oAzar = new Random();
            for (int i = 0; i < 5; i++)
            {
                punto1 = new Point(oAzar.Next(200), oAzar.Next(80));
                punto2 = new Point(oAzar.Next(200), oAzar.Next(80));
                grafico.DrawLine(new Pen(Brushes.Yellow, 2), punto1, punto2);
            }
            obeCaptcha.Codigo = sb.ToString();
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Jpeg);
                obeCaptcha.Imagen = ms.ToArray();
            }
            return (obeCaptcha);
        }


        private void crearCaptcha()
        {

            //Stopwatch oReloj = new Stopwatch();
            //oReloj.Start();
            beCaptcha obeCaptcha = crear();
            ViewState["codigo"] = obeCaptcha.Codigo;
            imgCaptcha.Src = String.Format("data:image/png;base64,{0}",
            Convert.ToBase64String(obeCaptcha.Imagen));

            //oReloj.Stop();
            //Response.Write("Duracion msg: " + oReloj.Elapsed.TotalMilliseconds);
        }


        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //if (txtRuc.Text.Length == 0)
            //{
            //    string msj = "Ingresa RUC";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
            //    return;
            //}

            if (txtCorreo.Text.Length == 0)
            {
                string msj = "Ingresa correo";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                return;
            }
            if (txtClave.Text.Length == 0)
            {
                string msj = "Ingresa clave";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                return;
            }


            oLN_Usuario = new LN_Usuario();
            ENT_Usuario oEnt_Usuario = new ENT_Usuario();
            //  oEnt_Usuario.Ruc=txtRuc.Text.Trim();
            oEnt_Usuario.Correo = txtCorreo.Text.Trim();
            oEnt_Usuario.Clave = txtClave.Text.Trim();

            int resultado = -1;
            int perfil = -1;
            string nombrecompleto = "SSS";
            int usuarioid = -1;
            int paquete = -1;
            int downgrade = -1;
            int restriccionip = -1;

            string codigoGenerado = ViewState["codigo"].ToString();
            string codigoIngresado = txtCodigo.Text;
            string ip = "";


            int PerfilUsuarioID = -1;
            int habilitado = -1;
            bool servicio = false;
            string ruc = string.Empty;



            //oLN_Usuario.ValidarUsuario(oEnt_Usuario, ref resultado, ref perfil, ref nombrecompleto, ref usuarioid);


            oLN_Usuario.ValidarUsuario(oEnt_Usuario
                , ref resultado
                , ref perfil
                , ref nombrecompleto
                , ref usuarioid
                , ref PerfilUsuarioID
                , ref habilitado
                , ref servicio
                , ref ruc
                , ref paquete
                , ref downgrade
                , ref restriccionip
                , ref ip
                , ref idioma
                );

            if (idioma.Equals(""))
                idioma = "ES";
            Session["Etiquetas"] = oLN_Idiona.ObtenerEtiquetasPorIdioma(idioma);
            Dictionary<string, string> etiquetas = (Dictionary<string, string>)Session["Etiquetas"];


            if (resultado == 0)
            {
                string msj = "";
                if (perfil == 5000)
                {
                    // msj = "Usuario no existe.";
                    msj = etiquetas["IS04"];
                }
                else
                {
                    if (habilitado == 2)
                    {
                        msj = "La cuenta está deshabilitada. Por favor contacte a su administrador.";
                    }
                    else
                    {
                        //msj = "Datos incorrectos.";
                        msj = etiquetas["IS03"];
                    }
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
            }
            else
            {
                Session["Perfil"] = perfil.ToString();
                Session["NombreCompleto"] = nombrecompleto.ToString();
                Session["UsuarioID"] = usuarioid.ToString();
                Session["PerfilUsuarioID"] = PerfilUsuarioID.ToString();
                Session["Servicio"] = servicio;
                Session["RUC"] = ruc;
                Session["Paquete"] = paquete;

                if (codigoGenerado.Equals(codigoIngresado))
                {
                    if (downgrade == 1 && PerfilUsuarioID != 1)
                    {
                        string msj = "No puede iniciar sesión hasta que el administrador configure los parámetros para su empresa.";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                    }
                    else
                    {
                        if (habilitado == 1)
                        {
                            WebClient wc = new WebClient();
                            string ipAddress = wc.DownloadString("http://icanhazip.com/");
                            int sizecadena = ipAddress.Length;
                            string ipsesion = ipAddress.Substring(0, sizecadena - 1);
                            if (restriccionip == 1 && (ip != ipsesion || !ip.Equals(ipsesion)))
                            {
                                string msj = "No puede iniciar sesión en una ubicación diferente a la indicada por el administrador.";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                            }
                            else
                            {
                                string msj = "Bienvenido a AL SISTEMA.";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);

                                switch (PerfilUsuarioID)
                                {
                                    case 1:

                                        //if (servicio == false)
                                        // {
                                        Response.Redirect("../iAdministrador/Inicio.aspx");
                                        //Server.transfer();
                                        //  }
                                        // else
                                        //  {
                                        //  Response.Redirect("../iAdministradors/Inicio.aspx");
                                        //  }

                                        break;

                                    case 2:
                                        //Response.Redirect("../iSupervisor/Inicio.aspx");
                                        Response.Redirect("../iAdministrador/Inicio.aspx");
                                        break;

                                    case 3:
                                        Response.Redirect("../iAnalista/Inicio.aspx");
                                        break;
                                }
                            }
                        }
                        else if (habilitado == 2)
                        {
                            string msj = "La cuenta está deshabilitada. Por favor contacte a su administrador.";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                        }
                    }
                }


                else
                {
                    //string msj = "Error código captcha.";
                    string msj = etiquetas["IS02"];
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
                    crearCaptcha();
                }

            }

        }

        protected void lbnActualizarCaptcha_Click(object sender, EventArgs e)
        {
            crearCaptcha();
        }
    }
}