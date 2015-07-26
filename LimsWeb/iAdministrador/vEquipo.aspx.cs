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
    public partial class vEquipo : System.Web.UI.Page
    {
        List<ENT_Equipos> oLista_Equipos = new List<ENT_Equipos>();
        List<ENT_Mantenimiento> oLista_Mantenimiento = new List<ENT_Mantenimiento>();
        LN_Mantenimiento oLN_Mantenimiento = new LN_Mantenimiento();
        LN_Equipos oLN_Equipos = new LN_Equipos();

        List<ENT_Parametro> oLista_Parametro = new List<ENT_Parametro>();
        List<ENT_Parametro> oLista_Param = new List<ENT_Parametro>();
        LN_Parametro oLN_Parametro = new LN_Parametro();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oLista_Equipos = oLN_Equipos.ListarEquiposLab(Session["LaboratorioCod"].ToString());
                lbEquipos.DataSource = oLista_Equipos;
                lbEquipos.DataTextField = "Nombre";
                lbEquipos.DataValueField = "EquipoID";
                lbEquipos.DataBind();

                oLista_Param = oLN_Parametro.ListarParametro(Int32.Parse(Session["UsuarioID"].ToString()));
                ddlParametros.DataSource = oLista_Param;
                ddlParametros.DataTextField = "NomParametro";
                ddlParametros.DataValueField = "ParametroID";
                ddlParametros.DataBind();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ENT_Equipos oEnt_Equipo = new ENT_Equipos();

            oEnt_Equipo.Nombre = txtNomEquipo.Text.Trim();
            oEnt_Equipo.SerialNumber = txtMarca.Text.Trim() + " - " + txtModelo.Text.Trim();
            oEnt_Equipo.UsuarioID = Session["UsuarioID"].ToString();
            string labCod = Session["LaboratorioCod"].ToString();
            oEnt_Equipo.LaboratorioCod = labCod;
            oLN_Equipos.InsertarEquipo(oEnt_Equipo);


            oLista_Equipos = oLN_Equipos.ListarEquiposLab(labCod);
            lbEquipos.DataSource = oLista_Equipos;
            lbEquipos.DataTextField = "Nombre";
            lbEquipos.DataValueField = "EquipoID";
            lbEquipos.DataBind();


            txtNomEquipo.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtNomEquipo.Focus();



        }

        protected void lbEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {

            lbNomEquipo.Text = lbEquipos.SelectedItem.ToString();

            oLista_Parametro = oLN_Parametro.ListarParametroXEquipo(Int32.Parse(lbEquipos.SelectedValue.ToString()));
            lbParametro.DataSource = oLista_Parametro;
            lbParametro.DataTextField = "NomParametro";
            lbParametro.DataValueField = "ParEqpID";
            lbParametro.DataBind();

        }

        protected void QuitarParamSeleccionado_Click(object sender, EventArgs e)
        {
            bool resul=false;
            resul = oLN_Parametro.QuitarParametroEquipo(Int32.Parse(lbParametro.SelectedValue.ToString()));

            if (resul)
            {
                oLista_Parametro = oLN_Parametro.ListarParametroXEquipo(Int32.Parse(lbEquipos.SelectedValue.ToString()));
                lbParametro.DataSource = oLista_Parametro;
                lbParametro.DataTextField = "NomParametro";
                lbParametro.DataValueField = "ParEqpID";
                lbParametro.DataBind();
                return;
            }
            else
            {
                Response.Write("<script>alert('No se puede eliminar el parametro porque esta siendo utilizado en otros procesos');</script>");
            }
        }

        protected void QuitarSeleccionado_Click(object sender, EventArgs e)
        {
            int existe = -1;
            bool resul = false;

            resul = oLN_Equipos.QuitarEquipo(Int32.Parse(lbEquipos.SelectedValue.ToString()), ref existe);

            if (resul)
            {
                oLista_Equipos = oLN_Equipos.ListarEquiposLab(Session["LaboratorioCod"].ToString());
                lbEquipos.DataSource = oLista_Equipos;
                lbEquipos.DataTextField = "Nombre";
                lbEquipos.DataValueField = "EquipoID";
                lbEquipos.DataBind();
                return;
            }
            else
            {
                Response.Write("<script>alert('No se puede eliminar el equipo porque esta siendo utilizado en otros procesos');</script>");
            }
        }

        protected void btnIngresarParametro_Click(object sender, EventArgs e)
        {
            if (lbEquipos.SelectedValue.ToString().Equals("") || lbEquipos.SelectedValue.ToString().Equals(null))
            {
                Response.Write("<script>alert('Seleccionar Equipo');</script>");
            }
            else
            {
                oLN_Parametro.InsertarParametroEquipo(Int32.Parse(ddlParametros.SelectedValue.ToString()), Int32.Parse(lbEquipos.SelectedValue.ToString()));

                oLista_Parametro = oLN_Parametro.ListarParametroXEquipo(Int32.Parse(lbEquipos.SelectedValue.ToString()));
                lbParametro.DataSource = oLista_Parametro;
                lbParametro.DataTextField = "NomParametro";
                lbParametro.DataValueField = "ParEqpID";
                lbParametro.DataBind();
            }
        }

    }
}