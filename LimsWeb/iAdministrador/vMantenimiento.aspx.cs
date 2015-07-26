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
    public partial class vMantenimiento : System.Web.UI.Page
    {
        
        List<ENT_Equipos> oLista_Equipo = new List<ENT_Equipos>();
        List<ENT_Mantenimiento> oLista_Mantenimiento = new List<ENT_Mantenimiento>();
        LN_Mantenimiento oLN_Mantenimiento = new LN_Mantenimiento();
        LN_Equipos oLN_Equipo = new LN_Equipos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                oLista_Equipo=oLN_Equipo.ListarEquiposLab(Session["LaboratorioCod"].ToString());
                ddlEquipo.DataSource = oLista_Equipo;
                ddlEquipo.DataTextField = "Nombre";
                ddlEquipo.DataValueField = "EquipoID";
                ddlEquipo.DataBind();

                oLista_Mantenimiento = oLN_Mantenimiento.ListarMantenimientos(1,Session["LaboratorioCod"].ToString());
                gvManteminiento.DataSource = oLista_Mantenimiento;
                gvManteminiento.DataBind();
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            bool resul = false;

            //OBTENEMOS LA FECHA DEL SISTEMA Y CONVERTIMOS LA FECPROG EN TIPO FECHA
            DateTime fecha = DateTime.Now;
            string fec = txtFecProgramada.Text.Trim();
            DateTime fecPro = Convert.ToDateTime(fec);

            //COMPARAMOS LAS 2 FECHAS
            int resultado = DateTime.Compare(fecPro, fecha);

            //VALIDAMOS SI LA FECHA ES MENOR A LA ACTUAL
            if (resultado < 0)
            {
                Response.Write("<script>alert('No se puede programar el mantenimiento en la fecha seleccionada.');</script>");

            }

            else
            {
                resul = oLN_Mantenimiento.AgregarMantenimiento(Int32.Parse(ddlEquipo.SelectedValue.ToString())
                                                    , txtFecProgramada.Text.Trim()
                                                    , txtOperador.Text.Trim());

                if (resul)
                {

                    txtOperador.Text = "";
                    txtFecProgramada.Text = "";
                    ddlEquipo.SelectedIndex = 0;

                    Response.Write("<script>alert('Se ha creado el mantenimiento correctamente.');</script>");

                    oLista_Mantenimiento = oLN_Mantenimiento.ListarMantenimientos(1, Session["LaboratorioCod"].ToString());
                    gvManteminiento.DataSource = oLista_Mantenimiento;
                    gvManteminiento.DataBind();




                }
                else
                {
                    return;
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resul=false;
            resul=oLN_Mantenimiento.FinalizarMantenimento(Int32.Parse(txtMantenimientoID.Text.Trim())
                                                    ,txtFecRealizado.Text.Trim()
                                                    ,txtObservaciones.Text.Trim());
            
             if (resul)
            {
                txtFecRealizado.Text = "";
                txtObservaciones.Text = "";

                Response.Write("<script>alert('Mantenimiento Terminado');</script>");
                
                oLista_Mantenimiento = oLN_Mantenimiento.ListarMantenimientos(1,Session["LaboratorioCod"].ToString());
                gvManteminiento.DataSource = oLista_Mantenimiento;
                gvManteminiento.DataBind();
            }
            else {
                return;
            }
        
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');

                oLN_Mantenimiento.EliminarMantenimiento(datos[0].ToString().Trim());

                oLista_Mantenimiento = oLN_Mantenimiento.ListarMantenimientos(1,Session["LaboratorioCod"].ToString());
                gvManteminiento.DataSource = oLista_Mantenimiento;
                gvManteminiento.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }



        public object yy { get; set; }
    }
}