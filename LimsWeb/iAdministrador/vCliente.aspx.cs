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
    public partial class vCliente : System.Web.UI.Page
    {
        ENT_RegistroTemporal oEnt_RegTemp = new ENT_RegistroTemporal();

        List<ENT_Cliente> oLista_Cliente = new List<ENT_Cliente>();

        LN_RegistroTemporal oLN_RegTemp = new LN_RegistroTemporal();
        LN_Pais oLN_Pais = new LN_Pais();
        LN_Rubro oLN_Rubro = new LN_Rubro();
        LN_Ciudad oLN_Ciudad = new LN_Ciudad();
        LN_Cliente oLN_Cliente = new LN_Cliente();
        LN_Empresa oLn_Empresa = new LN_Empresa();

        List<ENT_RegistroTemporal> oList_RegTemp = new List<ENT_RegistroTemporal>();
        List<ENT_Cliente> oList_Cliente = new List<ENT_Cliente>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oList_Cliente = oLN_Cliente.ListarClientesXEmpresa(Int32.Parse(Session["UsuarioID"].ToString()));
                lbClientes.DataSource = oList_Cliente;
                lbClientes.DataTextField = "NombreCliente";
                lbClientes.DataValueField = "ClienteID";
                lbClientes.DataBind();

                //CargarCombo(1, 0); //Cargar Lista Paises
                //CargarCombo(2, Int32.Parse(ddlPais.SelectedValue.ToString())); //Cargar Lista Ciudades


                if ((this.ViewState["Datos"] != null))
                {
                    oLista_Cliente = (List<ENT_Cliente>)(this.ViewState["Datos"]);
                    gvContactos.DataSource = oLista_Cliente;
                    gvContactos.DataBind();
                }
                else
                {
                    this.ViewState.Add("Datos", oLista_Cliente);
                    ViewState["Datos"] = new List<ENT_Cliente>();
                }


            }
        }

        protected void CargarCombo(int tipo, int filtro)
        {

            switch (tipo)
            {
                case 1: //CARGAR LISTA PAISES
                    List<ENT_Pais> oLista_Pais = new List<ENT_Pais>();
                    oLista_Pais = oLN_Pais.ListarPais();
                    ddlPais.DataSource = oLista_Pais;
                    ddlPais.DataTextField = "NombrePais";
                    ddlPais.DataValueField = "PaisID";
                    ddlPais.DataBind();
                    break;
                case 2: //CARGAR LISTA CIUDADES
                    List<ENT_Ciudad> oLista_Ciudad = new List<ENT_Ciudad>();
                    oLista_Ciudad = oLN_Ciudad.ListarCiudad(filtro);
                    //ddlCiudad.DataSource = oLista_Ciudad;
                    //ddlCiudad.DataTextField = "NombreCiudad";
                    //ddlCiudad.DataValueField = "CiudadID";
                    //ddlCiudad.DataBind();
                    break;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            int total = oLn_Empresa.VerificarRestriccion(Int32.Parse(Session["UsuarioID"].ToString()), "cliente", 0);
            int paquete = Int32.Parse(Session["Paquete"].ToString());
            if (total >= 2 && paquete == 0)
            {
                Response.Write("<script>alert('Ya llegó al límite de clientes permitidos en la licencia gratuita.');</script>");
            }
            else
            {
                oLN_Cliente.InsertarCliente(txtNomCliente.Text.Trim(), Int32.Parse(Session["UsuarioID"].ToString()));

                if (lbClientes.SelectedValue.Length > 0)
                {
                    LimpiarListaDatos();

                }
            }
            
            oList_Cliente = oLN_Cliente.ListarClientesXEmpresa(Int32.Parse(Session["UsuarioID"].ToString()));
            
            txtNomCliente.Text = "";
            lbClientes.DataSource = oList_Cliente;
            lbClientes.DataTextField = "NombreCliente";
            lbClientes.DataValueField = "ClienteID";
            lbClientes.DataBind();
            

        }

        public void LimpiarListaDatos()
        {


            oList_Cliente = oLN_Cliente.listarDatosCliente(Int32.Parse(lbClientes.SelectedValue.ToString()));
            lbNomEquipo.Text = lbClientes.SelectedItem.Text.Trim();
            string xmlString = string.Empty;

                foreach (ENT_Cliente oEnt_Cliente in oList_Cliente)
                {

                    txtNomCliente.Text = "";
                    txtRuc.Text = "";
                    txtRazonSocial.Text = "";
                    txtCiudad.Text = "";
                    txtDireccion.Text = "";
                    txtNombre.Text = "";

                    xmlString = oEnt_Cliente.Contacto;
                }

                string xmlString2 = xmlString.ToString();


                xmlString2 = xmlString2.Replace("<Contactos>", "");
                xmlString2 = xmlString2.Replace("</Contactos>", "");

                xmlString2 = xmlString2.Replace("<Nombre>", "");
                xmlString2 = xmlString2.Replace("<Telefono>", "");
                xmlString2 = xmlString2.Replace("<Email>", "");

                xmlString2 = xmlString2.Replace("<Contacto>", "");

                xmlString2 = xmlString2.Replace("</Contacto>", "{");

                xmlString2 = xmlString2.Replace("</Nombre>", "}");
                xmlString2 = xmlString2.Replace("</Telefono>", "[");
                xmlString2 = xmlString2.Replace("</Email>", "]");

                string[] bloques = xmlString2.Split('{');

                for (var i = 0; i < bloques.Count() - 1; i++)
                {

                    var bloque = bloques[i].ToString().Trim();

                    string[] nombres = bloque.Split('}');
                    var nombre = nombres[0].ToString().Trim();

                    string[] telefonos = nombres[1].ToString().Trim().Split('[');
                    var telefono = telefonos[0].ToString().Trim();

                    string[] emails = telefonos[1].ToString().Trim().Split(']');
                    var email = emails[0].ToString().Trim();

                    ENT_Cliente oEnt_Cliente = new ENT_Cliente();

                    oEnt_Cliente.NombreContacto = nombre;
                    oEnt_Cliente.TelefonoContacto = telefono;
                    oEnt_Cliente.EmailContacto = email;

                    //oLista_Cliente.Add(oEnt_Cliente);
                }

                this.ViewState.Add("Datos", oLista_Cliente);

                gvContactos.DataSource = oLista_Cliente;
                gvContactos.DataBind();

            

        }


        protected void QuitarSeleccionado_Click(object sender, EventArgs e)
        {
            int ClienteID = Int32.Parse(lbClientes.SelectedValue.ToString());

            if (!oLN_Cliente.EliminarCliente(ClienteID))
            {
                Response.Write("<script>alert('No se pudo eliminar porque el cliente tiene producto(s) asociado(s).');</script>");
            }
            else
            {
                Response.Write("<script>alert('Se eliminó el cliente con éxito.');</script>");
            }

            oList_Cliente = oLN_Cliente.ListarClientesXEmpresa(Int32.Parse(Session["UsuarioID"].ToString()));
            lbClientes.DataSource = oList_Cliente;
            lbClientes.DataTextField = "NombreCliente";
            lbClientes.DataValueField = "ClienteID";
            lbClientes.DataBind();
        }

        protected void lbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarListaDatos();
        }

        public void LlenarListaDatos()
        {
            oList_Cliente = oLN_Cliente.listarDatosCliente(Int32.Parse(lbClientes.SelectedValue.ToString()));
            lbNomEquipo.Text = lbClientes.SelectedItem.Text.Trim();

            string xmlString = string.Empty;

            foreach (ENT_Cliente oEnt_Cliente in oList_Cliente)
            {
                txtNombre.Text = oEnt_Cliente.NombreCliente;
                txtRuc.Text = oEnt_Cliente.Ruc;
                txtRazonSocial.Text = oEnt_Cliente.RazonSocial;
               /* if (oEnt_Cliente.PaisID != -1)
                {
                    ddlPais.SelectedValue = oEnt_Cliente.PaisID.ToString();
                }
                if (oEnt_Cliente.CiudadID != -1)
                {
                    //ddlCiudad.SelectedValue = oEnt_Cliente.CiudadID.ToString();
                }*/
                for (var i=0; i<ddlPais.Items.Count; i++)
                {
                    if(ddlPais.Items[i].Text.Equals(oEnt_Cliente.Pais))
                    {
                        ddlPais.ClearSelection();
                        ddlPais.SelectedIndex = i;
                    }
                }
                //ddlPais.SelectedItem.Text = oEnt_Cliente.Pais;
                txtCiudad.Text = oEnt_Cliente.Ciudad;
                txtDireccion.Text = oEnt_Cliente.Direccion;

                xmlString = oEnt_Cliente.Contacto;
            }

            string xmlString2 = xmlString.ToString();


            xmlString2 = xmlString2.Replace("<Contactos>", "");
            xmlString2 = xmlString2.Replace("</Contactos>", "");

            xmlString2 = xmlString2.Replace("<Nombre>", "");
            xmlString2 = xmlString2.Replace("<Telefono>", "");
            xmlString2 = xmlString2.Replace("<Email>", "");

            xmlString2 = xmlString2.Replace("<Contacto>", "");

            xmlString2 = xmlString2.Replace("</Contacto>", "{");

            xmlString2 = xmlString2.Replace("</Nombre>", "}");
            xmlString2 = xmlString2.Replace("</Telefono>", "[");
            xmlString2 = xmlString2.Replace("</Email>", "]");

            string[] bloques = xmlString2.Split('{');

            for (var i = 0; i < bloques.Count() - 1; i++)
            {

                var bloque = bloques[i].ToString().Trim();

                string[] nombres = bloque.Split('}');
                var nombre = nombres[0].ToString().Trim();

                string[] telefonos = nombres[1].ToString().Trim().Split('[');
                var telefono = telefonos[0].ToString().Trim();

                string[] emails = telefonos[1].ToString().Trim().Split(']');
                var email = emails[0].ToString().Trim();

                ENT_Cliente oEnt_Cliente = new ENT_Cliente();

                oEnt_Cliente.NombreContacto = nombre;
                oEnt_Cliente.TelefonoContacto = telefono;
                oEnt_Cliente.EmailContacto = email;

                oLista_Cliente.Add(oEnt_Cliente);
            }

            this.ViewState.Add("Datos", oLista_Cliente);

            gvContactos.DataSource = oLista_Cliente;
            gvContactos.DataBind();

            /*
                <Contactos>
                    <Contacto>
                        <Nombre></Nombre>
                        <Telefono></Telefono>
                        <Email></Email>
                    </Contacto>
                </Contactos>
            */

        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                ENT_Cliente oEnt_Cliente = new ENT_Cliente();
                oEnt_Cliente.NombreCliente = txtNombre.Text.Trim();
                oEnt_Cliente.Ruc = txtRuc.Text.Trim();
                oEnt_Cliente.RazonSocial = txtRazonSocial.Text.Trim();
                oEnt_Cliente.Direccion = txtDireccion.Text.Trim();
                //oEnt_Cliente.PaisID = Int32.Parse(ddlPais.SelectedValue.ToString().Trim());
                //oEnt_Cliente.CiudadID = Int32.Parse(ddlCiudad.SelectedValue.ToString().Trim());
                oEnt_Cliente.Pais = ddlPais.SelectedItem.Text;
                oEnt_Cliente.Ciudad = txtCiudad.Text;
                oEnt_Cliente.ClienteID = Int32.Parse(lbClientes.SelectedValue.ToString().Trim());

                result=oLN_Cliente.ActualizarDatos(oEnt_Cliente);


                if (result)
                {
                    Response.Write("<script>alert('Datos actualizados correctamente');</script>");
                    //LimpiarListaDatos();

                }
                else
                {
                    Response.Write("<script>alert('Ocurrió un error. Por favor intentelo nuevamente');</script>");
                }
            }
            catch {
                Response.Write("<script>alert('Seleccione un cliente');</script>");
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ENT_Cliente oEnt_Cliente = new ENT_Cliente();

            int ClienteID;
            try
            {
                ClienteID = Int32.Parse(lbClientes.SelectedValue.ToString());

            }
            catch
            {
                Response.Write("<script>alert('Seleccione un cliente');</script>");
                return;
            }

            //this.ViewState["Opciones"] = new List<ENT_ProductoAtributo>();
            oLista_Cliente = (List<ENT_Cliente>)(this.ViewState["Datos"]);

            oEnt_Cliente.NombreContacto = txtNomContacto.Text.Trim();
            oEnt_Cliente.TelefonoContacto = txtTelefono.Text.Trim();
            oEnt_Cliente.EmailContacto = txtCorreo.Text.Trim();

            oLista_Cliente.Add(oEnt_Cliente);

            string cadenaXML=string.Empty;
            cadenaXML = "<Contactos>";
            foreach (ENT_Cliente oEntidad in oLista_Cliente) {
                cadenaXML = cadenaXML + "<Contacto>";
                cadenaXML = cadenaXML + "<Nombre>" + oEntidad.NombreContacto + "</Nombre>";
                cadenaXML = cadenaXML + "<Telefono>" + oEntidad.TelefonoContacto + "</Telefono>";
                cadenaXML = cadenaXML + "<Email>" + oEntidad.EmailContacto + "</Email>";
                cadenaXML = cadenaXML + "</Contacto>";
            }
            cadenaXML = cadenaXML + "</Contactos>";

            
            oLN_Cliente.ActualizarContacto(cadenaXML,ClienteID);


            this.ViewState.Add("Datos", oLista_Cliente);
            gvContactos.DataSource = oLista_Cliente;
            gvContactos.DataBind();

            txtNomContacto.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }
    }
}