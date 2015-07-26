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
    public partial class vEditarParametro : System.Web.UI.Page
    {
        LN_UnidadMedida oLN_UM = new LN_UnidadMedida();
        LN_TipoParametro oLN_TipoParametro = new LN_TipoParametro();
        LN_Formula oLN_Formula = new LN_Formula();
        LN_Parametro oLN_Parametro = new LN_Parametro();
        string ProdParaCod = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ProdParaCod = Session["ProdParaCod"].ToString();
            try
            {
                lblParametro.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString() + "/" + Session["NomParametro"].ToString();
                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
            }
            catch
            {
                Response.Redirect("../iRegistro/Login.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {
                cargarCombos(1, 0);
                cargarCombos(2, 0);
                cargarCombos(3, 0);
                ENT_ProductoParametro oEnt_ProdPara = new ENT_ProductoParametro();
                oEnt_ProdPara = oLN_Parametro.ObtenerDatosParametro(Session["ProdParaCod"].ToString());


                if (oEnt_ProdPara.TiempoEstimado.ToString() == "")
                {
                    txtHoras.Text = "00";
                    txtMinutos.Text = "00";
                    txtSegundos.Text = "00";
                }
                else 
                {
                    string fecha    = oEnt_ProdPara.TiempoEstimado.ToString();
                    string[] datos = fecha.Split(':');
                    txtHoras.Text = datos[0].ToString();
                    txtMinutos.Text = datos[1].ToString();
                    txtSegundos.Text = datos[2];
                }
                ddlUM.SelectedValue = oEnt_ProdPara.UnidadMedidaID.ToString();
                ddlTipoParametro.SelectedValue = oEnt_ProdPara.TipoParametroID.ToString();
                ddlFormula.SelectedValue = oEnt_ProdPara.FormulaID.ToString();
                txtCalculado.Text = oEnt_ProdPara.Calculado;
                txtMinAdvertencia.Text = oEnt_ProdPara.MinAdvertencia.ToString();
                txtMaxAdvertencia.Text = oEnt_ProdPara.MaxAdvertencia.ToString();
                txtPromedio.Text = oEnt_ProdPara.Promedio.ToString();
                txtMinAccion.Text = oEnt_ProdPara.MinAccion.ToString();
                txtMaxAccion.Text = oEnt_ProdPara.MaxAccion.ToString();

            }


        }

        protected void cargarCombos(int tipo, int filtro)
        {

            switch (tipo)
            {
                case 1: //CARGAR LISTA UNIDAD DE MEDIDA
                    List<ENT_UnidadMedida> oLista_UM = new List<ENT_UnidadMedida>();
                    oLista_UM = oLN_UM.ListarUM();
                    ddlUM.DataSource = oLista_UM;
                    ddlUM.DataTextField = "NombreUM";
                    ddlUM.DataValueField = "UnidadMedidaID";
                    ddlUM.DataBind();
                    break;

                case 2: //CARGAR LISTA TIPO PARAMETRO
                    List<ENT_TipoParametro> oLista_TipoParametro = new List<ENT_TipoParametro>();
                    oLista_TipoParametro = oLN_TipoParametro.ListarTipoParametro();
                    ddlTipoParametro.DataSource = oLista_TipoParametro;
                    ddlTipoParametro.DataTextField = "NomParametro";
                    ddlTipoParametro.DataValueField = "TipoParametroID";
                    ddlTipoParametro.DataBind();
                    break;

                case 3: //CARGAR LISTA FORMULAS
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
            switch (txtHoras.Text.Trim().Length)
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
            }

            #endregion

            tiempo = hora + ":" + min + ":" + seg;

            ENT_ProductoParametro oEnt_Parametro = new ENT_ProductoParametro();

            oEnt_Parametro.TiempoEstimado = tiempo;
            oEnt_Parametro.UnidadMedidaID = Int32.Parse(ddlUM.SelectedValue.ToString());
            oEnt_Parametro.TipoParametroID = Int32.Parse(ddlTipoParametro.SelectedValue.ToString());
            oEnt_Parametro.FormulaID = Int32.Parse(ddlFormula.SelectedValue.ToString());
            oEnt_Parametro.Calculado = txtCalculado.Text.Trim();
            oEnt_Parametro.MinAdvertencia = decimal.Parse(txtMinAdvertencia.Text.Trim());
            oEnt_Parametro.MaxAdvertencia = decimal.Parse(txtMaxAdvertencia.Text.Trim());
            oEnt_Parametro.Promedio = decimal.Parse(txtPromedio.Text.Trim());
            oEnt_Parametro.MinAccion = decimal.Parse(txtMinAccion.Text.Trim());
            oEnt_Parametro.MaxAccion = decimal.Parse(txtMaxAccion.Text.Trim());
            oEnt_Parametro.ProdParaCod = ProdParaCod;

            resul = oLN_Parametro.CompletarDatosParametro(oEnt_Parametro);

            if (resul)
            {
                Response.Write("<script>alert('Datos actualizados correctamente');</script>");


                ENT_ProductoParametro oEnt_ProdPara = new ENT_ProductoParametro();
                oEnt_ProdPara = oLN_Parametro.ObtenerDatosParametro(Session["ProdParaCod"].ToString());


                if (oEnt_ProdPara.TiempoEstimado.ToString() == "")
                {
                    txtHoras.Text = "00";
                    txtMinutos.Text = "00";
                    txtSegundos.Text = "00";
                }
                else
                {
                    string fecha = oEnt_ProdPara.TiempoEstimado.ToString();
                    string[] datos = fecha.Split(':');
                    txtHoras.Text = datos[0].ToString();
                    txtMinutos.Text = datos[1].ToString();
                    txtSegundos.Text = datos[2];
                }
                ddlUM.SelectedValue = oEnt_ProdPara.UnidadMedidaID.ToString();
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
}