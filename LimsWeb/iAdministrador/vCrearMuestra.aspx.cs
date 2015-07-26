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
    public partial class vCrearMuestra : System.Web.UI.Page
    {
        
        LN_Parametro oLN_Parametro = new LN_Parametro();
        LN_Usuario oLN_Usuario = new LN_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ENT_ProductoParametro> oLista_Parametro = new List<ENT_ProductoParametro>();
            List<ENT_ProductoAtributo> oLista_Atributo = new List<ENT_ProductoAtributo>();
            List<ENT_Usuario> oLista_Usuario = new List<ENT_Usuario>();

            int contador = 1;
            lblRuta.Text = Session["NomLaboratorio"].ToString() + "/" + Session["NomProducto"].ToString();
            if (!IsPostBack)
            {
                oLista_Usuario = oLN_Usuario.ListarUsuario(Int32.Parse(Session["UsuarioID"].ToString()), Int32.Parse(Session["PerfilUsuarioID"].ToString()));
                oLista_Parametro = oLN_Parametro.ListarParametroXLab(Session["ProdLabCod"].ToString());
                oLista_Atributo = oLN_Parametro.ListarAtributoXLab(Session["ProdLabCod"].ToString());
                rFormulario.DataSource = oLista_Parametro;
                rFormulario.DataBind();
                repAtributo.DataSource = oLista_Atributo;
                repAtributo.DataBind();
            }

            txtMuestra.Focus();
        }


        protected void btnCrearLimpiar_Click(object sender, EventArgs e)
        {
            LN_Muestra oLN_Muestra = new LN_Muestra();
            bool resul = false;

            List<ENT_Muestra> oLista_Muestra = new List<ENT_Muestra>();
            List<ENT_Muestra> oLista_MuestraAttr = new List<ENT_Muestra>();
            string CodigoMuestra = txtMuestra.Text;
            string ProdLabCod = Session["ProdLabCod"].ToString();
            bool chkItems = false; 

            foreach (Control item in rFormulario.Items)
            {
                TextBox txtParametro = (TextBox)item.FindControl("txtParametro");
                CheckBox chk = (CheckBox)item.FindControl("chk");
                RadioButton rbBajo = (RadioButton)item.FindControl("rbBajo");
                RadioButton rbMedio = (RadioButton)item.FindControl("rbMedio");
                RadioButton rbAlto = (RadioButton)item.FindControl("rbAlto");


                if (chk.Checked)
                {
                    chkItems = true;
                    ENT_Muestra oEntidad = new ENT_Muestra();

                    oEntidad.NomParametro = txtParametro.Text;
                    if (rbBajo.Checked)
                    {
                        oEntidad.Prioridad = rbBajo.Text;
                    }
                    else if (rbMedio.Checked)
                    {
                        oEntidad.Prioridad = rbMedio.Text;
                    }
                    else if (rbAlto.Checked)
                    {
                        oEntidad.Prioridad = rbAlto.Text;
                    }
                    oLista_Muestra.Add(oEntidad);

                }
            }

            foreach (Control item in repAtributo.Items)
            {
                TextBox txtParametro = (TextBox)item.FindControl("txtParametro");
                CheckBox chk = (CheckBox)item.FindControl("chk");
                RadioButton rbBajo = (RadioButton)item.FindControl("rbBajo");
                RadioButton rbMedio = (RadioButton)item.FindControl("rbMedio");
                RadioButton rbAlto = (RadioButton)item.FindControl("rbAlto");


                if (chk.Checked)
                {
                    chkItems = true;
                    ENT_Muestra oEntidadAtt = new ENT_Muestra();

                    oEntidadAtt.NomParametro = txtParametro.Text;
                    if (rbBajo.Checked)
                    {
                        oEntidadAtt.Prioridad = rbBajo.Text;
                    }
                    else if (rbMedio.Checked)
                    {
                        oEntidadAtt.Prioridad = rbMedio.Text;
                    }
                    else if (rbAlto.Checked)
                    {
                        oEntidadAtt.Prioridad = rbAlto.Text;
                    }
                    oLista_MuestraAttr.Add(oEntidadAtt);

                }
            }

            /*foreach (Control item in rFormulario.Items)
            {
                TextBox txtParametro = (TextBox)item.FindControl("txtParametro");
                CheckBox chk = (CheckBox)item.FindControl("chk");
                RadioButton rbBajo = (RadioButton)item.FindControl("rbBajo");
                RadioButton rbMedio = (RadioButton)item.FindControl("rbMedio");
                RadioButton rbAlto = (RadioButton)item.FindControl("rbAlto");

                if (chk.Text.Equals("Atributo"))
                {
                    if (chk.Checked)
                    {
                        ENT_Muestra oEntidadAtrr = new ENT_Muestra();

                        oEntidadAtrr.NomParametro = txtParametro.Text;
                        if (rbBajo.Checked)
                        {
                            oEntidadAtrr.Prioridad = rbBajo.Text;
                        }
                        else if (rbMedio.Checked)
                        {
                            oEntidadAtrr.Prioridad = rbMedio.Text;
                        }
                        else if (rbAlto.Checked)
                        {
                            oEntidadAtrr.Prioridad = rbAlto.Text;
                        }
                        oLista_MuestraAttr.Add(oEntidadAtrr);
                    }

                }
                else
                {
                    if (chk.Checked)
                    {
                        ENT_Muestra oEntidad = new ENT_Muestra();

                        oEntidad.NomParametro = txtParametro.Text;
                        if (rbBajo.Checked)
                        {
                            oEntidad.Prioridad = rbBajo.Text;
                        }
                        else if (rbMedio.Checked)
                        {
                            oEntidad.Prioridad = rbMedio.Text;
                        }
                        else if (rbAlto.Checked)
                        {
                            oEntidad.Prioridad = rbAlto.Text;
                        }
                        oLista_Muestra.Add(oEntidad);
                    }
                }
            }*/

            if (chkItems)
            {
                resul = oLN_Muestra.InsertarMuestra(Int32.Parse(Session["UsuarioID"].ToString()), CodigoMuestra, ProdLabCod, oLista_Muestra, oLista_MuestraAttr);
                if (resul)
                {
                    Response.Write("<script>alert('La muestra ha sido creada Correctamente');</script>");
                }
                else
                {
                    Response.Write("<script>alert('error al insertar la muestra...');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Debe elegir por lo menos un parámetro o atributo.');</script>");
            }

        }

        protected void btnCrearContinuar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}