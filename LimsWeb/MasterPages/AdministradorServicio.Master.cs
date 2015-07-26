using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LimsWeb.MasterPages
{
    public partial class Principales : System.Web.UI.MasterPage
    {
        List<ENT_Empresa> oLista_Empresa = new List<ENT_Empresa>();
        List<ENT_Laboratorio> oLista_Laboratorio = new List<ENT_Laboratorio>();
        List<ENT_Producto> oLista_Producto = new List<ENT_Producto>();
        List<ENT_ProductoParametro> oLista_Parametro = new List<ENT_ProductoParametro>();
        List<ENT_Cliente> oLista_Cliente = new List<ENT_Cliente>();
        List<ENT_Atributo> oLista_Atributo = new List<ENT_Atributo>();

        LN_Atributo     oLN_Atributo    = new LN_Atributo();
        LN_Laboratorio  oLN_Laboratorio = new LN_Laboratorio();
        LN_Empresa      oLN_Empresa     = new LN_Empresa();
        LN_Producto     oLN_Producto    = new LN_Producto();
        LN_Parametro    oLN_Parametro   = new LN_Parametro();
        LN_Cliente      oLN_Cliente     = new LN_Cliente();
        LN_Idioma       oLN_Idioma      = new LN_Idioma();
         
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNombreCompleto.Text = Session["NombreCompleto"].ToString();

            string ruc = Session["RUC"].ToString();
            int PerfilUsuarioID = Int32.Parse(Session["PerfilUsuarioID"].ToString());

            if (PerfilUsuarioID != 1) {
                Response.Redirect("../iRegistro/Login.aspx");
                return;
            }

            oLista_Empresa = oLN_Empresa.ListarEmpresa(ruc);
            oLista_Laboratorio = oLN_Laboratorio.ListarLaboratorio(Int32.Parse(Session["UsuarioID"].ToString()));

           tvEstructura.DataSource = null;
           tvEstructura.DataBind();
          if (!IsPostBack) {

              if (Boolean.Parse(Session["Servicio"].ToString()) == false)
              {
                  CargarTreeViewEmpresa();
              }
              else {
                  CargarTreeViewServicio();
              }
           }
        }


       public void Select_Change(Object sender, EventArgs e)
        {
            string Nivel = tvEstructura.SelectedNode.Value;
            try
            {

                Nivel = Nivel.Substring(0, 3);
            }
            catch {
                Nivel = "CLI";
            }

                
                //   lblNombreCompleto.Text = Nivel;

            switch (Nivel) {
                case "EMP": Session["EmpresaCod"] = tvEstructura.SelectedNode.Value;
                    Response.Redirect("~/iAdministradors/Inicio.aspx");
                    break;
                case "LAB": Session["LaboratorioCod"] = tvEstructura.SelectedNode.Value;
                            Session["NomLaboratorio"] = tvEstructura.SelectedNode.Text;
                            Response.Redirect("~/iAdministradors/AsociarProducto.aspx");
                    break;
                case "PRO": Session["ProdLabCod"] = tvEstructura.SelectedNode.Value;
                                Session["NomProducto"] = tvEstructura.SelectedNode.Text;
                            ENT_Laboratorio oEnt = new ENT_Laboratorio();
                            oEnt = oLN_Laboratorio.ObtenerLab(tvEstructura.SelectedNode.Value);
                            Session["NomLaboratorio"] = oEnt.NomLaboratorio.ToString();
                            Response.Redirect("~/iAdministradors/Historial.aspx");
                    break;
                case "PAR": Session["ProdParaCod"] = tvEstructura.SelectedNode.Value;
                            Session["NomParametro"] = tvEstructura.SelectedNode.Text;
                            ENT_Parametro oEntidad = new ENT_Parametro();
                            oEntidad = oLN_Parametro.ObtenerLab(tvEstructura.SelectedNode.Value);

                            Session["NomLaboratorio"] = oEntidad.NomLaboratorio.ToString();
                            Session["NomProducto"] = oEntidad.NomProducto.ToString();                            

                            Response.Redirect("~/iAdministradors/EditarParametro.aspx");
                    break;

                case "CLI": Session["ClienteID"] = tvEstructura.SelectedNode.Value;
                            Session["NomCliente"] = tvEstructura.SelectedNode.Text;
                            //ENT_Cliente oEnt_Cli = new ENT_Cliente();

                            //oEntidad = oLN_Parametro.ObtenerLab(tvEstructura.SelectedNode.Value);

                            //Session["NomLaboratorio"] = oEntidad.NomLaboratorio.ToString();
                            //Session["NomProducto"] = oEntidad.NomProducto.ToString();

                            //Response.Redirect("~/iAdministrador/Cliente.aspx");
                            break;
    
            }
           // Session["LaboratorioCod"] = tvEstructura.SelectedNode.Value;
        }


        public void CargarTreeViewEmpresa() {

            tvEstructura.Nodes.Clear();
            foreach (ENT_Empresa oEntidad in oLista_Empresa)
            {
                TreeNode parentNode = new TreeNode(oEntidad.RazonSocial.ToString(), oEntidad.EmpresaCod.ToString());
                parentNode.ImageUrl = "..\\Content\\img\\Empresa.png";

                foreach (ENT_Laboratorio oEntidadLab in oLista_Laboratorio)
                {   
                    TreeNode LabNode = new TreeNode(oEntidadLab.NomLaboratorio.ToString(),
                                                     oEntidadLab.LaboratorioCod.ToString());

                    parentNode.ChildNodes.Add(LabNode);
                    LabNode.ImageUrl = "..\\Content\\img\\Laboratorio.png";

                    oLista_Producto = oLN_Producto.ListarProductoXLab(oEntidadLab.LaboratorioCod.ToString());

                    foreach (ENT_Producto oEntidadProd in oLista_Producto)
                    {
                        TreeNode ProdNode = new TreeNode(oEntidadProd.NombreProducto.ToString(), oEntidadProd.ProdLabCod.ToString());
                        LabNode.ChildNodes.Add(ProdNode);
                        ProdNode.ImageUrl = "..\\Content\\img\\Producto.png";


                        //oLista_Parametro = oLN_Parametro.ListarParametroXLab(oEntidadProd.ProdLabCod);
                        //foreach (ENT_ProductoParametro oEntidadPara in oLista_Parametro)
                        //{
                        //    TreeNode ParaNode = new TreeNode(oEntidadPara.NomParametro.ToString(), oEntidadPara.ProdParaCod.ToString());
                        //    ProdNode.ChildNodes.Add(ParaNode);
                        //    ParaNode.ImageUrl = "..\\Content\\img\\Producto.png";
                        //}

                    }
                }

                // parentNode.Collapse();

                // Show all checkboxes
                //tvEstructura.ShowCheckBoxes = TreeNodeTypes.All;
                tvEstructura.Nodes.Add(parentNode);

                tvEstructura.ExpandAll();
            }
        }


        public void CargarTreeViewServicio()
        {
            tvEstructura.Nodes.Clear();
            foreach (ENT_Empresa oEntidad in oLista_Empresa)
            {
                TreeNode parentNode = new TreeNode(oEntidad.RazonSocial.ToString(), oEntidad.EmpresaCod.ToString());
                parentNode.ImageUrl = "..\\Content\\img\\Empresa.png";

                foreach (ENT_Laboratorio oEntidadLab in oLista_Laboratorio)
                {
                    TreeNode LabNode = new TreeNode(oEntidadLab.NomLaboratorio.ToString(),
                                                     oEntidadLab.LaboratorioCod.ToString());

                    parentNode.ChildNodes.Add(LabNode);
                    LabNode.ImageUrl = "..\\Content\\img\\Laboratorio.png";

                    oLista_Cliente = oLN_Cliente.ListarClientesXLab(oEntidadLab.LaboratorioCod.ToString()); 

                    //oLista_Producto = oLN_Producto.ListarProductoXLab(oEntidadLab.LaboratorioCod.ToString());

                    foreach (ENT_Cliente oEnt_Cli in oLista_Cliente)
                    {
                        TreeNode CliNode = new TreeNode(oEnt_Cli.NombreCliente.ToString(), oEnt_Cli.ClienteID.ToString());
                        LabNode.ChildNodes.Add(CliNode);
                        CliNode.ImageUrl = "..\\Content\\img\\iconClient.png";

                        oLista_Producto = oLN_Producto.ListarProductoXLabServicio(oEnt_Cli.ClienteID.ToString());

                        foreach (ENT_Producto oEnt_Prod in oLista_Producto)
                        {
                            TreeNode ProdaNode = new TreeNode(oEnt_Prod.NombreProducto, oEnt_Prod.ProdLabCod.ToString());
                            CliNode.ChildNodes.Add(ProdaNode);
                            ProdaNode.ImageUrl = "..\\Content\\img\\Producto.png";
                        }

                        //oLista_Atributo = oLN_Atributo.ListarAtributoXLabServicio(oEnt_Cli.ClienteID.ToString());

                        //foreach (ENT_Atributo oEnt_Atr in oLista_Atributo)
                        //{
                        //    TreeNode AtrNode = new TreeNode(oEnt_Atr.NomAtributo, oEnt_Atr.AtributoID.ToString());
                        //    CliNode.ChildNodes.Add(AtrNode);
                        //    AtrNode.ImageUrl = "..\\Content\\img\\Producto.png";
                        //}

                    }
                }

                // parentNode.Collapse();

                // Show all checkboxes
                //tvEstructura.ShowCheckBoxes = TreeNodeTypes.All;
                tvEstructura.Nodes.Add(parentNode);

                tvEstructura.ExpandAll();
            }
        }

        protected void cambiaIdioma(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Session["Etiquetas"] = oLN_Idioma.ObtenerEtiquetasPorIdioma(lb.CommandArgument);
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["Perfil"] = "";
            Session["NombreCompleto"] = "";
            Session["UsuarioID"] = "";
            Response.Redirect("../iRegistro/Login.aspx");
        }

        protected void btnCrearMuestra_Click(object sender, EventArgs e)
        {

        }
    }
}