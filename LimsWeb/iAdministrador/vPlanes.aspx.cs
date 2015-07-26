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
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                  String message = Request.Params["message"].ToString();
                  Response.Write("<script>showMessage("+message+");</script>");
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
          

        }
    }
}