using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LimsWeb.iAdministrador
{
    public partial class vPlanes : System.Web.UI.Page
    {
        protected string message;
        public String servicio;
        public String paquete;
        public String plan;


        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                   servicio = Session["Servicio"].ToString();
                   paquete = Session["Plan"].ToString();
                   plan = Session["Plan"].ToString();
                   message = Request.Params["message"].ToString();
            }catch(Exception ex){
                message = "Zona segura activa";
                Console.WriteLine(ex.Message);
            }
          

        }
    }
}