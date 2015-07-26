using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;


namespace LimsWeb.iAdministrador
{
    public partial class AsociarParametro : System.Web.UI.Page
    {
        LN_Parametro oLN_Parametro = new LN_Parametro();
        LN_Muestra oLN_Muestra = new LN_Muestra();

        List<ENT_ProductoParametro> oLista_ProdPara = new List<ENT_ProductoParametro>();
        List<ENT_ProductoAtributo> oLista_Atributo = new List<ENT_ProductoAtributo>();
        List<ENT_Parametro> oLista_Parametro = new List<ENT_Parametro>();
        List<ENT_Muestra> oLista_Muestra = new List<ENT_Muestra>();
        List<ENT_Muestra> oLista_MuestraAttr = new List<ENT_Muestra>();

        ENT_Parametro oEnt_Producto = new ENT_Parametro();
        ENT_Muestra oEnt_Muestra = new ENT_Muestra();


        protected void Page_Load(object sender, EventArgs e)
        {

            Session["ProdLabID"] = "1";
            try
            {
                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
                Session["NomProducto"].ToString();
                Session["ProdLabCod"].ToString();
            }
            catch
            {
                Response.Redirect("../iRegistro/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblProducto.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString();

                oLista_Muestra = oLN_Muestra.ListarMuestras(Session["ProdLabCod"].ToString());
                oLista_ProdPara = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());
                oLista_Atributo = oLN_Parametro.ListarAtributoXLab(Session["ProdLabCod"].ToString());

                qtProductos.Value = oLista_ProdPara.Count.ToString();
                qtAtributos.Value = oLista_Atributo.Count.ToString();

                gvMuestra.DataSource = oLista_Muestra;
                gvMuestra.DataBind();
            }
            else 
            { }

        }



        protected void btnInforme_Click(object sender, EventArgs e)
        {
            List<ENT_ProductoParametro> oLista_Parametro = new List<ENT_ProductoParametro>();
            oLista_Parametro = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());
            bool existe = false; 
            if(oLista_Parametro.Count<=0)
            {
                Response.Write("<script>alert('No existen parametros asociados a este producto.');</script>");
                return;
                
            }
            else
            {
                foreach (ENT_ProductoParametro oEntidad in oLista_Parametro)
                {
                    List<ENT_Parametro> oEnt_Parametro = new List<ENT_Parametro>();
                    oEnt_Parametro = oLN_Parametro.ObtenerDatosMuestraParametro(oEntidad.ProdParaCod);
                    if(oEnt_Parametro.Count>0)
                    {
                        existe = true;
                    }
                }
                if (!existe)
                {
                    Response.Write("<script>alert('No existen resultados para los parametros asociados al producto.');</script>");
                }
                else
                {
                    Response.Redirect("Producto.aspx");
                }        
            }
        }
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');
                int MuestraID = 0;
                MuestraID = Int32.Parse(datos[0].ToString().Trim());

                oLista_Muestra = oLN_Muestra.ObtenerMuestras(MuestraID);
                oLista_MuestraAttr = oLN_Muestra.ObtenerMuestrasAttr(MuestraID);

                foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
                {

                    oLista_Muestra.Add(oEnti);
                }


                gvInfoMuestra.DataSource = oLista_Muestra;
                gvInfoMuestra.DataBind();
                lblNombreMuestra.Text = "Muestra : " + (datos[1].ToString().Trim()).ToString();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al cargar datos..." + ex.Message + "');</script>");
            }
        }




        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');

                oLN_Muestra.EliminarMuestraCabecera(Int32.Parse(datos[0].ToString().Trim()));
                oLista_Muestra = oLN_Muestra.ListarMuestras(Session["ProdLabCod"].ToString());
                gvMuestra.DataSource = oLista_Muestra;
                gvMuestra.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }


        protected void btnEliminarMuestraDetalle_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');

                oLN_Muestra.EliminarMuestraDetalle(Int32.Parse(datos[0].ToString().Trim())); //MuestraDetalleID



                int MuestraID = Int32.Parse(datos[1].ToString().Trim());

                oLista_Muestra = oLN_Muestra.ObtenerMuestras(MuestraID);
                oLista_MuestraAttr = oLN_Muestra.ObtenerMuestrasAttr(MuestraID);

                foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
                {

                    oLista_Muestra.Add(oEnti);
                }


                gvInfoMuestra.DataSource = oLista_Muestra;
                gvInfoMuestra.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }


    }
}
