using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LimsWeb.iAdministrador
{
    public partial class vSubirLogo : System.Web.UI.Page
    {
        ENT_Empresa oEnt_Empresa = new ENT_Empresa();
        LN_Empresa oLn_Empresa = new LN_Empresa();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Subir_Click(object sender, System.EventArgs e)
        {
            if ((logo.PostedFile != null) && (logo.PostedFile.ContentLength > 0))
            {
                string fn = "LE-" + Session["RUC"].ToString() + ".png";
                string SaveLocation = Server.MapPath("~\\Content") + "\\logos\\" + fn;
                try
                {
                    oEnt_Empresa.Ruc = Session["RUC"].ToString();
                    oEnt_Empresa.PathLogo = "http://" + HttpContext.Current.Request.Url.Authority + "/Content/logos/" + fn;
                    logo.PostedFile.SaveAs(SaveLocation);
                    if (oLn_Empresa.ListarInfoEmpresa(oEnt_Empresa.Ruc).PathLogo.Equals(""))
                    {
                        oLn_Empresa.ActualizarLogoEmpresa(oEnt_Empresa);
                    }
                    Response.Write("<script>alert('El archivo se subió correctamente.')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }

    }
}