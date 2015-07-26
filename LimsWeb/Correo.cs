using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace LimsWeb
{
    public class Correo
    {

        /*
         * Cliente SMTP
         * Gmail:  smtp.gmail.com  puerto:587
         * Hotmail: smtp.live.com  puerto:25
         */
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
        
        public Correo()
        {
            /*
             * Autenticacion en el Servidor
             * Utilizaremos nuestra cuenta de correo
             *
             * Direccion de Correo (Gmail o Hotmail)
             * y Contrasena correspondiente
             */
            server.Credentials = new System.Net.NetworkCredential("lapa@wasitec.net", "l@p@2014");
            server.EnableSsl = true;
        }

        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }

    }
}