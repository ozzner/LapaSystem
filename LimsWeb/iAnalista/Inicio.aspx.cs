using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.Data;

namespace LimsWeb.iAnalista
{
    /*
     * me quede en el procedimiento [SLW_SP_RegistrarUsoEquipo], ya esta terminado
     */
    public partial class Inicio : System.Web.UI.Page
    {
        LN_Muestra oLN_Muestra = new LN_Muestra();
        List<ENT_Muestra> oLista_Muestra = new List<ENT_Muestra>();
        List<ENT_Muestra> oLista_MuestraAttr = new List<ENT_Muestra>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try {


                    oLista_Muestra = oLN_Muestra.ListarMuestrasPendientes(Int32.Parse(Session["UsuarioID"].ToString()));
                    oLista_MuestraAttr = oLN_Muestra.ListarMuestrasPendientesAttr(Int32.Parse(Session["UsuarioID"].ToString()));

                    foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
                    {
                        oLista_Muestra.Add(oEnti);
                    }

                    gvMuestra.DataSource = oLista_Muestra;
                    gvMuestra.DataBind();


                    oLista_Muestra = oLN_Muestra.ListarEnProceso(Int32.Parse(Session["UsuarioID"].ToString()));
                    oLista_MuestraAttr = oLN_Muestra.ListarEnProcesoAttr(Int32.Parse(Session["UsuarioID"].ToString()));

                    foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
                    {
                        oLista_Muestra.Add(oEnti);
                    }

                    gvEnProceso.DataSource = oLista_Muestra;
                    gvEnProceso.DataBind();

                    oLista_Muestra = oLN_Muestra.ListarTerminado(Int32.Parse(Session["UsuarioID"].ToString()));
                    oLista_MuestraAttr = oLN_Muestra.ListarTerminadoAttr(Int32.Parse(Session["UsuarioID"].ToString()));

                    foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
                    {
                        oLista_Muestra.Add(oEnti);
                    }

                    gvTerminados.DataSource = oLista_Muestra;
                    gvTerminados.DataBind();

                }catch {
                    Response.Redirect("../iRegistro/Login.aspx");
                
                }


             
            }

        }


        protected void btnPasarATerminado_Command(object sender, CommandEventArgs e)
        {
            prodMD.Text = "";
            prioMD.Text = "";
            fechMD.Text = "";
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');

                oLN_Muestra.PasarAEnProceso(Int32.Parse(datos[0].ToString().Trim()), Int32.Parse(Session["UsuarioID"].ToString()));


                oLista_Muestra = oLN_Muestra.ListarMuestrasPendientes(Int32.Parse(Session["UsuarioID"].ToString()));
                oLista_MuestraAttr = oLN_Muestra.ListarMuestrasPendientesAttr(Int32.Parse(Session["UsuarioID"].ToString()));

                foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
                {
                    oLista_Muestra.Add(oEnti);

                }

                gvMuestra.DataSource = oLista_Muestra;
                gvMuestra.DataBind();

                oLista_Muestra = oLN_Muestra.ListarEnProceso(Int32.Parse(Session["UsuarioID"].ToString()));
                oLista_MuestraAttr = oLN_Muestra.ListarEnProcesoAttr(Int32.Parse(Session["UsuarioID"].ToString()));

                foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
                {
                    oLista_Muestra.Add(oEnti);
                }

                gvEnProceso.DataSource = oLista_Muestra;
                gvEnProceso.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }

        protected void btnVolverAEnCola_Command(object sender, CommandEventArgs e)
        {
            string strID = e.CommandArgument.ToString();
            if(oLN_Muestra.VolverAEnCola(Int32.Parse(strID)))
            {
                Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            else
            {
                Response.Write("<script>alert('Ocurrio un error en el servidor');</script>");
            }
        }

        protected void btnPasarAEnProceso_Command(object sender, CommandEventArgs e)
        {
            txtFormula.Text = "";
            prodMD.Text = "";
            prioMD.Text = "";
            fechMD.Text = "";
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');

                int MuestraDetalleID = Int32.Parse(datos[0].ToString().Trim());
                int TipoParametroID = Int32.Parse(datos[1].ToString().Trim());
                string NomParametro = datos[2].ToString().Trim();
                string Muestra = datos[3].ToString().Trim();
                string Formula = datos[4].ToString().Trim();
                DateTime FecFinE = DateTime.Parse(datos[5].ToString().Trim());

                txtMuestraa.Text = Muestra;
                txtParametroo.Text = NomParametro;
                txtTimeFin.Text = FecFinE.ToString("yyyy-MM-dd HH:mm:ss");

                ENT_Atributo oEnt_Atributo = new ENT_Atributo();


                scrollProcesoDetalle.Visible = true;
                btnTerminar.Enabled = true;

                if (Formula.Equals(""))
                {
                    
                    List<ENT_Muestra> oListaVacia = new List<ENT_Muestra>();
                    repResultado.DataSource = oListaVacia;
                    repResultado.DataBind();

                    List<ENT_Atributo> oLista = new List<ENT_Atributo>();
                    oEnt_Atributo = oLN_Muestra.ListarOpciones(MuestraDetalleID);
                    txtMuestraDetalleID.Text = MuestraDetalleID.ToString();
                    string opciones = oEnt_Atributo.Opciones.ToString();

                    opciones = opciones.Replace("<Atributo><Opcion>", "");
                    opciones = opciones.Replace("<Opcion><Atributo>", "");
                    opciones = opciones.Replace("</Atributo>", "");
                    opciones = opciones.Replace("</Opcion>", "");
                    opciones = opciones.Replace("<Opcion>", "{");


                    string[] datoss = opciones.Split('{');

                    for (int i = 0; i < datoss.Count(); i++)
                    {
                        ENT_Atributo oEntii = new ENT_Atributo();
                        oEntii.NomAtributo = datoss[i].ToString().Trim();
                        oLista.Add(oEntii);
                    }

                    repOpcion.Enabled = true;
                    chkEquipoUsado.Visible = false;
                    repOpcion.Visible = true;
                    lblEqpUtilizados.Text = "OPCIONES DE ATRIBUTO";
                    para_atri.Text = "Atributo";
                    repOpcion.DataSource = oLista;
                    repOpcion.DataTextField = "NomAtributo";
                    repOpcion.DataBind();
                   // MyTimer.Visible = false;
                    

                }
                else
                {
                    List<ENT_Muestra> oListaVacia = new List<ENT_Muestra>();

                    repOpcion.DataSource = oListaVacia;
                    repOpcion.DataBind();


                    //repOpciones.DataSource = oListaVacia;
                    //repOpciones.DataBind();

                    txtFormula.Text = Formula;
                    txtTipoParametroID.Text = TipoParametroID.ToString();
                    txtMuestraDetalleID.Text = MuestraDetalleID.ToString();
                    switch (TipoParametroID)
                    {
                        case 1:
                            List<ENT_Muestra> oLista = new List<ENT_Muestra>();
                            ENT_Muestra oEnt_Muestra = new ENT_Muestra();
                            oEnt_Muestra.Nombre = "Resultado";
                            oLista.Add(oEnt_Muestra);
                            repResultado.DataSource = oLista;   
                            repResultado.DataBind();
                            break;

                        case 3:
                            List<ENT_Muestra> oListaaaa = new List<ENT_Muestra>();
                            Formula = Formula.Replace("(", "");
                            Formula = Formula.Replace(")", "");

                            string[] variables = Formula.Split('+', '-', '*', '/');

                            foreach (string variable in variables)
                            {
                                ENT_Muestra oEnt_M = new ENT_Muestra();
                                oEnt_M.Nombre = variable.ToString();

                                oListaaaa.Add(oEnt_M);
                            }

                            repResultado.DataSource = oListaaaa;
                            repResultado.DataBind();
                            break;
                    }

                    List<ENT_Equipos> oLista_Equipos = new List<ENT_Equipos>();
                    LN_Equipos oLN_Equipo = new LN_Equipos();

                    lblEqpUtilizados.Text = "OPCIONES DE EQUIPO";
                    repOpcion.Visible = false;
                    chkEquipoUsado.Visible = true;
                   // MyTimer.Visible = true;
                    para_atri.Text = "Parametro";
                    oLista_Equipos = oLN_Equipo.ListarEquiposParametro(MuestraDetalleID);
                    chkEquipoUsado.DataSource = oLista_Equipos;
                    chkEquipoUsado.DataTextField = "Nombre";
                    chkEquipoUsado.DataValueField = "EquipoID";
                    chkEquipoUsado.DataBind();

                }

                //repEquipoUsado.DataSource = oLista_Equipos;
                //repEquipoUsado.DataBind();

                /*
                 * SI ES MANUAL MOSTRARME UN CUADRO 
                 * PARA INGRESAR EL RESUTLADO y/o OPCIONES
                 * MOSTRARME LOS EQUIPOS ASOCIADOS A ESTE
                 * 
                 */

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al mostrar los detalles..." + ex.Message + "');</script>");
            }
        }


        protected void btnLlenarMD_Command(object sender, CommandEventArgs e)
        {
            string strID = e.CommandArgument.ToString();
            string[] datos = strID.Split('{');


            DateTime fechaRegistro = DateTime.Parse(datos[0].ToString());
            string nomProducto = datos[1].ToString();
            string prioridad = datos[2].ToString().Trim();

            prodMD.Text = nomProducto;
            prioMD.Text = prioridad;
            fechMD.Text = fechaRegistro.ToString();
        }


        protected void btnTerminar_Click(object sender, EventArgs e)
        {

            string Formula = txtFormula.Text.Trim();
            string result = string.Empty;

            if (Formula.Equals(""))
            {
                try
                {
                    if (repOpcion.SelectedItem == null)
                    {
                        Response.Write("<script>alert('Seleccione una opción de atributo');</script>");
                        return;
                    }

                    oLN_Muestra.InsertarResultadoAttr(repOpcion.SelectedItem.Text.ToString(), Int32.Parse(txtMuestraDetalleID.Text));
                }
                catch {
                    oLN_Muestra.InsertarResultadoAttr("Vacio", Int32.Parse(txtMuestraDetalleID.Text));
                }
            }
            else
            {
                bool existEquipo = false;
                foreach (ListItem item in chkEquipoUsado.Items)
                {
                    if (item.Selected)
                        existEquipo = true;
                }
                if(!existEquipo)
                {
                                        
                    foreach (Control item in repResultado.Items)
                        {
                            TextBox txtResultado = (TextBox)item.FindControl("txtResultado");
                            Label lblTitulo = (Label)item.FindControl("lblTitulo");

                            switch (Int32.Parse(txtTipoParametroID.Text))
                            {
                                case 1:
                                    result = txtResultado.Text.Trim();
                                    
                                    if (result.Contains("0") ||
                                        result.Contains("1") ||
                                        result.Contains("2") ||
                                        result.Contains("3") ||
                                        result.Contains("4") ||
                                        result.Contains("5") ||
                                        result.Contains("6") ||
                                        result.Contains("7") ||
                                        result.Contains("8") ||
                                        result.Contains("9") ||
                                        result.Contains("."))
                                    {
                                        Response.Write("<script>alert('No ha seleccionado ningún equipo.');</script>");
                                        break;
                                    }

                                    else
                                    {
                                        Response.Write("<script>alert('Formato de resultado no válido. Verifique los datos ingresados.');</script>");
                                        return;
                                    }
                                    

                                case 3:
                                    string titulo = lblTitulo.Text.Trim();
                                    string resultado = txtResultado.Text.Trim();
                                    Formula = Formula.Replace(titulo, resultado);
                                    break;

                            }

                        }

                        int MuestraDetalleID = Int32.Parse(txtMuestraDetalleID.Text);

                        switch (Int32.Parse(txtTipoParametroID.Text))
                        {

                            case 1:
                                //oLN_Muestra.InsertarResultado(decimal.Parse(result), MuestraDetalleID);
                                oLN_Muestra.InsertarResultado(result, MuestraDetalleID);
                                break;
                            case 3:
                                result = Convert.ToString(Eval(Formula));
                                //oLN_Muestra.InsertarResultado(decimal.Parse(result), MuestraDetalleID);
                                oLN_Muestra.InsertarResultado(result, MuestraDetalleID);
                                break;
                        }

                        string listaEquipos = "";
                        oLN_Muestra.RegistrarEquiposUsados(listaEquipos, Int32.Parse(txtMuestraDetalleID.Text));
                
                    
                }
                else
                {
                foreach (Control item in repResultado.Items)
                {
                    TextBox txtResultado = (TextBox)item.FindControl("txtResultado");
                    Label lblTitulo = (Label)item.FindControl("lblTitulo");

                    switch (Int32.Parse(txtTipoParametroID.Text))
                    {
                        case 1:
                            result = txtResultado.Text.Trim();

                            if (result.Contains("0") ||
                                result.Contains("1") ||
                                result.Contains("2") ||
                                result.Contains("3") ||
                                result.Contains("4") ||
                                result.Contains("5") ||
                                result.Contains("6") ||
                                result.Contains("7") ||
                                result.Contains("8") ||
                                result.Contains("9") ||
                                result.Contains("."))
                            {
                                
                                break;
                            }

                            else
                            {
                                Response.Write("<script>alert('Formato de resultado no válido. Verifique los datos ingresados.');</script>");
                                return;
                            }

                        case 3:
                            string titulo = lblTitulo.Text.Trim();
                            string resultado = txtResultado.Text.Trim();
                            Formula = Formula.Replace(titulo, resultado);
                            break;

                    }

                }

                int MuestraDetalleID = Int32.Parse(txtMuestraDetalleID.Text);

                switch (Int32.Parse(txtTipoParametroID.Text))
                {

                    case 1:
                        //oLN_Muestra.InsertarResultado(decimal.Parse(result), MuestraDetalleID);
                        oLN_Muestra.InsertarResultado(result, MuestraDetalleID);
                        break;
                    case 3:
                        result = Convert.ToString(Eval(Formula));
                        //oLN_Muestra.InsertarResultado(decimal.Parse(result), MuestraDetalleID);
                        oLN_Muestra.InsertarResultado(result, MuestraDetalleID);
                        break;
                }

                string listaEquipos = string.Empty;
                foreach (ListItem chkEquipo in chkEquipoUsado.Items)
                {
                    if (chkEquipo.Selected)
                    {
                        oLN_Muestra.RegistrarUsoEquipo(Int32.Parse(chkEquipo.Value), Int32.Parse(txtMuestraDetalleID.Text));
                        listaEquipos = listaEquipos + chkEquipo.Text+" - ";
                    }
                }

                int size = listaEquipos.Length;

                listaEquipos = listaEquipos.Substring(0, (size - 2));

                oLN_Muestra.RegistrarEquiposUsados(listaEquipos, Int32.Parse(txtMuestraDetalleID.Text));
                }
            }
            oLista_Muestra = oLN_Muestra.ListarMuestrasPendientes(Int32.Parse(Session["UsuarioID"].ToString()));
            oLista_MuestraAttr = oLN_Muestra.ListarMuestrasPendientesAttr(Int32.Parse(Session["UsuarioID"].ToString()));

            foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
            {
                oLista_Muestra.Add(oEnti);

            }

            gvMuestra.DataSource = oLista_Muestra;
            gvMuestra.DataBind();

            oLista_Muestra = oLN_Muestra.ListarEnProceso(Int32.Parse(Session["UsuarioID"].ToString()));
            oLista_MuestraAttr = oLN_Muestra.ListarEnProcesoAttr(Int32.Parse(Session["UsuarioID"].ToString()));

            foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
            {
                oLista_Muestra.Add(oEnti);
            }

            gvEnProceso.DataSource = oLista_Muestra;
            gvEnProceso.DataBind();

           

            oLista_Muestra      = oLN_Muestra.ListarTerminado(Int32.Parse(Session["UsuarioID"].ToString()));
            oLista_MuestraAttr  = oLN_Muestra.ListarTerminadoAttr(Int32.Parse(Session["UsuarioID"].ToString()));

            foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
            {
                oLista_Muestra.Add(oEnti);
            }

            gvTerminados.DataSource = oLista_Muestra;
            gvTerminados.DataBind();

            txtMuestraa.Text = String.Empty;
            txtParametroo.Text = String.Empty;

            /*Deshabilitando controles*/
            repOpcion.Visible = false;
            lblEqpUtilizados.Text = "OPCIONES";
            chkEquipoUsado.Visible = false;
            scrollProcesoDetalle.Visible = false;
            repOpcion.Enabled = false;
            //btnTerminar.Enabled = True;
        }



        private object Eval(string eqn)
        {
            DataTable dt = new DataTable();
            var result = dt.Compute(eqn, string.Empty);
            return result;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            oLista_Muestra = oLN_Muestra.ListarMuestrasPendientes(Int32.Parse(Session["UsuarioID"].ToString()));
            oLista_MuestraAttr = oLN_Muestra.ListarMuestrasPendientesAttr(Int32.Parse(Session["UsuarioID"].ToString()));

            foreach (ENT_Muestra oEnti in oLista_MuestraAttr)
            {
                oLista_Muestra.Add(oEnti);
            }

            gvMuestra.DataSource = oLista_Muestra;
            gvMuestra.DataBind();

        }





    }
}