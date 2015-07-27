using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.IO;
using System.Text;

namespace LimsWeb.iRegistro
{
    public partial class Registro : System.Web.UI.Page
    {
        ENT_RegistroTemporal oEnt_RegTemp = new ENT_RegistroTemporal();

        LN_RegistroTemporal oLN_RegTemp = new LN_RegistroTemporal();
        LN_Pais oLN_Pais = new LN_Pais();
        LN_Rubro oLN_Rubro = new LN_Rubro();
        LN_Ciudad oLN_Ciudad = new LN_Ciudad();

        List<ENT_RegistroTemporal> oList_RegTemp = new List<ENT_RegistroTemporal>();

        protected string complete;
        protected string ruc_nit;
        protected string company;
        protected string info;
        protected string rz;
        protected string country;
        protected string city;
        protected string rb;
        protected string segment;
        protected string type;
        protected string user;
        protected string email;
        protected string clave;
        protected string conf_clave;
        protected string language;
        protected string address;
        protected string domain;
        protected string terminos;

        public String lang;


        protected void Page_Load(object sender, EventArgs e)
        {
            setVisibleFalse();
            int resultado = -1;
            string serial = "";


            lang = Request.UserLanguages[0];

            if (lang.Contains("es"))
            {
                complete = "COMPLETE EL REGISTRO";
                ruc_nit = "RUC / INIT";
                company = "EMPRESA";

                rz = "RazónSocial";
                country = "País";
                city = "Ciudad";
                rb = "Rubro";
                segment = "Segmento";
                type = "Tipo de uso";
                user = "USUARIO";
                email = "Correo";
                clave = "Clave";
                conf_clave = "Confirmar clave";
                language = "Idioma";
                address = "Dirección";
                domain = "Dominio";
                terminos = "Al hacer clic en 'Finalizar Registro', usted está de acuerdo con nuestros Términos y Condiciones.";
                chkAceptar.Text = "Estoy de acuerdo";
                btnFinalizar.Text = "FINALIZAR";



            }
            if (lang.Contains("en"))
            {
                complete = "COMPLETE THE REGISTER";
                ruc_nit = "RUC / INIT";
                company = "COMPANY";

                rz = "Name Company";
                country = "Country";
                city = "City";
                rb = "Category";
                segment = "Segment";
                type = "Tipe of use";
                user = "USER";
                email = "Email";
                clave = "Password";
                conf_clave = "Confirm Password";
                language = "Language";
                address = "Address";
                domain = "Domain";
                terminos = "Clicking 'Finish Registration' , you agree to our Terms and Conditions.";
                chkAceptar.Text = "I agree";
                btnFinalizar.Text = "END";


            }

            try
            {
                serial = Session["serial"].ToString();
            }
            catch { }
            oList_RegTemp = oLN_RegTemp.VerificarSerial(serial, ref resultado);

            if (oList_RegTemp.Count == 0)
            {
                return;
            }

            foreach (ENT_RegistroTemporal oEntidad in oList_RegTemp)
            {
                txtRazonSocial.Text = oEntidad.RazonSocial;
                txtCorreo.Text = oEntidad.Correo;
                txtCorreoE.Text = oEntidad.Correo;
                txtDominio.Text = oEntidad.Dominio;
            }
            if (!Page.IsPostBack)
            {
                CargarCombo(1, 0); //Cargar Lista Paise
                //int paisNumero = Int32.Parse(pais);
                //CargarCombo(2, Int32.Parse(ddlPais.SelectedValue.ToString())); //Cargar Lista Ciudades
                //CargarCombo(3, 0); //Cargar Lista Ciudades
            }
            //   CargarCombo(2, Int32.Parse(ddlPais.SelectedValue.ToString())); //Cargar Lista Ciudades
        }


        protected void CargarCombo(int tipo, int filtro)
        {

            switch (tipo)
            {
                case 1: //CARGAR LISTA PAISES
                    //List<ENT_Pais> oLista_Pais = new List<ENT_Pais>();
                    //oLista_Pais = oLN_Pais.ListarPais();
                    //ddlPais.DataSource = oLista_Pais;
                    //ddlPais.DataTextField = "NombrePais";
                    //ddlPais.DataValueField = "PaisID";
                    //ddlPais.DataBind();
                    break;
                case 2: //CARGAR LISTA CIUDADES
                    //List<ENT_Ciudad> oLista_Ciudad = new List<ENT_Ciudad>();
                    //oLista_Ciudad = oLN_Ciudad.ListarCiudad(filtro);
                    //ddlCiudad.DataSource = oLista_Ciudad;
                    //ddlCiudad.DataTextField = "NombreCiudad";
                    //ddlCiudad.DataValueField = "CiudadID";
                    //ddlCiudad.DataBind();
                    break;
                case 3: //CARGAR LISTA RUBROS
                    List<ENT_Rubro> oLista_Rubro = new List<ENT_Rubro>();
                    oLista_Rubro = oLN_Rubro.ListarRubro();
                    ddlRubro.DataSource = oLista_Rubro;
                    ddlRubro.DataTextField = "NombreRubro";
                    ddlRubro.DataValueField = "RubroID";
                    ddlRubro.DataBind();
                    break;
            }
        }


        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (chkAceptar.Checked)
            { }
            else
            {
                string msj = "Para poder finalizar el registro estar de acuerdo con los términos y condiciones";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "RechazaContrato", "alert('" + msj + "');", true);
                return;
            }

            ENT_Empresa oEnt_Empresa = new ENT_Empresa();
            ENT_Usuario oEnt_Usuario = new ENT_Usuario();

            LN_Empresa oLN_Empresa = new LN_Empresa();
            LN_Usuario oLN_Usuario = new LN_Usuario();

            oEnt_Empresa.Ruc = txtRuc.Text.Trim();
            oEnt_Empresa.RazonSocial = txtRazonSocial.Text.Trim();
            //oEnt_Empresa.PaisID = Int32.Parse(ddlPais.SelectedValue.ToString());
            //oEnt_Empresa.PaisID = ddlPais.SelectedValue.ToString();
            oEnt_Empresa.PaisID = ddlPais.SelectedItem.ToString();
            //oEnt_Empresa.CiudadID = Int32.Parse(ddlCiudad2.Text.ToString());
            oEnt_Empresa.CiudadID = ddlCiudad2.Text.ToString();
            oEnt_Empresa.Direccion = txtDireccion.Text.Trim();
            //oEnt_Empresa.RubroID = Int32.Parse(ddlRubro.SelectedValue.ToString());
            oEnt_Empresa.RubroID = ddlRubro.SelectedValue.ToString();
            oEnt_Empresa.nomLab = "Laboratorio";
            oEnt_Empresa.ubicacion = txtDireccion.Text;

            switch (ddlRubro.SelectedValue.ToString())
            {
                case "alimentos animal":
                    oEnt_Empresa.segmento = segmento1.SelectedValue.ToString(); break;
                case "alimentos consumo":
                    oEnt_Empresa.segmento = segmento2.SelectedValue.ToString(); break;
                case "alimentos insumos":
                    oEnt_Empresa.segmento = segmento3.SelectedValue.ToString(); break;
                case "industrial extraccion":
                    oEnt_Empresa.segmento = segmento4.SelectedValue.ToString(); break;
                case "industrial farma":
                    oEnt_Empresa.segmento = segmento5.SelectedValue.ToString(); break;
                case "industrial maquilado":
                    oEnt_Empresa.segmento = segmento6.SelectedValue.ToString(); break;
                case "industrial quimico":
                    oEnt_Empresa.segmento = segmento7.SelectedValue.ToString(); break;
                case "industrial vestido":
                    oEnt_Empresa.segmento = segmento8.SelectedValue.ToString(); break;
            }

            oEnt_Empresa.Dominio = txtDominio.Text.Trim();
            oEnt_Empresa.Correo = txtCorreo.Text.Trim();

            oEnt_Usuario.Nombre = txtNombre.Text.Trim();
            oEnt_Usuario.Correo = txtCorreoE.Text.Trim();
            oEnt_Usuario.Clave = txtClave.Text.Trim();
            oEnt_Empresa.Idioma = ddlIdioma.SelectedValue.ToString();

            if (rbEmpresa.Checked)
            {
                oEnt_Usuario.Servicio = false;
            }
            else
            {
                oEnt_Usuario.Servicio = true;
            }

            int resultado = -1;
            oLN_Empresa.InsertarNuevaEmpresa(oEnt_Empresa, oEnt_Usuario, ref resultado);

            if (resultado == 0)
            {
                string msj = "Registro almacenado correctamente. ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "RegistroCompletado", "alert('" + msj + "');", true);

                txtRuc.Text = "";
                txtRazonSocial.Text = "";
                txtDireccion.Text = "";
                txtDominio.Text = "";
                txtCorreo.Text = "";

                txtNombre.Text = "";
                txtCorreoE.Text = "";
                txtClave.Text = "";
                txtClaveConf.Text = "";



                Response.Redirect("../iRegistro/Login.aspx");
            }
            else
            {
                string msj = "No se completo el registro. Se ha detectado que el numero de RUC ya se encuentra registrado en el sistema";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MostrarMensaje", "alert('" + msj + "');", true);
            }
        }


        protected void ddlRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sValue = ddlRubro.Text.ToString();

            switch (sValue)
            {
                case "alimentos animal":
                    setVisibleFalse();
                    segmento1.Visible = true;
                    break;
                case "alimentos consumo":
                    setVisibleFalse();
                    segmento2.Visible = true;
                    break;
                case "alimentos insumos":
                    setVisibleFalse();
                    segmento3.Visible = true;
                    break;
                case "industrial extraccion":
                    setVisibleFalse();
                    segmento4.Visible = true;
                    break;
                case "industrial farma":
                    setVisibleFalse();
                    segmento5.Visible = true;
                    break;
                case "industrial maquilado":
                    setVisibleFalse();
                    segmento6.Visible = true;
                    break;
                case "industrial quimico":
                    setVisibleFalse();
                    segmento7.Visible = true;
                    break;
                case "industrial vestido":
                    setVisibleFalse();
                    segmento8.Visible = true;
                    break;
            }
        }

        private void setVisibleFalse()
        {

            segmento1.Visible = false;
            segmento2.Visible = false;
            segmento3.Visible = false;
            segmento4.Visible = false;
            segmento5.Visible = false;
            segmento6.Visible = false;
            segmento7.Visible = false;
            segmento8.Visible = false;

        }

        private void setVisibleTrue()
        {

            segmento1.Visible = true;
            segmento2.Visible = true;
            segmento3.Visible = true;
            segmento4.Visible = true;
            segmento5.Visible = true;
            segmento6.Visible = true;
            segmento7.Visible = true;
            segmento8.Visible = true;

        }


    }

}
