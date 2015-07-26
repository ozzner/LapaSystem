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
    public partial class vLaboratorio : System.Web.UI.Page
    {
        LN_Usuario oLn_Usuario = new LN_Usuario();
        List<ENT_Usuario> oList_Usuario = new List<ENT_Usuario>();
        List<ENT_Laboratorio> oList_Lab = new List<ENT_Laboratorio>();
        LN_PerfilUsuario oLn_PerfilUsuario = new LN_PerfilUsuario();
        LN_Laboratorio oLn_Laboratorio = new LN_Laboratorio();
        LN_Empresa oLn_Empresa = new LN_Empresa();

        ENT_Producto oEnt_Producto = new ENT_Producto();
        LN_Producto oLN_Producto = new LN_Producto();
        List<ENT_Producto> oLista_Producto = new List<ENT_Producto>();

        protected void Page_Load(object sender, EventArgs e)
        {

            //   Session["UsuarioID"] = 13;

            try
            {
                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
                oLista_Producto = oLN_Producto.ListarProducto(Int32.Parse(Session["UsuarioID"].ToString()));
              

            }
            catch
            {
                Response.Redirect("../iRegistro/Login.aspx");
                return;
            }


            if (!IsPostBack)
            {
                oList_Lab = oLn_Laboratorio.ListarLaboratorio(Int32.Parse(Session["UsuarioID"].ToString()));
                gvLaboratorio.DataSource = oList_Lab;
                gvLaboratorio.DataBind();

            }

         //   if (!Page.IsPostBack)
         //   {
         //       CargarCombo(1, 0); //Cargar Lista PerfilUsuario
         //       CargarCombo(2, Int32.Parse(Session["UsuarioID"].ToString())); //Cargar Lista Laboratorio
         //   }

        }


        //protected void CargarCombo(int tipo, int filtro)
        //{
        //    switch (tipo)
        //    {
        //        case 1: //CARGAR PerfilUsuario
        //            List<ENT_PerfilUsuario> oLista_PerfilUsuario = new List<ENT_PerfilUsuario>();
        //            oLista_PerfilUsuario = oLn_PerfilUsuario.ListarPerfilUsuario();
        //            ddlPerfilUsuario.DataSource = oLista_PerfilUsuario;
        //            ddlPerfilUsuario.DataTextField = "NomPerfilUsuario";
        //            ddlPerfilUsuario.DataValueField = "PerfilUsuarioID";
        //            ddlPerfilUsuario.DataBind();
        //            break;
        //        case 2: //CARGAR Laboratorio
        //            List<ENT_Laboratorio> oLista_Laboratorio = new List<ENT_Laboratorio>();
        //            oLista_Laboratorio = oLn_Laboratorio.ListarLaboratorio(filtro);
        //            ddlLaboratorio.DataSource = oLista_Laboratorio;
        //            ddlLaboratorio.DataTextField = "NomLaboratorio";
        //            ddlLaboratorio.DataValueField = "LaboratorioID";
        //            ddlLaboratorio.DataBind();
        //            break;
        //    }
        //}


        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int labID = Int32.Parse(e.CommandArgument.ToString());
                //string[] datos = strID.Split('{');


                oLista_Producto = oLN_Producto.ListarProductoXLabID(labID.ToString());
                int prodLab = oLista_Producto.Count();

                if (prodLab > 0)
                {
                    Response.Write("<script>alert('Operación denegada. El laboratorio contiene uno o más productos. Deberá eliminar previamente los productos que contiene.');</script>");
                }
                else
                {
                    oLn_Laboratorio.EliminarLaboratorio(labID);
                }
                
                oList_Lab = oLn_Laboratorio.ListarLaboratorio(Int32.Parse(Session["UsuarioID"].ToString()));
                gvLaboratorio.DataSource = oList_Lab;
                gvLaboratorio.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }


        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string strID = e.CommandArgument.ToString();
                string[] datos = strID.Split('{');


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al eliminar..." + ex.Message + "');</script>");
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            ENT_Laboratorio oEnt_Laboratorio = new ENT_Laboratorio();
            Dictionary<string,string> etiquetas = (Dictionary<string,string>) Session["Etiquetas"];

            oEnt_Laboratorio.Ubicacion = txtDescProducto.Text.Trim();
            oEnt_Laboratorio.NomLaboratorio = txtProducto.Text.Trim();
            int userID = Int32.Parse(Session["UsuarioID"].ToString());

            if (txtProductoID.Text.Length == 0)
            {
                int total = oLn_Empresa.VerificarRestriccion(Int32.Parse(Session["UsuarioID"].ToString()), "lab", 0);

                //OBTENER VALOR DE PAQUETE
                int paquete = Int32.Parse(Session["Paquete"].ToString());

                if (paquete==0 && total >= 1)
                {
                    //Response.Write("<script>alert('No puede crear más laboratorios con la licencia actual.');</script>");
                    Response.Write("<script>alert('" + etiquetas["ML01"] + "');</script>");
                }
                else if (paquete==2)
                {
                    oLn_Laboratorio.InsertarLab(oEnt_Laboratorio.NomLaboratorio, oEnt_Laboratorio.Ubicacion, Session["Ruc"].ToString(), userID);
                }
            }
            else
            {
                oEnt_Laboratorio.LaboratorioID = Int32.Parse(txtProductoID.Text.Trim());
                oLn_Laboratorio.ActualizarLaboratorio(oEnt_Laboratorio);
            }

            oList_Lab = oLn_Laboratorio.ListarLaboratorio(userID);
            gvLaboratorio.DataSource = oList_Lab;
            gvLaboratorio.DataBind();
        }





    }
}