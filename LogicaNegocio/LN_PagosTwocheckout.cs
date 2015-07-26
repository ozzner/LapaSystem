using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LN_PagosTwocheckout
    {
        ADNT_PagosTwocheckout paymentTx = new ADNT_PagosTwocheckout();

        public int storePayment(ENT_PagosTwocheckout checkout, int userId, int plan, ref int process)
        {
            return paymentTx.storePaymentTwocheckout(checkout, userId, plan, ref process);
        }
    }
}