using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Entidades;

namespace LimsWeb.Prueba
{
    public partial class CalculoFormula : System.Web.UI.Page
    {
        string Formula = "(A+B+C)/3";
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        private object Eval(string eqn)
        {
            DataTable dt = new DataTable();
            var result = dt.Compute(eqn, string.Empty);
            return result;
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                string result = Convert.ToString(Eval(txtEquation.Text.Trim()));
                lblResult.Text= result;
             
            }
            catch (Exception ex)
            {
                lblResult.Text = "Ocurrio un error: " + ex.Message.ToString();
                lblResult.ForeColor = Color.Red;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtEquation.Text = string.Empty;
            txtEquation.Focus();
            lblResult.Text = string.Empty;
        }



        protected void btnCalcularPromedio_Click(object sender, EventArgs e)
        {
            try
            {
                Formula = Formula.Replace("A", txtValor1.Text);
                Formula = Formula.Replace("B", txtValor2.Text);
                Formula = Formula.Replace("C", txtValor3.Text);


                string result = Convert.ToString(Eval(Formula));
                lblResultado.Text = result;

            }
            catch (Exception ex)
            {
                lblResultado.Text = "Ocurrio un error: " + ex.Message.ToString();
                lblResultado.ForeColor = Color.Red;
            }
        }

    }
}