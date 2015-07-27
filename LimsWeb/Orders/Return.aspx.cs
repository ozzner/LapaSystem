using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TwoCheckout;
using Entidades;
using LogicaNegocio;


namespace LimsWeb.Orders
{
    public partial class Return : System.Web.UI.Page
    {

        LN_PagosTwocheckout logicPayment = new LN_PagosTwocheckout();
        ENT_PagosTwocheckout entityPayment = new ENT_PagosTwocheckout();


        protected void Page_Load(object sender, EventArgs e)
        {
            TwoCheckoutConfig.SecretWord = "lapatec";
            TwoCheckoutConfig.SellerID = "901281879";

            var Return = new ReturnService();
            var Args = new ReturnCheckServiceOptions();
            Args.total = Request.Params["total"];
            Args.order_number = Request.Params["order_number"];
            Args.key = Request.Params["key"];
            bool result = Return.Check(Args);

            if (result) {

                int usuarioID = Int32.Parse(Session["UsuarioID"].ToString());
                String servicio = Session["Servicio"].ToString();
                String description = Request.Params["product_description"];
                String codPaquete = Request.Params["merchant_product_id"];
                int tipoPlan, process = 0;
                

                //Planes corporativos (Privado y Servicio)
                if (codPaquete.Equals("CO-S") || codPaquete.Equals("CO-P"))
                {
                    tipoPlan = 2;
                }
                 //Planes basicos (Privado y Servicio)
                else if (codPaquete.Equals("BA-S") || codPaquete.Equals("BA-P"))
                {
                    tipoPlan = 1;
                }
                //Planes gratuitos  GR-S Y GR-P (Privado y Servicio)
                else {
                    tipoPlan = 0;
                }

                entityPayment.quantity = 1;
                entityPayment.packageCod = codPaquete;
                entityPayment.description = description;
                entityPayment.amount = Decimal.Parse(Args.total);
                entityPayment.numberOrder = Int64.Parse(Args.order_number);
                entityPayment.licenceId = 0;
                entityPayment.key = Args.key;
                entityPayment.payMethod = Request.Params["pay_method"].ToString();
                entityPayment.email = Request.Params["email"].ToString();

                int resultado = logicPayment.storePayment(entityPayment, usuarioID,tipoPlan,ref process);
                String message;
                if (resultado > 0)
                {
                    message = "¡Pago correcto! Código de operación: " + entityPayment.numberOrder;
                }
                else {
                    message = "Error al registrar el pago. Consulte a soporte (PAY_001)";
                }

                Response.Redirect("../iAdministrador/vPlanes.aspx?message='" + message + "'");
              
            }else{
                String msj = "Hubo un error con sus credenciales";
                Response.Redirect("../iAdministrador/vPlanes.aspx?message='" + msj + "'");
            }
            
        }
    }
}