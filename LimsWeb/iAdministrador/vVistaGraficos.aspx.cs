using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Entidades;

namespace LimsWeb.iAdministrador
{
    public partial class vVistaGraficos : System.Web.UI.Page
    {
        LN_Parametro oLN_Parametro = new LN_Parametro();
        List<ENT_ProductoParametro> oLista_ProdPara = new List<ENT_ProductoParametro>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oLista_ProdPara = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());

                rParametros.DataSource = oLista_ProdPara;
                rParametros.DataBind();

            }
        }

        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem ri = e.Item;
            var dataItem = ri.DataItem as ENT_ProductoParametro;
            var chk = ri.FindControl("chk") as CheckBox;
            if (Int32.Parse(dataItem.FlagVgrafico) == 1)
                chk.Checked = true;
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                 int counter = 0;
                 String prodLabCod = Session["ProdLabCod"].ToString();
                 if (oLN_Parametro.DeshabilitaFlProdParam(prodLabCod))
                 {
                     for (int i = 0; i < rParametros.Items.Count; i++)
                     {
                         CheckBox chk = (CheckBox)rParametros.Items[i].FindControl("chk");
                         var p = (ENT_ProductoParametro)rParametros.Items[i].DataItem;
                         if (chk.Checked && counter < 4)
                         {
                             oLN_Parametro.ActualizarProdParam(prodLabCod, chk.Text);
                             counter++;
                         }
                     }
                 }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al guardar las opciones..." + ex.Message + "');</script>");
            }
        }
    }
}