using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.Globalization;

namespace LimsWeb.iAdministrador
{
    

    public partial class Inicio : System.Web.UI.Page
    {
        LN_Laboratorio oLN_Lab = new LN_Laboratorio();
        LN_Empresa oLN_Emp = new LN_Empresa();
        ENT_Empresa oEnt_Emp = new ENT_Empresa();
        ENT_Empresa oEnt_Emp2 = new ENT_Empresa();

        List<ENT_Laboratorio> oLista_Lab = new List<ENT_Laboratorio>();
        protected string enlace_2;
        protected string enlace_3;
        protected string url_2;
        protected string url_3;
        
        
        protected string info;
        protected string rz;
        protected string country;
        protected string city;
        protected string rb;
        protected string segment;
        protected string dir;
        protected string type;
        protected string plans;


        protected void Page_Load(object sender, EventArgs e)
        {
            string ruc = string.Empty;
          
            
            try
            {
                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
                Dictionary<string, string> etiquetas = (Dictionary<string, string>)Session["Etiquetas"];

                ruc = (Session["RUC"].ToString());

                info = etiquetas["INFO"];
                rz = etiquetas["RZ"];
                country = etiquetas["COUNTRY"];
                city = etiquetas["CITY"];
                rb = etiquetas["RB"];
                segment = etiquetas["SEGMENT"];
                dir = etiquetas["DIR"];
                type = etiquetas["TYPE"];


                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("../iRegistro/Login.aspx");
            }


            if (!IsPostBack)
            {
                oLista_Lab = oLN_Lab.ListarLaboratorioXEmpresa(Int32.Parse(Session["UsuarioID"].ToString()));
                for (int i = 0; i < oLista_Lab.Count;i++ )
                {
                    string nomSupervisor = oLN_Lab.ObtenerSupervisor(oLista_Lab[i].LaboratorioID).Trim();
                    if (nomSupervisor.Equals("") || nomSupervisor.Equals(null) || nomSupervisor.Equals(" "))
                    {
                        oLista_Lab[i].NomUsuario = "No asignado";
                    }
                    else
                    {
                        oLista_Lab[i].NomUsuario = nomSupervisor;
                    }
                    
                }
                gvLaboratorio.DataSource = oLista_Lab;
                gvLaboratorio.DataBind();

                oEnt_Emp = oLN_Emp.ListarInfoEmpresa(ruc);

                txtRuc.Text = ruc;
                txtRazonSocial.Text = oEnt_Emp.RazonSocial;
                txtNomPais.Text = oEnt_Emp.NomPais;
                txtNomCiudad.Text = oEnt_Emp.NomCiudad;
                txtNomRubro.Text = oEnt_Emp.NomRubro;
                txtDireccion.Text = oEnt_Emp.Direccion;
                txtDom.Text = oEnt_Emp.segmento;
               

                if (oEnt_Emp.Servicio)
                {
                    txtUso.Text = "Servicio";
                   
                }
                else
                {
                    txtUso.Text = "Privado";
                }

                //Plan actual
                if (oEnt_Emp.TipoUsoID == 1)
                {
                    txtPlanes.Text = "Gratuito";
                   
                }
                else if (oEnt_Emp.TipoUsoID == 2)
                {
                    txtPlanes.Text = "Básico";
                }
                else {
                    txtPlanes.Text = "Corporativo";
                }

                Session["Plan"] = txtPlanes.Text;
                
                //PUBLICIDAD INICIO 1
                oEnt_Emp = oLN_Emp.ListarPubInicio1(ruc);
                string imagen1 = oEnt_Emp.imagen;
                                
                if (imagen1 == null || imagen1.Equals(""))
                {
                    url_2 = "http://lapa-tec.com/backend/img_publicidad/default/img_2.jpg";
                    enlace_2 = "https://play.google.com/store/apps/details?id=net.wasitec.activity";
                }
                else
                {
                    url_2 = "http://lapa-tec.com/backend/img_publicidad/" + imagen1;
                    enlace_2 = oEnt_Emp.enlace;
                }

                //PUBLICIDAD INICIO 2
                oEnt_Emp2 = oLN_Emp.ListarPubInicio2(ruc);
                string imagen2 = oEnt_Emp2.imagen;

                if (imagen2 == null || imagen2.Equals(""))
                {
                    url_3 = "http://lapa-tec.com/backend/img_publicidad/default/img_3.jpg";
                    enlace_3 = "https://play.google.com/store/apps/details?id=net.wasitec.sieveanalisis";
                }
                else
                {
                    url_3 = "http://lapa-tec.com/backend/img_publicidad/" + imagen2;
                    enlace_3 = oEnt_Emp.enlace;
                }

            }

        }
    }
}