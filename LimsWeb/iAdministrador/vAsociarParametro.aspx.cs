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
    public partial class vAsociarProducto : System.Web.UI.Page
    {
        LN_Parametro oLN_Parametro = new LN_Parametro();
        ENT_Parametro oEnt_Producto = new ENT_Parametro();

        List<ENT_ProductoParametro> oLista_ProdPara = new List<ENT_ProductoParametro>();
        List<ENT_Parametro> oLista_Parametro = new List<ENT_Parametro>();

        LN_UnidadMedida oLN_UM = new LN_UnidadMedida();
        LN_TipoParametro oLN_TipoParametro = new LN_TipoParametro();
        LN_Formula oLN_Formula = new LN_Formula();
        string ProdParaCod = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblProducto.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString();
            lblWinTitle.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString();

            Session["ProdLabID"] = "1";
            try
            {
                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
            }
            catch
            {
                Response.Redirect("../iRegistro/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                oLista_Parametro = oLN_Parametro.ListarParametro(Int32.Parse(Session["UsuarioID"].ToString()));
                lbProductos.DataSource = oLista_Parametro;
                lbProductos.DataTextField = "NomParametro";
                lbProductos.DataValueField = "ParametroID";
                lbProductos.DataBind();

                oLista_ProdPara = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());
                lbAgregados.DataSource = oLista_ProdPara;
                lbAgregados.DataTextField = "NomParametro";
                lbAgregados.DataValueField = "ProdParaID";
                lbAgregados.DataBind();

                cargarCombos(1, 0);
                cargarCombos(2, 0);
                cargarCombos(3, 0);

            }
        }


        protected void lbAgregados_OnSelectedIndexChanged(object sender, System.EventArgs e) {
            ENT_ProductoParametro oEnt_ProdPara = new ENT_ProductoParametro();
            oEnt_ProdPara = oLN_Parametro.ObtenerDatosParam(Int32.Parse(lbAgregados.SelectedValue.ToString()));

            int tipo = oEnt_ProdPara.TipoParametroID;
            switch (tipo)
            {
                case 1: ddlFormula.Visible = false;
                    txtCalculado.Visible = false;

                    break;
                case 2: ddlFormula.Visible = false;
                    txtCalculado.Visible = true;

                    break;
                case 3:
                    ddlFormula.Visible = true;
                    txtCalculado.Visible = false;
                    break;



            }
            lblParametro.Text = "Parámetro: "+lbAgregados.SelectedItem.Text.Trim();
            if (oEnt_ProdPara.TiempoEstimado.ToString() == "")
            {
                /*txtHoras.Text = "00";
                txtMinutos.Text = "00";
                txtSegundos.Text = "00";*/
                txtTiempo.Text = "0";
            }
            else
            {
                string fecha = oEnt_ProdPara.TiempoEstimado.ToString();
                /*string[] datos = fecha.Split(':');
                txtHoras.Text = datos[0].ToString();
                txtMinutos.Text = datos[1].ToString();
                txtSegundos.Text = datos[2];*/
                txtTiempo.Text = fecha;
            }
            try
            {
                txtUnidadMedida.Text = oEnt_ProdPara.UnidadMedida.ToString();
            }
            catch { }
           
            ddlTipoParametro.SelectedValue = oEnt_ProdPara.TipoParametroID.ToString();
            try
            {
                ddlFormula.SelectedValue = oEnt_ProdPara.FormulaID.ToString();
            }
            catch { 
            }
            txtCalculado.Text = oEnt_ProdPara.Calculado;
            txtMinAdvertencia.Text = oEnt_ProdPara.MinAdvertencia.ToString();
            txtMaxAdvertencia.Text = oEnt_ProdPara.MaxAdvertencia.ToString();
            txtPromedio.Text = oEnt_ProdPara.Promedio.ToString();
            txtMinAccion.Text = oEnt_ProdPara.MinAccion.ToString();
            txtMaxAccion.Text = oEnt_ProdPara.MaxAccion.ToString();
            txtNumDecimales.Text = oEnt_ProdPara.NumDecimales.ToString();
        }
        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            ENT_Producto oEntidad = new ENT_Producto();
            int resultado = -1;
            foreach (ListItem li in lbProductos.Items)
            {
                if (li.Selected)
                {
                    oLN_Parametro.AsociarParametro(Int32.Parse(li.Value), Session["ProdLabCod"].ToString(), 1, ref resultado);

                    if (resultado == 1)
                    {
                        Response.Write("<script>alert('El parámetro ya se encuentra agregado');</script>");
                        return;
                    }
                    else
                    {
                        oLista_ProdPara = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());
                        lbAgregados.DataSource = oLista_ProdPara;
                        lbAgregados.DataTextField = "NomParametro";
                        lbAgregados.DataValueField = "ProdParaID";
                        lbAgregados.DataBind();

                    //    ((MasterPages.Principal)this.Master).CargarTreeView();
                    }

                }
            }
        }



        protected void btnQuitar_Click(object sender, ImageClickEventArgs e)
        {
            ENT_Producto oEntidad = new ENT_Producto();

            foreach (ListItem li in lbAgregados.Items)
            {
                if (li.Selected)
                {
/* Verifificar si el parametro tiene muestra asociadas.
 * En caso que las tenga, Mostrar un mensaje informandole
 * que no se puede eliminar hasta que se eliminen las muestras
 * */
                    oLN_Parametro.QuitarProdPara(Int32.Parse(li.Value));
                }
            }

            oLista_ProdPara = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());
            lbAgregados.DataSource = oLista_ProdPara;
            lbAgregados.DataTextField = "NomParametro";
            lbAgregados.DataValueField = "ProdParaID";
            lbAgregados.DataBind();

          //  ((MasterPages.Principal)this.Master).CargarTreeView();
        }


        protected void cargarCombos(int tipo, int filtro)
        {

            switch (tipo)
            {
                /*case 1: //CARGAR LISTA UNIDAD DE MEDIDA
                    List<ENT_UnidadMedida> oLista_UM = new List<ENT_UnidadMedida>();
                    ddlUM.DataSource = oLN_UM.ListarUM();
                     //= oLista_UM;
                    ddlUM.DataTextField = "NombreUM";
                    ddlUM.DataValueField = "UnidadMedidaID";
                    ddlUM.DataBind();
                    break;*/

                case 1: //CARGAR LISTA TIPO PARAMETRO
                    List<ENT_TipoParametro> oLista_TipoParametro = new List<ENT_TipoParametro>();
                    ddlTipoParametro.DataSource = oLN_TipoParametro.ListarTipoParametro();
                    //ddlTipoParametro.DataSource = oLista_TipoParametro;
                    ddlTipoParametro.DataTextField = "NomParametro";
                    ddlTipoParametro.DataValueField = "TipoParametroID";
                    ddlTipoParametro.DataBind();
                    break;

                case 2: //CARGAR LISTA FORMULAS
                    List<ENT_Formula> oLista_Formula = new List<ENT_Formula>();
                    oLista_Formula = oLN_Formula.ListarFormula();
                    ddlFormula.DataSource = oLista_Formula;
                    ddlFormula.DataTextField = "NombreFormula";
                    ddlFormula.DataValueField = "FormulaID";
                    ddlFormula.DataBind();
                    break;
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string hora = string.Empty;
            string min = string.Empty;
            string seg = string.Empty;
            string tiempo = string.Empty;
            bool resul = false;

            #region  "Dando formato al tiempo estimado"
            /*switch (txtHoras.Text.Trim().Length)
            {
                case 0:
                    hora = "00";
                    break;
                case 1:
                    hora = "0" + txtHoras.Text.Trim();
                    break;
                case 2:
                    hora = txtHoras.Text.Trim();
                    break;
            }

            switch (txtMinutos.Text.Trim().Length)
            {
                case 0:
                    min = "00";
                    break;
                case 1:
                    min = "0" + txtMinutos.Text.Trim();
                    break;
                case 2:
                    min = txtMinutos.Text.Trim();
                    break;
            }

            switch (txtSegundos.Text.Trim().Length)
            {
                case 0:
                    seg = "00";
                    break;
                case 1:
                    seg = "0" + txtSegundos.Text.Trim();
                    break;
                case 2:
                    seg = txtSegundos.Text.Trim();
                    break;
            }*/

            #endregion

            //tiempo = hora + ":" + min + ":" + seg;
            tiempo = txtTiempo.Text;

            ENT_ProductoParametro oEnt_Parametro = new ENT_ProductoParametro();

            oEnt_Parametro.TiempoEstimado = tiempo;
            //oEnt_Parametro.UnidadMedidaID = Int32.Parse(ddlUM.SelectedValue.ToString());
            oEnt_Parametro.UnidadMedida = txtUnidadMedida.Text;
            oEnt_Parametro.TipoParametroID = Int32.Parse(ddlTipoParametro.SelectedValue.ToString());
            oEnt_Parametro.FormulaID = Int32.Parse(ddlFormula.SelectedValue.ToString());
            oEnt_Parametro.Calculado = txtCalculado.Text.Trim();
            oEnt_Parametro.NumDecimales = Int32.Parse(txtNumDecimales.Text.Trim());
            oEnt_Parametro.MinAdvertencia = decimal.Parse(txtMinAdvertencia.Text.Trim());
            oEnt_Parametro.MaxAdvertencia = decimal.Parse(txtMaxAdvertencia.Text.Trim());
            oEnt_Parametro.Promedio = decimal.Parse(txtPromedio.Text.Trim());
            oEnt_Parametro.MinAccion = decimal.Parse(txtMinAccion.Text.Trim());
            oEnt_Parametro.MaxAccion = decimal.Parse(txtMaxAccion.Text.Trim());
            oEnt_Parametro.ProdParaID = Int32.Parse(lbAgregados.SelectedValue.ToString());

            if (oEnt_Parametro.MinAccion >= oEnt_Parametro.MinAdvertencia ||
                oEnt_Parametro.MinAccion >= oEnt_Parametro.MaxAdvertencia ||
                oEnt_Parametro.MinAccion >= oEnt_Parametro.Promedio ||
                oEnt_Parametro.MinAccion >= oEnt_Parametro.MaxAccion ||

                oEnt_Parametro.MinAdvertencia >= oEnt_Parametro.MaxAdvertencia ||
                oEnt_Parametro.MinAdvertencia >= oEnt_Parametro.Promedio ||
                oEnt_Parametro.MinAdvertencia >= oEnt_Parametro.MaxAccion ||

                oEnt_Parametro.Promedio >= oEnt_Parametro.MaxAdvertencia ||
                oEnt_Parametro.Promedio >= oEnt_Parametro.MaxAccion ||

                oEnt_Parametro.MaxAdvertencia >= oEnt_Parametro.MaxAccion)
            {
                Response.Write("<script>alert('Los datos no se han actualizado! Verifique los valores de mínimos, promedio y máximos');</script>");
                txtTiempo.Text = "";
                txtUnidadMedida.Text = "";
                txtMinAccion.Text = "";
                txtMinAdvertencia.Text = "";
                txtPromedio.Text = "";
                txtMaxAdvertencia.Text = "";
                txtMaxAccion.Text = "";
                txtCalculado.Text = "";
                txtNumDecimales.Text = "";
                
            }
            else
            {
                resul = oLN_Parametro.CompletarDatosParametro(oEnt_Parametro);
                if (resul)
                {
                    Response.Write("<script>alert('Datos actualizados correctamente');</script>");


                    ENT_ProductoParametro oEnt_ProdPara = new ENT_ProductoParametro();
                    oEnt_ProdPara = oLN_Parametro.ObtenerDatosParam(Int32.Parse(lbAgregados.SelectedValue.ToString()));

                    if (oEnt_ProdPara.TiempoEstimado.ToString() == "")
                    {
                        /* txtHoras.Text = "00";
                         txtMinutos.Text = "00";
                         txtSegundos.Text = "00";*/
                        txtTiempo.Text = "0";
                    }
                    else
                    {
                        string fecha = oEnt_ProdPara.TiempoEstimado.ToString();
                        /*string[] datos = fecha.Split(':');
                        txtHoras.Text = datos[0].ToString();
                        txtMinutos.Text = datos[1].ToString();
                        txtSegundos.Text = datos[2];*/
                        txtTiempo.Text = fecha;
                    }
                    try
                    {
                        txtUnidadMedida.Text = oEnt_ProdPara.UnidadMedida.ToString();
                    }
                    catch { }
                    ddlTipoParametro.SelectedValue = oEnt_ProdPara.TipoParametroID.ToString();
                    ddlFormula.SelectedValue = oEnt_ProdPara.FormulaID.ToString();
                    txtCalculado.Text = oEnt_ProdPara.Calculado;
                    txtMinAdvertencia.Text = oEnt_ProdPara.MinAdvertencia.ToString();
                    txtMaxAdvertencia.Text = oEnt_ProdPara.MaxAdvertencia.ToString();
                    txtPromedio.Text = oEnt_ProdPara.Promedio.ToString();
                    txtMinAccion.Text = oEnt_ProdPara.MinAccion.ToString();
                    txtMaxAccion.Text = oEnt_ProdPara.MaxAccion.ToString();
                }

                else
                {
                    Response.Write("<script>alert('Ocurrio un error. Porfavor intentalo nuevamente');</script>");
                }


            }

        }

        protected void ddlTipoParametro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipo = Int32.Parse(ddlTipoParametro.SelectedValue.ToString());

            switch (tipo) 
            {
                case 1: ddlFormula.Visible = false;
                        txtCalculado.Visible = false;

                    break;
                case 2: ddlFormula.Visible = false;
                    txtCalculado.Visible = true;

                    break;
                case 3:
                    ddlFormula.Visible = true;
                    txtCalculado.Visible = false;
                    break;
            }

        }

    }
}